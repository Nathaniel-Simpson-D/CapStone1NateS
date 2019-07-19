using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone1_PigLatin_NateS
{
    class Program
    {
        static void Main(string[] args)
        {
            bool rep = true;
            Console.WriteLine("Welcome to the piglatin translator.");
            while (rep)
            {
                string inWord = GetUserStr("what would you like to translate?");
                string pretrans = RemovePun(inWord);
                string[] midtrans = pretrans.Split(' ');
                int index = midtrans.Length;

                
                
                if (pretrans != null && pretrans != " ")
                {
                    int x = midtrans.Length;
                    for (int i=0; i<=index-1;i++)
                    {
                        

                        if (FindSpChar(midtrans[i]))
                        { TransWord(midtrans[i]);
                            
                        }
                        else
                        { Console.Write("not valid");
                            Console.WriteLine($"({midtrans[i]})");
                        }
                        Console.Write(" ");
                    }
                    
                    Console.WriteLine(" ");
                    rep = ValidUserChoice("would you like to translate again?");
                }
            }
            Console.WriteLine("have a good day, press Enter to exit.");
            
        }
        public static bool ValidUserChoice(string A, string B, string message)
        {
            string input = GetUserStr(message);

            if (input == A)
            { return true; }
            else if (input == B)
            { return false; }
            else
            { return ValidUserChoice(A, B, "Oops, not an option! "); }
        }
        public static string GetUserStr(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine().ToLower();
            if (input == null || input == " ")
            {
                string inp2 = GetUserStr("Oops thats not valid");
                return inp2;
            }
            else
            {
                return input;
            }
        }
        public static int GetUserInt(string message)
        {
            string input = GetUserStr(message);
            int num;
            if (int.TryParse(input, out num))
            {
                return num;
            }
            else
            {
                return GetUserInt("Please input a CORRECT number!");
            }
        }
        public static bool ValidUserChoice(string message)
        {
            string input = GetUserStr(message);

            if (input == "y" || input == "yes")
            { return true; }
            else if (input == "n" || input == "no")
            { return false; }
            else
            { return ValidUserChoice("Oops, not an option! "); }
        }
        public static void TransWord(string word)
        {
            int vowA = word.IndexOf("a");
            int vowE = word.IndexOf("e");
            int vowU = word.IndexOf("u");
            int vowO = word.IndexOf("o");
            int vowI = word.IndexOf("i");

            vowA = FixValue(vowA);
            vowE = FixValue(vowE);
            vowU = FixValue(vowU);
            vowO = FixValue(vowO);
            vowI = FixValue(vowI);

            if (vowA < vowE && vowA < vowU && vowA < vowO)
            {
                TransWord(vowA, word);
            }
            else if (vowE < vowA && vowE < vowU && vowE < vowO && vowE < vowI)
            { TransWord(vowE, word); }
            else if (vowU < vowE && vowU < vowA && vowU < vowO && vowU < vowI)
            { TransWord(vowU, word); }
            else if (vowO < vowE && vowO < vowU && vowO < vowA && vowO < vowI)
            { TransWord(vowO, word); }
            else if (vowI < vowE && vowI < vowU && vowI < vowO && vowI < vowA)
            { TransWord(vowI, word); }
            

        }
        public static void TransWord(int i,string word)
        {
            if (i == 0)
            {
                Console.Write($"{word}way ");
                Console.Write(" ");
            }
            else
            {
                string postA = word.Substring(i);
                string preA = word.Substring(0,i);
                Console.Write($"{postA}{preA}ay ");
                Console.Write(" ");
            }
            
        }
        public static int FixValue(int i)
        {
            if (i < 0)
            {
                i = 200;
                return i;
            }
            else
            {
                return i;
            }
        }
        public static bool FindSpChar(string s)
        {
            string[] specialChar = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")","_", "-", "+", "=", "{", "}", "[", "]", ";", ":", "/", "?", ".", ">", ",", "<", "'", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            int c = specialChar.Length;
            int x = 0;
            foreach (string str in specialChar)
            {
                if (s.IndexOf(str) != -1) { x = 101; }
            }
            if ( x != 101) { return true; }
            else { return false; }

        }
        public static string RemovePun(string pretrans)
        {
            if (pretrans.EndsWith("."))
                { pretrans.Replace('.', ' '); }
            if (pretrans.EndsWith("!"))
            { pretrans.Replace('!', ' '); }
            if (pretrans.EndsWith("?"))
            { pretrans.Replace('?', ' '); }
            if (pretrans.EndsWith("."))
            { pretrans.Replace('<', ' '); }
            return pretrans;
        }
    }
}
