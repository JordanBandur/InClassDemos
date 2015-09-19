<Query Kind="Expression">
  <Connection>
    <ID>f7303b1a-da38-4932-ba34-19ae4c26a4b7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Groupby
from food in Items
group food by food.MenuCategory.Description

// This creates a key with a value and the row collection for that key value

// more than one field
from food in Items
group food by new {food.MenuCategory.Description, food.CurrentPrice}