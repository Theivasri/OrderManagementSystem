public class MenuHandler
{
    private string v1;
    private object v2;

    public string Title { get; set; }
    public Action Function { get; set; }

    public MenuHandler(string title, Action function)
    {
        title = Title;
        function = Function;
    }

}