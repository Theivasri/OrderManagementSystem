using OrderManagement.Model;
using OrderManagement.View;
using OrderManagement.Repository;
namespace OrderManagement.Controller;

public class ProductManager
{
    public static int SelectedProductId{ get; set; }

    /// <summary>
    /// Displays the main menu.
    /// </summary>
    public static void HandleMainMenu()
    {
        List<MenuHandler> mainmenuHandler = new List<MenuHandler>()
        {
            new MenuHandler( "Add new Product", AddNewProduct ),
            new MenuHandler( "View Products", OutputManager.ViewProduct),
            new MenuHandler( "Edit Product", HandleEditMenu),
            new MenuHandler( "Exit", InputManager.ExitApplication )
        };
        HandleMainMenuActions("Main Menu", mainmenuHandler);
    }

    /// <summary>
    /// Displays the menu options.
    /// </summary>
    /// <param name="menutitle">User's choice of menu option.</param>
    /// <param name="handler">Actions corresponding to the user choice.</param>
    public static void HandleMainMenuActions(string menutitle, List<MenuHandler> handler)
    {
        while (true)
        {
            Console.WriteLine($"\n===== {menutitle} =====\n");
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
                InputManager.ExitApplication();
                return;
            }
            else
            {
                handler[choice - 1].Function.Invoke();
            }
        }
    }

    /// <summary>
    /// Display Edit Menu.
    /// </summary>
    public static void HandleEditMenu()
    {
        List<EditMenuHandler> editmenuHandlers = new List<EditMenuHandler>(){
            new EditMenuHandler("Product Id", InputManager.GetEditId),
            new EditMenuHandler("Main Menu", () => { })
        };
        HandleEditMenuActions(" Menu ", editmenuHandlers);
    }

    /// <summary>
    /// Handles the edit options.
    /// </summary>
    /// <param name="editTitle">User's choice of edit option.</param>
    /// <param name="editHandler">Edit actions corresponding to the user choice.</param>
    public static void HandleEditMenuActions(string editTitle, List<EditMenuHandler> editHandler)
    {
        if (ProductDatabase._productList.Count() == 0)
        {
            Console.WriteLine("No products to edit.");
            return;
        }
        OutputManager.ViewProduct();
        while (true)
        {
            Console.WriteLine($"\n====== {editTitle} ======\n");
            OutputManager.DisplayEditMenuDetails(editHandler);

            Console.Write("\n[Menu] Enter your choice: ");
            string userInput = Console.ReadLine();
            bool isValidChoice = int.TryParse(userInput, out int choice);

            if (!isValidChoice)
            {
                Console.WriteLine("[Error] Invalid Choice.");
            }
            else if (choice < 1 || choice > editHandler.Count)
            {
                Console.WriteLine($"[Error] Choice should be between 1 to {editHandler.Count}");
            }
            else if (choice == editHandler.Count)
            {
                HandleMainMenu();
            }
            else
            {
                editHandler[choice - 1].Function.Invoke();
            }
        }
    }

    /// <summary>
    /// Handles the edit sub menu.
    /// </summary>
    public static void HandleSubMenu()
    {
        List<EditSubMenuHandler> editSubMenuHandlers = new List<EditSubMenuHandler>()
        {
            new EditSubMenuHandler( "Edit Name", InputManager.EditName),
            new EditSubMenuHandler( "Edit Price", InputManager.EditPrice),
            new EditSubMenuHandler( "Edit Quantity", InputManager.EditQuantity),
            new EditSubMenuHandler( "Main Menu", () => { })
        };
        HandleEditSubMenuActions("Sub Menu", editSubMenuHandlers);
    }

    /// <summary>
    /// Handles the edit sub menu options.
    /// </summary>
    /// <param name="menutitle">User's choice of edit option.</param>
    /// <param name="subMenuHandler">Edit actions corresponding to the user choice.</param>
    public static void HandleEditSubMenuActions(string menutitle, List<EditSubMenuHandler> subMenuHandler)
    {
        while (true)
        {
            Console.WriteLine($"\n ===== {menutitle} ======\n");
            OutputManager.DisplayEditSubMenuDetails(subMenuHandler);

            Console.Write("\n[Menu] Enter your choice: ");
            string userInput = Console.ReadLine();
            bool isValidChoice = int.TryParse(userInput, out int choice);

            if (!isValidChoice)
            {
                Console.WriteLine("[Error] Invalid Choice.");
            }
            else if (choice < 1 || choice > subMenuHandler.Count)
            {
                Console.WriteLine($"[Error] Choice should be between 1 to {subMenuHandler.Count}");
            }
            else if (choice == subMenuHandler.Count)
            {
                HandleMainMenu();
            }
            else
            {
                subMenuHandler[choice - 1].Function.Invoke();
            }
        }
    }

    /// <summary>
    /// Adds a new product.
    /// </summary>
    private static void AddNewProduct()
    {
        Console.WriteLine("\n====== Add New Product ======\n");
        string name = InputManager.GetProductName();
        decimal price = InputManager.GetProductPrice();
        int quantity = InputManager.GetProductQuantity();
        ProductDatabase.AddProduct(new Product(name, price, quantity));
        Console.WriteLine("\n[Success] New product is added successfully!");
        Console.WriteLine("\nPress Any Key to Continue...");
        Console.ReadKey();
    }
}
