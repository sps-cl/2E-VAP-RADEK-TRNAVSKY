using System;
using System.Collections.Generic;

class TextEditor
{
    private List<string> words;
    private int currentIndex;

    public TextEditor()
    {
        words = new List<string>();
        currentIndex = -1;
    }

    public void AddWord(string word)
    {
        words.Add(word);
        currentIndex = words.Count - 1;
        Console.WriteLine(word);
    }

    public void ShowPreviousWord()
    {
        if (currentIndex > 0)
            currentIndex--;
        Console.WriteLine(words[currentIndex]);
    }

    public void ShowNextWord()
    {
        if (currentIndex < words.Count - 1)
            currentIndex++;
        Console.WriteLine(words[currentIndex]);
    }
}

class Program
{
    static void Main(string[] args)
    {
        TextEditor editor = new TextEditor();

        while (true)
        {
            string command = Console.ReadLine().Trim();

            if (command.StartsWith("Pridat:".ToLower()))
            {
                string word = command.Split(':')[1];
                editor.AddWord(word);
            }
            else if (command == "Zpet".ToLower())
            {
                editor.ShowPreviousWord();
            }
            else if (command == "Vpred".ToLower())
            {
                editor.ShowNextWord();
            }
            else
            {
                Console.WriteLine("Neznamy prikaz.");
            }
        }
    }
}



