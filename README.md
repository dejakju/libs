# libs

A collection of helper classes which provide functions for a variety of purposes.

---
in 
## Libraries

### Core - A dumber name could have never been chosen. The core of what? An egg or a planet? But let's stick to it, because it sounds important, neccessary or at least, non disposable. Maybe even cool considering having said nothing but yet still existing at the core of everything and everywhere. Herein i put all the stuff i don't know where to put otherwise.

*FilterBy* - Extension Method (pretty much like LINQ's Where())

*ThenFilterBy* - dito., just a different name

*Measure* - Simple Stopwatch function

*MeasureRuntime* - Prints the runtime of a lambda function to the Console

---

### DOS - A collection to simulate (stimulate? emulate? ejaculate?) Disk Operation System's functions

*DOSException* - A derived class for specific 'DOS' exceptions

*DOSCode* - One huge monolith for all the various 'DOS' types

*CreateDir* - Short for the System.IO's Directory.CreateDirectory() function (returns DirectoryInfo structure)

*GetEnv* - Short for the System.Environment.GetEnvironmentVariable() function (returns the string if found on windows, otherwise string.Empty)

*WaitForKey* - Wait for a specified ConsoleKey to be pressed (this function call blocks - that is deliberately done)

*PressAnyKeyToContinue* - Prints the function name to the console and waits for any keystroke (this function call blocks)

---

### Hash - A few simpley hash and encryption algos and converting methods for convenience

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

### Node - A generic node class for holding two informations: an object (aka payload) and the next node (if any, otherwise null). Could be used eg. in single linked lists or any other basic data structure

#### Members

*T data* - Any generic type as the data
*Node<T> next* - Pointer to the next node (or null)

#### Constructors

*Node()* - The default empty contructor (data is set to default and next node to null)
*Node(T o)* - Create node of generic type 'o' (next node is set to null)
*Node(T o, Node<T> n)* - Create node of generic type 'o' and the next node 'n'

#### Methods

*getData()* - Gets the data
*getNextNode()* - Gets the next node
*setData(T o)* - Sets the data 'o'
*setNextNode(Node<T> n)* - Sets the next node 'n'


---
