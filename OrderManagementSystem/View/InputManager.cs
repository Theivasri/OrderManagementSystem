using OrderManagement.Controller;
using OrderManagement.Model;
using OrderManagement.Repository;
namespace OrderManagement.View;

public class InputManager
{
    /// <summary>
    /// Get product from user.
    /// </summary>
    /// <returns>Returns the validated product.</returns>
    public static string GetProductName()
    {
        while (true)
        {
            Console.Write("Enter Name : ");
            string userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("[Error] Input cannot be empty.");
            }
            else if (isProductExists(userInput))
            {
                Console.WriteLine("[Error] Product already exist.");
            }
            else if (userInput.Any(char.IsDigit))
            {
                Console.WriteLine("[Error] Name must contain only letters and spaces.");
            }
            else
            {
                return userInput;
            }
        }
    }

    /// <summary>
    /// Get price of product.
    /// </summary>
    /// <returns>Returns the validated price.</returns>
    public static decimal GetProductPrice()
    {
        while (true)
        {
            Console.Write("Enter Price : ");
            string userInput = Console.ReadLine();
            bool isDecimal = decimal.TryParse(userInput, out decimal price);

            if (!isDecimal)
            {
                Console.WriteLine("[Error] Invalid Price");
            }
            else if (price < 0)
            {
                Console.WriteLine("[Error] Price must be an Positive value.");
            }
            else
            {
                return price;
            }
        }
    }

    /// <summary>
    /// Get the number of product needed.
    /// </summary>
    /// <returns>Returns the quantity of product.</returns>
    public static int GetProductQuantity()
    {
        while (true)
        {
            Console.Write("Enter Quantity : ");
            string userInput = Console.ReadLine();
            bool isInteger = int.TryParse(userInput, out int value);
            if (!isInteger)
            {
                Console.WriteLine("[Error] Quantity must be an Integer.");
            }
            else if (value < 0)
            {
                Console.WriteLine("[Error] Quantity must be an positive value.");
            }
            else
            {
                return value;
            }
        }
    }

    /// <summary>
    /// Check whether the product already exist or not
    /// </summary>
    /// <param name="userInput">The entered product name by the user.</param>
    /// <returns></returns>
    private static bool isProductExists(string userInput)
    {
        List<Product> existingProduct = ProductDatabase.DisplayProduct();
        foreach (Product i in existingProduct)
        {
            if (i.Name.Trim().ToLower() == userInput.Trim().ToLower())
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Get product id to edit
    /// </summary>
    public static void GetEditId()
    {
        while (true)
        {
            Console.Write("Enter Id: ");
            string userInput = Console.ReadLine();
            bool isInteger = int.TryParse(userInput, out int choice);

            if (!isInteger)
            {
                Console.WriteLine("[Error] Invalid Choice.");
            }
            else if (choice < 1 || choice > ProductDatabase._productList.Count)
            {
                Console.WriteLine($"[Error] Choice should be between 1 to {ProductDatabase._productList.Count}");
            }
            else
            {
                OutputManager.DetailsBeforeAndAfterEdit(choice);
                ProductManager.SelectedProductId = choice;
                ProductManager.HandleSubMenu();
                return;
            }
        }
    }

    /// <summary>
    /// Edit the product name
    /// </summary>
    public static void EditName()
    {
        int choice = ProductManager.SelectedProductId;
        Console.WriteLine("To cancel the operation press Enter key");
        Console.Write("Enter new product : ");
        string userInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(userInput))
        {
            ProductManager.HandleMainMenu();
        }
        else if (isProductExists(userInput))
        {
            Console.WriteLine("[Error] Product already exist.");
        }
        else if (userInput.Any(char.IsDigit))
        {
            Console.WriteLine("[Error] Name must contain only letters and spaces.");
        }
        else
        {
            ProductDatabase._productList[choice - 1].Name = userInput;
            Console.WriteLine("[Success] Details edited successfully!");
            OutputManager.DetailsBeforeAndAfterEdit(choice);
        }
    }

    /// <summary>
    /// Edit the product's price.
    /// </summary>
    public static void EditPrice()
    {
        int choice = ProductManager.SelectedProductId;
        Console.Write("Enter new price : ");
        string userInput = Console.ReadLine();
        bool isInteger = decimal.TryParse(userInput, out decimal price);
        if (!isInteger)
        {
            Console.WriteLine("[Error] Invalid user input.");
        }
        else if (price < 1)
        {
            ProductManager.HandleMainMenu();
        }
        else
        {
            ProductDatabase._productList[choice - 1].Price = price;
            Console.WriteLine("[Success] Details edited successfully!");
            OutputManager.DetailsBeforeAndAfterEdit(choice);
        }
    }

    /// <summary>
    /// Edit the product's quantity.
    /// </summary>
    public static void EditQuantity()
    {
        int choice = ProductManager.SelectedProductId;
        Console.Write("Enter new quantity : ");
        string userInput = Console.ReadLine();
        bool isInteger = int.TryParse(userInput, out int quantity);
        if (!isInteger)
        {
            Console.WriteLine("[Error] Invalid user input.");
        }
        else if (quantity < 1)
        {
            ProductManager.HandleMainMenu();
        }
        else
        {
            ProductDatabase._productList[choice - 1].Quantity = quantity;
            Console.WriteLine("[Success] Details edited successfully!");
            OutputManager.DetailsBeforeAndAfterEdit(choice);
        }
    }

    /// <summary>
    /// Exit the application.
    /// </summary>
    public static void ExitApplication()
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
                ProductManager.HandleMainMenu();
            }
            else
            {
                Console.WriteLine("[Error] Invalid choice. Please enter 'Y' or 'N'.");
            }
        }

    }
}