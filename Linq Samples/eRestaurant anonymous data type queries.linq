<Query Kind="Expression">
  <Connection>
    <ID>f7303b1a-da38-4932-ba34-19ae4c26a4b7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

// Anonymousdata type queries
from food in Items 
where food.MenuCategory.Description.Equals("Entree")
		&& food.Active
		orderby food.Active
orderby food.CurrentPrice descending
select new //POCOObjectName
{
	Description = food.Description, 
	price = food.CurrentPrice,
	Cost = food.CurrentCost,
	Profit = food.CurrentPrice - food.CurrentCost
}
