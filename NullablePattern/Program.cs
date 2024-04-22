 
using NullPattern.Greeter;

using System.Runtime.CompilerServices;

namespace NullPattern;

public class Program
{
    /// <summary>
    /// Entry Point
    /// </summary>
    public static void Main()
    {
        Run(GetLanguages, GetGreeter);    
    }
    /// <summary>
    /// Process the Language Enum Type
    /// </summary>
    /// <param name="lngFunc">Function delegate</param>
    /// <param name="greeter">Function to retrieve an IGreeter</param>
    private static void Run(Func<IEnumerable<LanguageGreet?>> lngFunc, Func<LanguageGreet?, IGreeter> greeter)
    {
        IGreeter lng;

        lngFunc().ToList()
            .ForEach(item =>
        {
            lng = greeter(item);
            Console.WriteLine(lng.Greet());
        });
    }

    /// <summary>
    /// Convert the enum into an generic enumeration
    /// and add null at the end
    /// </summary>
    /// <returns></returns>
    private static IEnumerable<LanguageGreet?> GetLanguages() =>
    Enum.GetValues(typeof(LanguageGreet))
        .Cast<LanguageGreet?>()
        .Append(null)
        ;

    /// <summary>
    /// Retrieve a Language from LangugeGreet enum type
    /// </summary>
    /// <param name="greeter">LanguageGreet</param>
    /// <returns>IGreeting</returns>
    private static IGreeter GetGreeter(LanguageGreet? greeter = null) =>
        greeter switch
        {
            LanguageGreet.En => new English(),
            LanguageGreet.Sp => new Spanish(),
            LanguageGreet.Fr => new French(),
            _ => Language.Null,
        };
}
