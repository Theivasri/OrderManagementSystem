using OrderManagement.Model;
using OrderManagement.View;
using OrderManagement.Repository;


namespace OrderManagement.Controller;

public class ProductManager
{
    /// <summary>
    /// Displays the main menu.
    /// </summary>
    public void HandleMainMenu()
    {
        List<MenuHandler> mainmenuHandler = new List<MenuHandler>()
        {
            new MenuHandler( "Add new Product", AddNewProduct ),
            new MenuHandler( "View Products", OutputManager.ViewProduct),
            new MenuHandler( "Exit", ExitApplication )
        };

        HandleMainMenuActions("Main Menu", mainmenuHandler);
    }
    /// <summary>
    /// Displays menu options.
    /// </summary>
    /// <param name="menutitle">User's choice of action.</param>
    /// <param name="handler">Actions corresponding to the user choice.</param>
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

    /// <summary>
    /// Adds a new product.
    /// </summary>
    private void AddNewProduct()
    {
        Console.WriteLine("\n====== Add New Product ======\n");
        string name = InputManager.GetProductName();
        decimal price = InputManager.GetProductPrice();
        int quantity = InputManager.GetProductQuantity();
        ProductDatabase.AddProduct(new Product(name, price, quantity));
        Console.WriteLine("\n[Success] New product is added successfully!");
    }

    /// <summary>
    /// Exits the application when the user wants to close it.
    /// </summary>
    private void ExitApplication()
    {
        while (true)
        {
            Console.Write("\nAre you sure you want to exit? (Y/N): ");
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
