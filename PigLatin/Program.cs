// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using System.Globalization;

Console.WriteLine("Welcome to the Pig Latin Translator!");
bool IsValid = true;
while (IsValid)
{
    Console.WriteLine("Enter a line to be translated:");
    string? sentence = Console.ReadLine();
    if (!string.IsNullOrEmpty(sentence))//checking if the user entered empty or null string
    {
        if ((sentence.Split()).Length > 1) // checking for more than 1 word
        {
            string pigLatin = ToPigLatin(sentence);
            Console.WriteLine(pigLatin);
        }
        else
        {
            Console.WriteLine("Please enter a sentence instead of word:");
            continue;
        }

    }
    else
    {
        Console.WriteLine("Please enter a sentence:");
        continue;   // go to starting again
    }
    IsValid = GetContinued();
}

 static string ToPigLatin(string sentence)
{
    string vowels = "AEIOUaeiou";
    
    string finalSentence= "";

    foreach (string word in sentence.Split(' '))
    {
        string result = ""; // prevents appending words together
        string firstLetter = word.Substring(0, 1);  // (starting of index, length)
        if (word.All(Char.IsLetter)|| word.Contains("\'")|| word.Contains(".")) // determine all the characters in the word satisfies this condition and includes apostrope & Pull stop.
        {
            if (vowels.IndexOf(firstLetter) >= 0)     // vowels.IndexOf(e)>=0 1>0  else -1
            {
                result += word + "way";

            }
            else
            {

                for (int i = 0; i < word.Length; i++)
                {
                    char letter = word[i];
                    if (vowels.IndexOf(letter) > -1)
                    {
                        string restOfWord = word.Substring(i);
                        string consonants = word.Substring(0, i);
                        result += restOfWord + consonants + "ay";
                        break;
                    }
                }
            }
            finalSentence += result + " ";
        }
        else
        {
            finalSentence += word + " ";
        }
    } 
    
    
    return finalSentence.Trim();
    
}
static bool GetContinued()
{
  
        Console.WriteLine("Translate another line? (yes/no):");
        string? userOption = Console.ReadLine();
    return userOption == "yes";     // better way to replace if-else statement
       
}

