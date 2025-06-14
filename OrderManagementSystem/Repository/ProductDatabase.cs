namespace OrderManagement.Repository;
using OrderManagement.Model;

public class ProductDatabase
{
    static List<Product> _productList = new List<Product>();
    public static void AddProduct(Product _newProduct)
    {
        _productList.Add(_newProduct);
    }
    public static List<Product> DisplayProduct()
    {
        return _productList;
    }
}