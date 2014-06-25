/*
 * Date: 6/11/2013
 * Time: 7:03 AM
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Scripting.Utils;
using Newtonsoft.Json;
using RestSharp;
using clojure.lang;

namespace MetaX.UI
{
	/// <summary>
	/// Controller Interface.
	/// </summary>
	public interface IController
	{
		void RefreshCommands();
		void ExecuteCommand(string command);
	}
	
	public class EmbeddedController : IController
	{
		private readonly string XelHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/.xel/";
		private readonly Form view;
		private readonly TextBox command;
		
		public EmbeddedController(Form view, TextBox command)
		{
			this.view = view;
			this.command = command;
			
			RT.load("main");
			
			System.Environment.SetEnvironmentVariable(RT.ClojureLoadPathString, XelHome);
		}
		
		public void RefreshCommands()
		{
			LoadCustom();
			EnumerateCommands();
		}
		
		private void LoadCustom()
		{
			try
			{
				var loadCustom = RT.var("main", "load-custom");
				loadCustom.invoke(XelHome);
			}
			catch (Exception e)
			{
				Trace.WriteLine("Failed to load user.clj : " + e.Message);
				Trace.WriteLine(e.StackTrace);
				
				FeedbackForm.Show(this.view, "Failed to load user.clj", e);
			}
		}
		
		private void EnumerateCommands()
		{
			var listCommands = RT.var("main", "list-commands");
			IList<Object> commands = (IList<Object>) listCommands.invoke();
			
			if (commands != null)
			{
				var source = new AutoCompleteStringCollection();
				source.AddRange(Enumerable.ToArray(commands.Select(cmd => cmd.ToString())));
				this.command.AutoCompleteCustomSource = source;
			}
			else
			{
				Trace.TraceError("unable to enumerate available commands");
			}
		}
		
		public void ExecuteCommand(String command)
		{
			try
			{
				var exec = RT.var("main", "exec-command");
				var result = exec.invoke(command);
				
				// FIXME only show some predefined container type i.e. FeedbackMessage etc...
				if (result != null && result.GetType() == typeof(FeedbackMessage))
				{
					// FIXME focus FeedbackForm
					FeedbackForm.Show(this.view, (FeedbackMessage) result);
				}
			}
			catch (Exception e)
			{
				Trace.WriteLine(e.Message);
				Trace.WriteLine(e.StackTrace);
				
				FeedbackForm.Show(this.view, "Error executing command: " + command, e);
			}
		}
	}
	
	public class HttpController : IController
	{
	
		/// <summary>
		/// Command API Enumeration Result
		/// </summary>
		public class API
		{
			public List<string> Commands { get; set; }
		}
		
		private readonly Config config;
		private readonly TextBox command;
		
		public HttpController(Config config, TextBox command)
		{
			this.config = config;
			this.command = command;
		}
		
		public void RefreshCommands()
		{
			var client = new RestClient(config.EndpointBaseURL);
			var request = new RestRequest(config.EndpointResource, Method.GET);
			
			client.ExecuteAsync<API>(request,
			                    response => {
			                         	var api = JsonConvert.DeserializeObject<API>(response.Content);
			                         	BuildCommandAutoCompleteSource(api.Commands.ToArray());
			                    });
		}
		
		delegate void SetCommandAutoCompleteSourceCallback(AutoCompleteStringCollection source);
		
		private void BuildCommandAutoCompleteSource(string[] commands)
		{
			var source = new AutoCompleteStringCollection();
			source.AddRange(commands);
		
			if (this.command.InvokeRequired)
			{
				this.command.Invoke(
					new SetCommandAutoCompleteSourceCallback(SetCommandAutoCompleteSource),
					new object[] { source });
			}
			else
			{
				SetCommandAutoCompleteSource(source);
			}
		}
		
		private void SetCommandAutoCompleteSource(AutoCompleteStringCollection source)
		{
			this.command.AutoCompleteCustomSource = source;
		}
		
		public void ExecuteCommand(string command)
		{
			var client = new RestClient(config.EndpointBaseURL);
			var request = new RestRequest(config.EndpointExecute, Method.POST);
			
			request.AddParameter("command", command);

			client.ExecuteAsync(request, response => {
			                    	Trace.WriteLine(command + " : " + response.StatusCode);
			                    });
		}
	}
}
