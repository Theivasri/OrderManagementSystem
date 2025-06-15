using OrderManagement.Controller;

public class Program
{
    /// <summary>
    /// Initializes and start the new product.
    /// </summary>
    public static void Main()
    {
        ProductManager productManager = new ProductManager();
        ProductManager.HandleMainMenu();
    }
}