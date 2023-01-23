using System;
using System.Collections.Generic;

/*  Singleton je třída s jednou jedinou instancí. Místo konstruktoru instanci získáme statickou GetInstance metodou.
 *  - GetInstance vrátí instanci, druhé zavolání GetInstance vrátí stejnou instanci - singleton
 *  - Uživatel ani nemusí o využití singletonu vědět.
 *  - V aplikaci je zajištěno, že se dvě instance nestarají o jednu věc.
 */

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseOperations DO1 = DatabaseOperations.GetInstance();
            DO1.AddWord("jedna");
            DO1.AddWord("dve");
            DO1.AddWord("Tri ctyri");

            DatabaseOperations DO2 = DatabaseOperations.GetInstance();

            foreach (var word in DO2.GetWords())
            {
                Console.WriteLine(word);
            }
            foreach (var word in DO1.GetWords())
            {
                Console.WriteLine(word);
            }

        }
    }

    public class DatabaseOperations
    {
        private static DatabaseOperations SingletonInstance;
        public List<string> Words { get; set; } = new();    

        private DatabaseOperations(){}

        public static DatabaseOperations GetInstance()
        {
            if (SingletonInstance == null)
            {
                SingletonInstance = new DatabaseOperations();
                return SingletonInstance;
            }
            else
            {
                return SingletonInstance;
            }
        }

        public List<string> GetWords()
        {
            return Words;
        }

        public string GetWord(int index)
        {
            try
            {
                return Words[index];
            }
            catch (Exception)
            {
                Console.WriteLine("index out of bounds");
                return "Null!";
            }
        }

        public void AddWord(string word)
        {
            Words.Add(word);
        }

    }
}
