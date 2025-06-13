namespace OrderManagement.Model;

public class Product
{
    /// <summary>
    /// Getter and setter for Product's ID
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// Getter and setter for Products's Name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Initializes the new instances of Products
    /// </summary>
    /// <param name="id">Id of the Product</param>
    /// <param name="name">Name of the Product</param>
    public Product(int id, string name)
    {
        ID = id;
        Name = name;
    }
}