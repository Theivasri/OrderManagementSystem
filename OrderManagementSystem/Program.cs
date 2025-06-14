using OrderManagement.Controller;
using OrderManagement.Model;
using OrderManagement.View;

public class Program
{
    /// <summary>
    /// Initializes and start the new product.
    /// </summary>
    public static void Main()
    {
        ProductManager productManager = new ProductManager();
        productManager.HandleMainMenu();
    }
}