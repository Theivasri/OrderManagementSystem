public class EditSubMenuHandler
{
    /// <summary>
    /// Getter and setter for user's edit sub menu option.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Getter and setter for user's edit sub menu action.
    /// </summary>
    public Action Function { get; set; }

    /// <summary>
    /// Initializes the instances of EditSubMenuHandler class.
    /// </summary>
    /// <param name="title">Ttitle of sub menu option</param>
    /// <param name="function">Action of user's edit sub menu option</param>
    public EditSubMenuHandler(string title, Action function)
    {
        Title = title;
        Function = function;
    }
}