using System;
using System.Collections.Generic;

class CityDatabase
{
    private Dictionary<string, string> cities = new Dictionary<string, string>();

    public void PridejMesto(string mesto, string pocetObyvatel)
    {
        cities[mesto] = pocetObyvatel;
    }

    public string Obyvatele(string mesto)
    {
        if (cities.ContainsKey(mesto))
            return cities[mesto];
        else
            return "Nezname mesto";
    }

    public string PosledniMesto()
    {
        if (cities.Count == 0)
            return "V aplikaci nejsou zadna mesta.";

        string posledniMesto = "";
        string posledniPocetObyvatel = "";
        foreach (var pair in cities)
        {
            posledniMesto = pair.Key;
            posledniPocetObyvatel = pair.Value;
        }
        return $"Posledni pridane mesto: {posledniMesto}, pocet obyvatel: {posledniPocetObyvatel}";
    }

    public string VypisMesta()
    {
        if (cities.Count == 0)
            return "V aplikaci nejsou zadna mesta.";

        string vypis = "";
        foreach (var pair in cities)
        {
            vypis += $"{pair.Key}: {pair.Value}\n";
        }
        return vypis;
    }
}

class Program
{
    static void Main(string[] args)
    {
        CityDatabase cityDb = new CityDatabase();

        while (true)
        {
            Console.Write("Zadejte prikaz: ");
            string command = Console.ReadLine();

            if (command.ToLower() == "konec")
                break;

            string result = ParseCommand(command, cityDb);
            Console.WriteLine(result);
        }
    }

    static string ParseCommand(string command, CityDatabase cityDb)
    {
        string[] parts = command.Split(' ');
        if (parts.Length < 2)
            return "Neznamy prikaz";

        string mesto = "";
        string pocetObyvatel = "";

        switch (parts[0].ToLower())
        {
            case "pridej":
                if (parts.Length < 3)
                    return "Chybi nazev mesta nebo pocet obyvatel.";

                mesto = string.Join(" ", parts, 1, parts.Length - 2);
                pocetObyvatel = parts[parts.Length - 1];
                cityDb.PridejMesto(mesto, pocetObyvatel);
                return $"Mesto {mesto} s poctem obyvatel {pocetObyvatel} bylo pridano.";

            case "obyvatele":
                if (parts.Length < 2)
                    return "Chybi nazev mesta.";

                mesto = string.Join(" ", parts, 1, parts.Length - 1);
                return cityDb.Obyvatele(mesto);

            case "posledni":
                return cityDb.PosledniMesto();

            case "mesta":
                return cityDb.VypisMesta();

            default:
                return "Neznamy prikaz";
        }
    }
}
