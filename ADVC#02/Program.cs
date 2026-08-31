namespace ADVC_02
{
    internal class Program
    {
        // Task 1 Search Method 3shan btakhod Product w trg3 condition bool (True/False) l search
        public static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> result = new List<Product>();

            foreach (Product product in products)
            {
                if (filter(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }

        // Task 3.1 PrintReport Method 3shan btakhod Product w mesh bt return haga (void), b t print bs
        public static void PrintReport(List<Product> products, Action<Product> action)
        {
            foreach (Product product in products)
            {
                action(product);
            }
        }

        //3.2. Transform Products 3shan btakhod Product w trg3 type gdeed (Transform)
        public static List<TResult> TransformProducts<TResult>(List<Product> products, Func<Product, TResult> transformer)
        {
            List<TResult> result = new List<TResult>();

            foreach (Product product in products)
            {
                result.Add(transformer(product));
            }

            return result;
        }

        // Task 03.3: FilterProducts Method
        public static List<Product> FilterProducts(List<Product> products, Predicate<Product> match)
        {
            List<Product> result = new List<Product>();

            foreach (Product product in products)
            {
                if (match(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }

        static void Main(string[] args)
        {


            List<Product> catalog = new()
            {
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
                new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
                new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
                new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
                new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
                new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
                new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
                new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
                new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
                new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
            };

            // Task 1: Search using Func<Product, bool>
            List<Product> electronics = SearchProducts(catalog, p => p.Category == "Electronics");
            List<Product> cheapProducts = SearchProducts(catalog, p => p.Price < 50);
            List<Product> inStockProducts = SearchProducts(catalog, p => p.Stock > 0);
            List<Product> cheapClothing = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);

            Console.WriteLine("=== Electronics ===");
            foreach (Product p in electronics)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            Console.WriteLine("\n--- Under $50 ---");
            foreach (Product p in cheapProducts)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            Console.WriteLine("\n--- In-Stock Product ---");
            foreach (Product p in inStockProducts)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            Console.WriteLine("\n--- Clothing Under $100 ---");
            foreach (Product p in cheapClothing)
            {
                Console.WriteLine($"{p.Name} - {p.Category} - ${p.Price} (Stock: {p.Stock})");
            }

            // Task 3.1: Reports using Action<Product>
            Console.WriteLine("\n--- Short Report ---");
            PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            Console.WriteLine("\n--- Detailed Report ---");
            PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));

            // Task 3.2: Transform using Func<Product, TResult>
            Console.WriteLine("\n--- Summary List ---");
            List<string> summaryList = TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
            foreach (string item in summaryList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n--- Price Label ---");
            List<string> priceLabels = TransformProducts(catalog, p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}");
            foreach (string label in priceLabels)
            {
                Console.WriteLine(label);
            }

            // Task 3.3: Low-stock alert using Predicate<Product>
            Console.WriteLine("\n--- Low-Stock Alert ---");
            List<Product> lowStockProducts = FilterProducts(catalog, p => p.Stock < 20);
            foreach (Product p in lowStockProducts)
            {
                Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
            }
        }
    }
}
