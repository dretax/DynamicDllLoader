# DynamicDllLoader
DynamicDllLoader in C# for native dlls

# Loading a DLL from memory
This tutorial describes a technique how a dynamic link library (DLL) can be loaded from memory without storing it on the hard-disk first.

# Overview
The default windows API functions to load external libraries into a program (LoadLibrary, LoadLibraryEx) only work with files on the filesystem. It’s therefore impossible to load a DLL from memory. But sometimes, you need exactly this functionality (e.g. you don’t want to distribute a lot of files or want to make disassembling harder). Common workarounds for this problems are to write the DLL into a temporary file first and import it from there. When the program terminates, the temporary file gets deleted.

In this tutorial, I will describe first, how DLL files are structured and will present some code that can be used to load a DLL completely from memory – without storing on the disk first.

https://www.joachim-bauch.de/tutorials/loading-a-dll-from-memory/
