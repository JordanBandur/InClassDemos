<Query Kind="Statements">
  <Connection>
    <ID>f7303b1a-da38-4932-ba34-19ae4c26a4b7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

(from theBill in BillItems
where theBill.BillID == 104
select theBill.SalePrice * theBill.Quantity).Sum()

(from customer in Bills
where customer.PaidStatus == true
select customer.BillItems.Sum(theBill => theBill.SalePrice * theBill.Quantity)).Max()

// The average paid bill 

(from customer in Bills
where customer.PaidStatus == true
select customer.BillItems.Sum(theBill => theBill.SalePrice * theBill.Quantity)).Average()

// What is the average number of items per paid bill
// We need to get a list of numbers representing the items per bill
// We take an average of the List

(from customer in Bills 
where customer.PaidStatus
select customer.BillItems.Count()).Average()