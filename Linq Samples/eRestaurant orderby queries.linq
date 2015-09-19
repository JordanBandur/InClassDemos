<Query Kind="Expression">
  <Connection>
    <ID>f7303b1a-da38-4932-ba34-19ae4c26a4b7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Orderby

// Default is ascending
from food in Items 
orderby food.Description 
select food

// also available descending
from food in Items
orderby food.CurrentPrice descending
select food

// Can use both ascending and descending
from food in Items
orderby food.CurrentPrice descending, food.Calories ascending
select food

// You can use where and orderby together
from food in Items
orderby food.CurrentPrice descending, food.Calories ascending
where food.MenuCategory.Description.Equals("Entree")
select food