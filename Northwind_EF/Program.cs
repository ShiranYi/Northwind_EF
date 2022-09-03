using Northwind_EF.Models;

var db = new NorthwindContext();

// 1
Console.WriteLine("Q1");
var query1 = (from product in db.Products
             select new { product.ProductName, product.QuantityPerUnit }).ToList();

query1.ForEach(x => Console.WriteLine($"{x.ProductName} - {x.QuantityPerUnit}"));

// 2
Console.WriteLine("\nQ2");
var query2 = (from product in db.Products
             where product.Discontinued == false
             select new { product.ProductId, product.ProductName }).ToList();

query2.ForEach(x => Console.WriteLine($"{x.ProductId} {x.ProductName}"));

// 3
Console.WriteLine("\nQ3");
var query3 = (from product in db.Products
              where product.Discontinued == true
              select new { product.ProductId, product.ProductName }).ToList();

query3.ForEach(x => Console.WriteLine($"{x.ProductId} {x.ProductName}"));

// 4
Console.WriteLine("\nQ4");
var query4 = (from product in db.Products
             orderby product.UnitPrice descending
             select new { product.ProductName, product.UnitPrice }).ToList();

query4.ForEach(x => Console.WriteLine($"{x.ProductName} | price: {x.UnitPrice}"));

// 5
Console.WriteLine("\nQ5");
var query5 = (from product in db.Products
              where product.Discontinued == false && product.UnitPrice < 20
              select new {product.ProductId, product.ProductName, product.UnitPrice }).ToList();

query5.ForEach(x => Console.WriteLine($"{x.ProductId} | {x.ProductName} | price: {x.UnitPrice}"));

// 6
Console.WriteLine("\nQ6");
var query6 = (from product in db.Products
              where product.UnitPrice > 15 && product.UnitPrice < 25
              select new { product.ProductId, product.ProductName, product.UnitPrice }).ToList();

query6.ForEach(x => Console.WriteLine($"{x.ProductId} | {x.ProductName} | price: {x.UnitPrice}"));

// 7
Console.WriteLine("\nQ7");
var query7 = (from product in db.Products
              where product.UnitPrice > db.Products.Average(a=>a.UnitPrice)
              select new { product.ProductName, product.UnitPrice }).ToList();

query7.ForEach(x => Console.WriteLine($"{x.ProductName} | price: {x.UnitPrice}"));

// 8
Console.WriteLine("\nQ8");
var query8 = (from product in db.Products
              orderby product.UnitPrice descending
              select new { product.ProductName, product.UnitPrice }).Take(10).ToList();

query8.ForEach(x => Console.WriteLine($"{x.ProductName} | price: {x.UnitPrice}"));

// 9
Console.WriteLine("\nQ9");
var cur = db.Products.Where(x => x.Discontinued == false).Count();
var dis = db.Products.Where(x => x.Discontinued == true).Count();

Console.WriteLine($"Current products: { cur} | Discontinued products: {dis}");

// 10
Console.WriteLine("\nQ10");
var query9 = (from product in db.Products
              where product.UnitsInStock < product.UnitsOnOrder
              select new { product.ProductName, product.UnitsOnOrder, product.UnitsInStock }).ToList();

query9.ForEach(x => Console.WriteLine($"{x.ProductName} | {x.UnitsOnOrder} | {x.UnitsInStock}"));
