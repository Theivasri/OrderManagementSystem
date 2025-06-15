public class MenuHandler
{
    /// <summary>
    /// Getter and setter for user menu title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Getter and setter for user action.
    /// </summary>
    public Action Function { get; set; }

    /// <summary>
    /// Initializes the instance of the MenuHandler class.
    /// </summary>
    /// <param name="title">Title of menu option.</param>
    /// <param name="function">Action for user's menu option.</param>
    public MenuHandler(string title, Action function)
    {
        Title = title;
        Function = function;
    }

}