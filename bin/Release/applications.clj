(ns applications
  (:import [System.Diagnostics Process]))



(defn- exec
  ([filename]      (Process/Start filename))
  ([filename args] (Process/Start filename args)))



(defn browse
  "Browse to the given URI"
  [uri] (exec (if (.StartsWith uri "http://")
                uri
                (str "http://" uri))))

(defn e-mail
  "Compose an e-mail"
  ([]   (exec "mailto:"))
  ([to] (exec (str "mailto:" to))))



(defn !npp [] (exec "C:/Program Files (x86)/Notepad++/notepad++.exe"))

(defn !console [] (exec "C:/Program Files (x86)/Console2/Console.exe"))

(defn !chrome [] (exec "C:/Users/caleb/AppData/Local/Google/Chrome/Application/chrome.exe"))

(defn !gmail [] (exec "C:/Users/caleb/AppData/Local/Google/Chrome/Application/chrome.exe"
                      "--app=https://mail.google.com/mail"))

(defn !home      [] (exec "C:/Users/caleb/"))
(defn !downloads [] (exec "C:/Users/caleb/Downloads"))
(defn !workspace [] (exec "C:/Users/caleb/Dropbox/Work"))