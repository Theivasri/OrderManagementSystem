namespace OrderManagement.Model;

public class Product
{
    /// <summary>
    /// Getter and setter for Products's Name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Getter and setter for Product's Price.
    /// </summary>
    public decimal Price { get; set; }
    /// <summary>
    /// Getter and setter for Product's Quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Initializes the instance of Product.
    /// </summary>
    /// <param name="name">Name of the Product.</param>
    /// <param name="price">Price of the Product.</param>
    /// <param name="quantity">Quantity of the Product.</param>
    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}