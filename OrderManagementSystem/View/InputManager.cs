using System.Data;
using OrderManagement.Controller;
using OrderManagement.Model;
using OrderManagement.Repository;
namespace OrderManagement.View;

public class InputManager
{
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

    private static bool isProductExists(string username)
    {
        List<Product> existingProduct = ProductDatabase.DisplayProduct();
        foreach (Product i in existingProduct)
        {
            if (i.Name.Trim().ToLower() == username.Trim().ToLower())
            {
                return true;
            }
        }
        return false;
    }
}