<Query Kind="Expression">
  <Connection>
    <ID>f7303b1a-da38-4932-ba34-19ae4c26a4b7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Where clause

// List all tabels that hold more than 3 people
// Query syntax
from row in Tables
where row.Capacity > 3 
select row

// Method syntax
Tables.Where(row => row.Capacity > 3)

// List all items with more than 500 calories
from food in Items 
where food.Calories > 500
select food

or

Items.Where(row => row.Calories > 500)

// List all items with more than 500 calories and selling for more than $10.00
from food in Items 
where food.Calories > 500 &&
	  food.CurrentPrice > 10.00m
select food

or

Items.Where(row => (row.Calories > 500) && (row.CurrentPrice > 10.00m))

// List all items with more than 500 calories and are Entrees on the menu
from food in Items 
where food.Calories > 500 &&
	  food.MenuCategory.Description.Equals("Entree")
select food

or

Items.Where(row => (row.Calories > 500) && (row.MenuCategory.Description.Equals("Entree")))