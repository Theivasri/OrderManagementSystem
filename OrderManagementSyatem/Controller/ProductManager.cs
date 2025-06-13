using OrderManagement.Model;
using OrderManagement.Repositary;
using OrderManagement.View;


namespace OrderManagement.Controller;

public class ProductManager
{
    public void HandleMainMenu()
    {
        Console.WriteLine("===== Main Menu =====");
        List<MenuHandler> mainmenuHandler = new List<MenuHandler>()
        {
            new MenuHandler( "Add a new Product", AddNewProduct ),
            new MenuHandler( "View Products", ViewProduct)
        };
    }

    private void ViewProduct()
    {
        List<Product> products = ProductDatabase.DisplayProduct();
        foreach (var item in products)
        {
            Console.WriteLine("Product id : " + item.ID);
            Console.WriteLine("Product Name : " + item.Name);
        }
    }
    private void AddNewProduct()
    {
        int id = InputManager.GetProductId();
        string name = InputManager.GetProductName();
        ProductDatabase.AddProduct(new Product(id, name));
    }
}
