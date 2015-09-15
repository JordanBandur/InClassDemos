<Query Kind="Program" />

void Main()
{
	// Simple concatenation 
	//"Hello World" 
	//5 + 7
	
	// Simple C# statement
	//string name = "Jordan";
	//string message = "Hello " + name;
	//message.Dump();
	
	// Simple C# program 
	//method call
	SayHello("Jordan");
}

// Define other methods and classes here
public void SayHello(string name)
{
	string message = "Hello " + name;
	message.Dump();
}