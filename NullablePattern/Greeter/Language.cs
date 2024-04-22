 
namespace NullPattern.Greeter;

public abstract class Language : IGreeter
{
    /// <summary>
    /// Static safe null property 
    /// </summary>
    public static readonly IGreeter Null = new NoLanguage();
    private Language()  {}
    /// <summary>
    /// Class implementation of the Null Pattern
    /// </summary>
    private class NoLanguage : IGreeter
    {
        string IGreeter.Greet() => "???";
    }
    public abstract string Greet();

}
