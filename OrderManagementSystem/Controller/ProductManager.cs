using OrderManagement.Model;
using OrderManagement.View;
using OrderManagement.Repository;


namespace OrderManagement.Controller;

public class ProductManager
{
    public void HandleMainMenu()
    {
        List<MenuHandler> mainmenuHandler = new List<MenuHandler>()
        {
            new MenuHandler( "Add new Product", AddNewProduct ),
            new MenuHandler( "View Products", ViewProduct),
            new MenuHandler( "Exit", ExitApplication )
        };

        HandleMainMenuActions("Main Menu", mainmenuHandler);
    }
    public void HandleMainMenuActions(string menutitle, List<MenuHandler> handler)
    {
        while (true)
        {
            Console.WriteLine($"\n===== {menutitle} =====");
            OutputManager.DisplayMenuDetails(handler);

            Console.Write("\n[Menu] Enter your choice: ");
            string userInput = Console.ReadLine();
            bool isValidChoice = int.TryParse(userInput, out int choice);

            if (!isValidChoice)
            {
                Console.WriteLine("[Error] Invalid Choice.");
            }
            else if (choice < 1 || choice > handler.Count)
            {
                Console.WriteLine($"[Error] Choice should be between 1 to {handler.Count}");
            }
            else if (choice == handler.Count)
            {
                ExitApplication();
                return;
            }
            else
            {
                handler[choice - 1].Function.Invoke();
            }
            Console.WriteLine("Press Any Key to Continue..");
            Console.ReadKey();
        }
    }

    private void ViewProduct()
    {
        List<Product> products = ProductDatabase.DisplayProduct();
        if (products.Count == 0)
        {
            Console.WriteLine("No products exist in inventory.");
            return;
        }
        Console.WriteLine("\n====== Products ======\n");
        Console.WriteLine(" {0,-5} | {1,-20} | {2,-10} | {3,-10} ", "Id", "Product Name", "Price", "Quantity");
        Console.WriteLine("--------------------------------------------------");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine("{0,-5} | {1,-20} | {2,-10} | {3,-10}", i + 1, products[i].Name, products[i].Price, products[i].Quantity);
        }
    }

    private void AddNewProduct()
    {
        string name = InputManager.GetProductName();
        decimal price = InputManager.GetProductPrice();
        int quantity = InputManager.GetProductQuantity();
        ProductDatabase.AddProduct(new Product(name, price, quantity));
        Console.WriteLine("\n[Success] New product is added successfully!");
    }

    private void ExitApplication()
    {
        while (true)
        {
            Console.WriteLine("\nAre you sure you want to exit? (Y/N):");
            string userInput = Console.ReadLine();
            if (userInput == "Y" || userInput == "y")
            {
                Console.WriteLine("Exiting the application...");
                Environment.Exit(0);
            }
            else if (userInput == "N" || userInput == "n")
            {
                HandleMainMenu();
            }
            else
            {
                Console.WriteLine("[Error] Invalid choice. Please enter 'Y' or 'N'.");
            }
        }

    }
}
