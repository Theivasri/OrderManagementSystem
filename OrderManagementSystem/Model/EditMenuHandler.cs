public class EditMenuHandler
{
    /// <summary>
    /// Getter and setter for edit menu option by user.
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Getter and setter for edit menu action by user.
    /// </summary>
    public Action Function { get; set; }

    /// <summary>
    /// Initializes the instances for EditMenuHandler class.
    /// </summary>
    /// <param name="title">Title of edit menu option</param>
    /// <param name="function">Action for user's edit menu option.</param>
    public EditMenuHandler(string title, Action function)
    {
        Title = title;
        Function = function;
    }
}