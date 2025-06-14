using OrderManagement.Controller;
using OrderManagement.Model;
namespace OrderManagement.View;
public class OutputManager
{
    public static void DisplayMenuDetails(List<MenuHandler> mainmenuHandler)
{
    for (int i = 0; i < mainmenuHandler.Count; i++)
    {
            Console.WriteLine($"{i + 1}. {mainmenuHandler[i].Title}");
    }
}

}