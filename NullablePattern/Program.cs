 
using NullPattern.Greeter;

namespace NullPattern;

public class Program
{
    public static void Main()
    {
        // Convert the enum into an generic enumeration
        // and add null at the end
        static IEnumerable<LanguageGreet?> GetLanguages() => 
            Enum.GetValues(typeof(LanguageGreet))
                .Cast<LanguageGreet?>()
                .Append(null)
                ;

        IGreeting lng;
        // Process the enumeration
        GetLanguages().ToList().ForEach(item => {
            lng = GetGreeter(item);
            Console.WriteLine(lng.Greet());
        });
    }
    /// <summary>
    /// Retrieve a Language from LangugeGreet enum type
    /// </summary>
    /// <param name="greeter">LanguageGreet</param>
    /// <returns>IGreeting</returns>
    private static IGreeting GetGreeter(LanguageGreet? greeter = null) =>
        greeter switch
        {
            LanguageGreet.En => new English(),
            LanguageGreet.Sp => new Spanish(),
            LanguageGreet.Fr => new French(),
            _ => Language.Null,
        };
}
