public class MenuHandler
{
    public string Title { get; set; }
    public Action Function { get; set; }

    public MenuHandler(string title, Action function)
    {
        Title = title;
        Function = function;
    }

}