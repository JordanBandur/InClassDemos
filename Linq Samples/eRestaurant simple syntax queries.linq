<Query Kind="Statements">
  <Connection>
    <ID>f7303b1a-da38-4932-ba34-19ae4c26a4b7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Simpliest form for dumping an entity
Waiters

// Simple query snytax
from person in Waiters 
select person

// Simple method syntax
Waiters.Select(person => person)

// Inside our project we will be writing C# statemnet
var results = from person in Waiters
				select person;
// To display the contents of a var in linqPad
// use the .Dump() method
results.Dump();

// Implemented inside a VS project's class library BLL method
//[DataObjectMethod(DataObjectMethodType.Select,false)]
//public List<Waiters> SomeMethodName ()
{
	// You will need to connect to your DAL object
	// this will be done using a new xxxxx() constructor
	// assume your connection var is called contextvariable
	
	// Do your query
	//var results = from person in contextvariable.Waiters
	//			select person;
	//Return your results
	//return results.ToList();
}