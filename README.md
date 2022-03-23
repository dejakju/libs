# libs

A collection of helper classes which provide functions for a variety of purposes.

---
in 
## Libraries

### Core

*FilterBy* - Extension Method (pretty much like LINQ's Where())

*ThenFilterBy* - dito., just a different name

*Measure* - Simple Stopwatch function (not recommended for pro/deploy apps)

*MeasureRuntime* - Prints runtime of a lambda function to the Console (also not recommended for pro/deploy apps)

---

### DOS

*DOSException* - A derived class for specific 'DOS' Exceptions

*DOSCode* - One huge monolith for all the 'DOS' types

*CreateDir* - Short for the System.IO's Directory.CreateDirectory() function (returns DirectoryInfo structure)

*GetEnv* - Short for the System.Environment.GetEnvironmentVariable() function (returns the string if found on windows, otherwise string.Empty)

*WaitForKey* - Wait for a specified ConsoleKey to be pressed (this function call blocks - that is deliberately done)

*PressAnyKeyToContinue* - Prints the function name to the console and waits for any keystroke (this function call blocks)

---

### Hash

*MD5* - Return a MD5 hash for the given string

*SHA1* - Returns a SHA1 hash for the given string

*Encrypt* - Encrypt a byte array with the TrippleDES method

*Decrypt* - Decrypts a byte array with the TrippleDES method

*Encode* - Encodes a string into a byte array

*Decode* -  Decodes a byte array back into a string

---

### Math

*NthFibonacci* - Calculate the n-th fibonacci sequence using memoization (max. 79th)

---

### Node

A simple node class for holding two information, an object (aka payload) and the next node (if any, otherwise null). Could be used in i.e. single linked lists or any basic data structure.

---
