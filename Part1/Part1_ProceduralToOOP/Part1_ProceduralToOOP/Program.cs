namespace Part1_ProceduralToOOP;

    internal class Program
    {
        static void Main(string[] args)
        {
        var order = new OrderStore();
        SeedDate(order);
      bool Running=true;
        while (Running)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("      ORDER MANAGEMENT SYSTEM (C#)      ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. View All Customers");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. View All Orders");
            Console.WriteLine("4. Add New Customer");
            Console.WriteLine("5. Add New Product");
            Console.WriteLine("6. Create New Order");
            Console.WriteLine("7. View Total Paid Sales");
            Console.WriteLine("0. Exit");
            Console.WriteLine("========================================");
            Console.Write("Select an option: ");
            int option = int.Parse(Console.ReadLine()!);
            
            switch (option)
            {
                case 1:
                    PrintALLCustomers(order);
                    break;
                case 2:
                    PrintALLProducts(order);
                    break;
                case 3:
                    PrintALLOredrs(order);
                    break;
                case 4:
                    AddCustomer(order);
                    break;
                case 5:
                    AddProduct(order);
                    break;
                case 6:
                    CreateORDRER(order);
                    break;
                case 7:
                    order.CalculateTotalOrders();
                    break;
                case 0:
                    Running = false;
                    Console.WriteLine("Exiting program... Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
            if (Running)
            {
                Console.WriteLine("\nPress Any Key to return to main menu...");
                Console.ReadKey();
            }
        }


        }
    public static void PrintALLCustomers(OrderStore order)
    {
        Console.WriteLine("=== ALL CUSTOMERS ===");
        if (order.Customer.Count == 0)
        {
            Console.WriteLine("No customers found.");
            return;
        }
            foreach(var c in order.Customer)
        {
            Console.WriteLine($"[ID: {c.Id}] Name: {c.Name,-15} | Email: {c.Email,-20} | City: {c.City,-10} | VIP: {(c.IsVip ? "Yes" : "No")}");
        }           
    }
    public static void PrintALLProducts(OrderStore order)
    {
        Console.WriteLine("=== ALL PRODUCTS ===");
        if (order.Product.Count == 0)
        {
            Console.WriteLine("No PRODUCTS found.");
            return;
        }
        foreach(var p in order.Product)
        {
            Console.WriteLine($"[ID: {p.Id}] Name: {p.Name,-20} | Price: {p.Price,8:F2} EGP | Stock: {p.Stock}");
        }
    }
    public static void PrintALLOredrs(OrderStore order)
    {
         Console.WriteLine("=== ALL ORDERS ===");
        if (order.Order.Count == 0)
        {
            Console.WriteLine("No Order found.");
            return;
        }
        foreach(var o in order.Order)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Order #{o.Id} | Date: {o.Date} | Customer: {o.Customer.Name} | Paid: {(o.IsPaid ? "Yes" : "No")}");
            foreach(var line in o.Orderline)
            {
                Console.WriteLine($"- {line.Product.Name} x{line.Quinty} @ {line.Product.Price:F2} = {line.TotalLine:F2} EGP");
            }
            Console.WriteLine($"Total Order Amount: {o.CalculateTotal():F2} EGP");
        }
        
    }

    public static void SeedDate(OrderStore store)
    {
        store.AddCustomer(new Customer(1,"Gaser","Gaser@gmail.com","Borsaid",true));
        store.AddCustomer(new Customer(2,"Osama","Osama@gmail.com","Bahr",true));
        store.AddCustomer(new Customer(3,"Mohamed","Mohamed@gmail.com","Bahr",true));

        store.AddProduct(new Product(1,"MacBook",2000,20));
        store.AddProduct(new Product(2,"Tap",1000,20));
        store.AddProduct(new Product(3,"IPhone",2000,20));

     var order1 = store.CreateOrder(1,1,"2026-9-21");
        if (order1 != null)
        {
            order1.AddLine(store.FindProductById(1),1);
            order1.AddLine(store.FindProductById(3),2);
            order1.MarkPaid();
        }

     var order2 = store.CreateOrder(2,1,"2026-9-21");
        if (order1 != null)
        {
            order1.AddLine(store.FindProductById(2),1); 
        }
    }


    public static void AddCustomer(OrderStore store)
    {
        Console.WriteLine("Add New Customer");
        Console.WriteLine("Eneter the Id");
        int Id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Name: ");
        string name = Console.ReadLine() ?? null! ;

        Console.Write("Enter Email: ");
        string email = Console.ReadLine() ?? null!;

        Console.Write("Enter City: ");
        string city = Console.ReadLine() ?? null!;
        Console.Write("Is VIP? (y/n): ");
        bool IsVip = Console.ReadLine()!.Trim().ToLower() == "y";

        Customer cus = new Customer(Id, name, email, city, IsVip);
       bool isadded= store.AddCustomer(cus);
        if (isadded)
            Console.WriteLine("Added Successfully");
        else
        Console.WriteLine(" Not Added");
    }

    public static void AddProduct(OrderStore store)
    {
        Console.WriteLine("=== ADD NEW PRODUCT ===");
        Console.Write("Enter Product ID: ");
        int id = int.Parse(Console.ReadLine()!);

        Console.Write("Enter Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Enter Price: ");
        double price = double.Parse(Console.ReadLine()!);

        Console.Write("Enter Stock: ");
        int stock = int.Parse(Console.ReadLine()!);

        Product product = new Product(id, name, price, stock);
        if (store.AddProduct(product))
            Console.WriteLine("\nProduct added successfully!");
        else
            Console.WriteLine("\nError: Product ID already exists!");
    }

    public static void CreateORDRER(OrderStore store)
    {
        Console.WriteLine("CREATE ORDRER");

        Console.WriteLine("Enter Order ID");
        int Id = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Customer ID");
        int CustomerId= int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Date");
        string Date= Console.ReadLine()!;

        var order = store.CreateOrder(Id, CustomerId, Date);
        if(order== null)
        {
            Console.WriteLine("\nError: Either Order ID already exists OR Customer ID does not exist.");
            return;
        }
        bool addingProducts = true;
        while (addingProducts)
        {
            Console.WriteLine("Enter Id Product");
            int IdProduct = int.Parse(Console.ReadLine()!);
            var product = store.FindProductById(IdProduct);
            if (product == null)
            {
                Console.WriteLine("Product not found!");
            }
            else
            {
                Console.WriteLine($"Enter Quinty For {product.Name}");
                int Quinty = int.Parse(Console.ReadLine()!);
                order.AddLine(product, Quinty);
                Console.WriteLine("Product added to order.");
            }
            Console.WriteLine("Do You Add New Product y/n");
            addingProducts = Console.ReadLine()!.Trim().ToLower() == "y";
        }
        Console.Write("Mark as paid now? (y/n): ");
        if (Console.ReadLine()!.Trim().ToLower() == "y")
        {
            order.MarkPaid();
        }
        Console.WriteLine("\nOrder created successfully!");
    }
    
    }
  

