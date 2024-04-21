 
namespace NullPattern.Greeter;

public abstract class Language : IGreeting
{
    /// <summary>
    /// Static safe null property 
    /// </summary>
    public static readonly IGreeting Null = new NoLanguage();
    private Language()  {}
    /// <summary>
    /// Class implementation of the Null Pattern
    /// </summary>
    private class NoLanguage : IGreeting
    {
        string IGreeting.Greet() => "???";
    }
    public abstract string Greet();

}
