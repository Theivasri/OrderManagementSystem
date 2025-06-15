namespace OrderManagement.Repository;
using OrderManagement.Model;

public class ProductDatabase
{
    /// <summary>
    /// Stores all products.
    /// </summary>
    public static List<Product> _productList = new List<Product>();

    /// <summary>
    /// Add a new product to the list.
    /// </summary>
    /// <param name="_newProduct">The product to be added</param>
    public static void AddProduct(Product _newProduct)
    {
        _productList.Add(_newProduct);
    }

    /// <summary>
    /// Display products.
    /// </summary>
    /// <returns></returns>
    public static List<Product> DisplayProduct()
    {
        return _productList;
    }
}