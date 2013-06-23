# META-xel
__M-x for the whole OS...__


## Overview

META-xel takes the idea of M-x from `emacs` and moves it into a OS-wide tool for Windows&trade;. The UI is implemented in C# and Windows Forms. All commands are implemented in Clojure CLR.


## Building

From the command line cd to the root `META-xel` project directory and `build-release`. The script may need to be updated to point to the latest installed .NET runtime on your system.

The binaries can be found in `bin/Release/`.


## Installing

After the application builds `install` a shortcut to the Windows&trade; `Startup` directory to start META-xel on startup.


## Uninstalling

To uninstall run `uninstall`


## Customizing the Available Commands

Copy `user.clj` to `.xel/user.clj` in your home directory. META-xel will no longer load the default `user.clj`. Any additional Clojure (`.clj`) source files in `.xel/` can be `use`ed or `require`d from within `user.clj`.


## Caveat

This is very much a work in progress.


## License

Licensed under the Eclipse Public License. Copyright Caleb Peterson 2013.