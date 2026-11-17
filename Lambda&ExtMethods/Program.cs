using Webshop.Lambda;

internal class Program
{
    private static void Main(string[] args)
    {
        // Opgave 2
        Func<int, int> square = x => x * x;
        Console.WriteLine(square(5)); // Returns 25

        Action<string> sayHello = name => Console.WriteLine($"Hello, {name}!");
        sayHello("Emmerence");

        Func<int, int, int> add = (a, b) => a + b;
        Console.WriteLine(add(5, 3)); // Returns 8

        static int Calculate(int a, int b, Func<int, int, int> method)
        {
            return method(a, b);
        }

        int result = Calculate(5, 3, (x, y) => x - y); // Returns 2
        Console.WriteLine(result);

        Func<int, bool> isEven = x => x % 2 == 0;
        Console.WriteLine(isEven(4));
        Console.WriteLine(isEven(7));

        Action<int> printIsEven = x =>
        {
            if (isEven(x))
            {
                Console.WriteLine($"{x} is even");
            }
            else
            {
                Console.WriteLine($"{x} is odd");
            }
        };

        printIsEven(4);
        printIsEven(7);

        int discount = 10;
        Func<decimal, decimal> withDiscount = price => price * (100 - discount) / 100;

        Console.WriteLine(withDiscount(200));

        string tekst = "Lambda og extension methods";
        Console.WriteLine(tekst.WordCount()); // 4

        Console.WriteLine(4.IsEven());
        Console.WriteLine(7.IsEven());

        Console.WriteLine("Samsung Galaxy S21".FirstWord());


        // Opgave 3.1
        Func<Product, bool> isCheap = p => p.Price < 1000;
        Func<Product, bool> isPhone = p => p.CategoryId == 4;
        Func<Product, bool> isLowStock = p => p.StockQuantity < 5;
        Console.WriteLine();
        foreach (var product in WebshopData.Products)
        {
            if (isCheap(product))
            {
                Console.WriteLine($"{product.ProductName} is cheap");
            }


        }
        Console.WriteLine();
        foreach (var product in WebshopData.Products)
        {
            if (isPhone(product))
            {
                Console.WriteLine($"{product.ProductName} is a phone");
            }
        }
        Console.WriteLine();
        foreach (var product in WebshopData.Products)
        {
            if (isLowStock(product))
            {
                Console.WriteLine($"{product.ProductName} is low on stock ({product.StockQuantity} pcs.)");
            }
        }
        Console.WriteLine();


        foreach (var product in FilterProducts(WebshopData.Products, p => p.CategoryId == 4 && p.Price > 2000))
        {
            Console.WriteLine($"{product.ProductName} is a phone and cost more than 2000");
        }

        static List<Product> FilterProducts(List<Product> products, Func<Product, bool> condition)
        {
            var filteredProducts = new List<Product>();
            foreach (var product in products)
            {
                if (condition(product))
                {
                    filteredProducts.Add(product);
                }
            }

            return filteredProducts;
        }

        WebshopData.Products.FilterProductsWhere(p => p.IsLowStock());

        // Same thing as above
        //WebshopData.Products.Where(p => p.IsLowStock());

        WebshopData.Products.FilterProductsWhere(p => p.CategoryId == 4 && p.IsLowStock());

        Action<Product> productListPrint = product =>
        {
            Console.Write($"\n{product.ProductName}: {product.Price}");

            if (product.IsLowStock())
            {
                Console.Write($" is low on stock ({product.StockQuantity} pcs.)");
            }
        };

        foreach (var product in WebshopData.Products)
        {
            productListPrint(product);
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();


        // Opgave 3.2

        Console.WriteLine(4999.99m.ToDKKString());
        Console.WriteLine(WebshopData.Products[0]
            .PriceWithVAT()
            .ToDKKString());
        Console.WriteLine();
        var lowStockProducts = WebshopData.Products
            .Where(p => p.IsLowStock());

        foreach (var product in lowStockProducts)
        {
            Console.WriteLine($"{product.ProductName}: {product.PriceWithVAT().ToDKKString()} ({product.StockQuantity} pcs.)");
        }

        Console.WriteLine(WebshopData.Products[2].StockQuantity);

        WebshopData.Products[2].Restock(10);

        Console.WriteLine(WebshopData.Products[2].StockQuantity);

        int number = 5;
        Console.WriteLine(number);

        number = number.AddOne();

        Console.WriteLine(number);

    }
}

public static class StringExtensions
{
    public static int WordCount(this string str)
    {
        return str.Split(' ').Length;
    }

    public static string FirstWord(this string str)
    {
        return str.Split(' ')[0];
    }
}

public static class IntExtensions
{
    public static bool IsEven(this int number)
    {
        return number % 2 == 0;
    }
}

public static class ProductExtensions
{
    public static string ToDKKString(this decimal amount)
    {
        return $"{amount:N2} kr.";
    }

    public static bool IsLowStock(this Product product)
    {
        return product.StockQuantity < 5;
    }

    public static decimal PriceWithVAT(this Product product)
    {
        return product.Price * 1.25m; // Assuming 25% VAT
    }

    public static void Restock(this Product product, int quantity)
    {
        product.StockQuantity += quantity;
    }

    public static int AddOne(this int number)
    {
        return ++number;
    }

    public static List<Product> FilterProductsWhere(this List<Product> products, Func<Product, bool> condition)
    {
        var filteredProducts = new List<Product>();
        foreach (var product in products)
        {
            if (condition(product))
            {
                filteredProducts.Add(product);
            }
        }

        return filteredProducts;
    }
}
