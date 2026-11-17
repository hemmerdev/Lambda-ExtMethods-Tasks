// ============================================================
// Webshop – klasser og testdata til øvelserne om lambda-udtryk
// og extension methods (uge 47)
//
// Kopiér filen ind i et Console App (.NET 6 eller nyere), og skriv
// using Webshop.Lambda; øverst i Program.cs.
// Kategorierne og produkterne er de samme som i WebshopData.cs fra
// uge 40 og i webshop-databasen fra uge 38.
//
// I skal ikke rette i filen. Jeres egne extension methods skriver I
// i jeres egne statiske klasser, fx ProductExtensions. Det er netop
// pointen: I udvider Product og decimal uden at ændre deres kode.
//
// Eksempel:
//   Func<Product, bool> erBillig = p => p.Price < 1000;
//   Console.WriteLine(erBillig(WebshopData.Products[2]));   // True (Nokia Telefon)
// ============================================================
using System;
using System.Collections.Generic;

namespace Webshop.Lambda
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = "";
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }

    public static class WebshopData
    {
        public static List<Category> Categories { get; } = new()
        {
            new() { CategoryId = 1, CategoryName = "Electronics" },
            new() { CategoryId = 2, CategoryName = "Home Appliances" },
            new() { CategoryId = 3, CategoryName = "Books" },
            new() { CategoryId = 4, CategoryName = "Phones" },
            new() { CategoryId = 5, CategoryName = "Furniture" },
        };

        public static List<Product> Products { get; } = new()
        {
            new() { ProductId = 1, ProductName = "iPhone 13",          CategoryId = 4, Price = 4999.99m, StockQuantity = 3 },
            new() { ProductId = 2, ProductName = "Samsung Galaxy S21", CategoryId = 4, Price = 2699.99m, StockQuantity = 15 },
            new() { ProductId = 3, ProductName = "Nokia Telefon",      CategoryId = 4, Price = 999.99m,  StockQuantity = 2 },
            new() { ProductId = 4, ProductName = "Stationær Telefon",  CategoryId = 4, Price = 349.99m,  StockQuantity = 50 },
            new() { ProductId = 5, ProductName = "Bærbar Computer",    CategoryId = 1, Price = 2200.00m, StockQuantity = 2 },
            new() { ProductId = 6, ProductName = "Tablet",             CategoryId = 1, Price = 1300.00m, StockQuantity = 4 },
        };
    }
}
