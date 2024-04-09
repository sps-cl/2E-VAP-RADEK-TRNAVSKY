using System;
using System.Text.RegularExpressions;

class ComplexNumber
{
    // Getter a setter pro reálnou část komplexního čísla
    public double Real { get; set; }

    // Getter a setter pro imaginární část komplexního čísla
    public double Imaginary { get; set; }

    // Konstruktor pro vytvoření komplexního čísla ze dvou reálných čísel
    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    // Konstruktor pro vytvoření komplexního čísla z řetězce ve formátu a + bi
    public ComplexNumber(string input)
    {
        // Použijeme regulární výraz pro rozpoznání formátu a + bi
        Regex regex = new Regex(@"^\s*(?<real>[-+]?\d*\.?\d+)\s*[-+]\s*(?<imaginary>[-+]?\d*\.?\d*)\s*i\s*$");
        Match match = regex.Match(input);

        // Pokud formát neodpovídá očekávanému, vyhodíme výjimku
        if (!match.Success)
        {
            throw new ArgumentException("Neplatný formát komplexního čísla.");
        }

        // Načteme reálnou a imaginární část ze vstupního řetězce
        Real = double.Parse(match.Groups["real"].Value);
        Imaginary = double.Parse(match.Groups["imaginary"].Value);
    }

    // Metoda pro sčítání komplexních čísel
    public ComplexNumber Add(ComplexNumber other)
    {
        return new ComplexNumber(Real + other.Real, Imaginary + other.Imaginary);
    }

    // Metoda pro odčítání komplexních čísel
    public ComplexNumber Subtract(ComplexNumber other)
    {
        return new ComplexNumber(Real - other.Real, Imaginary - other.Imaginary);
    }

    // Metoda pro násobení komplexních čísel
    public ComplexNumber Multiply(ComplexNumber other)
    {
        double newReal = Real * other.Real - Imaginary * other.Imaginary;
        double newImaginary = Imaginary * other.Real + Real * other.Imaginary;
        return new ComplexNumber(newReal, newImaginary);
    }

    // Metoda pro dělení komplexních čísel
    public ComplexNumber Divide(ComplexNumber other)
    {
        double denominator = other.Real * other.Real + other.Imaginary * other.Imaginary;
        double newReal = (Real * other.Real + Imaginary * other.Imaginary) / denominator;
        double newImaginary = (Imaginary * other.Real - Real * other.Imaginary) / denominator;
        return new ComplexNumber(newReal, newImaginary);
    }

    // Převede komplexní číslo na řetězec ve formátu a + bi
    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Vstup od uživatele pro první komplexní číslo
        Console.WriteLine("Zadejte prvni komplexni cislo ve formatu a + bi:");
        string input1 = Console.ReadLine();
        ComplexNumber number1;
        try
        {
            number1 = new ComplexNumber(input1);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        // Vstup od uživatele pro druhé komplexní číslo
        Console.WriteLine("Zadejte druhe komplexni cislo ve formatu a + bi:");
        string input2 = Console.ReadLine();
        ComplexNumber number2;
        try
        {
            number2 = new ComplexNumber(input2);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        // Vypočítání součtu, rozdílu, součinu a podílu komplexních čísel
        ComplexNumber sum = number1.Add(number2);
        ComplexNumber difference = number1.Subtract(number2);
        ComplexNumber product = number1.Multiply(number2);
        ComplexNumber quotient = number1.Divide(number2);

        // Výstup vypočtených hodnot
        Console.WriteLine($"Soucet: {sum}");
        Console.WriteLine($"Rozdil: {difference}");
        Console.WriteLine($"Soucin: {product}");
        Console.WriteLine($"Podil: {quotient}");
        Console.ReadLine();
    }
}
