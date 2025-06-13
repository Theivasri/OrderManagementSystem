using OrderManagement.Controller;
using OrderManagement.Model;
namespace OrderManagement.View;

public class InputManager
{
    public static int GetProductId()
    {
        Console.WriteLine("Enter Product Id : ");
        int userInput = Convert.ToInt32(Console.ReadLine());
        return userInput;
    }
    public static string GetProductName()
    {
        Console.WriteLine("Enter Product Name : ");
        string userInput = Console.ReadLine();
        return userInput;
    }
}