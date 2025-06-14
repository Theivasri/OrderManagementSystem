using OrderManagement.Repository;
using OrderManagement.Controller;
using OrderManagement.Model;
namespace OrderManagement.View;

public class OutputManager
{
    /// <summary>
    /// Displays the Main Menu.
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
    /// Displays the table of available products.
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
        Console.WriteLine("\n");
    }

}