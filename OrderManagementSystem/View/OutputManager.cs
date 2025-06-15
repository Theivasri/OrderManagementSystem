using OrderManagement.Repository;
using OrderManagement.Model;
namespace OrderManagement.View;

public class OutputManager
{
    /// <summary>
    /// Display the Main Menu.
    /// </summary>
    /// <param name="mainmenuHandler">List of Main Menu actions</param>
    public static void DisplayMenuDetails(List<MenuHandler> mainmenuHandler)
    {
        for (int i = 0; i < mainmenuHandler.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {mainmenuHandler[i].Title}");
        }
    }

    /// <summary>
    /// Display edit menu.
    /// </summary>
    /// <param name="editnenuHandler">List of edit menu actions.</param>
    public static void DisplayEditMenuDetails(List<EditMenuHandler> editnenuHandler)
    {
        for (int i = 0; i < editnenuHandler.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {editnenuHandler[i].Title}");
        }
    }

    /// <summary>
    /// Display Edit Sub-Menu
    /// </summary>
    /// <param name="editSubMenuHandlers">List of edit sub menu actions.</param>
    public static void DisplayEditSubMenuDetails(List<EditSubMenuHandler> editSubMenuHandlers)
    {
        for (int i = 0; i < editSubMenuHandlers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {editSubMenuHandlers[i].Title}");
        }
    }

    /// <summary>
    /// Display the table of available products.
    /// </summary>
    public static void ViewProduct()
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
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }

    /// <summary>
    /// Details aefore and after edit operation
    /// </summary>
    /// <param name="choice">Id of the product</param>
    public static void DetailsBeforeAndAfterEdit(int choice)
    {
        List<Product> products = ProductDatabase.DisplayProduct();
        Console.WriteLine("\n====== Details ======\n");
        Console.WriteLine($"Id       : {choice}");
        Console.WriteLine($"Name     : {products[choice - 1].Name}");
        Console.WriteLine($"Price    : {products[choice - 1].Price}");
        Console.WriteLine($"Quantity : {products[choice - 1].Quantity}");
    }
}