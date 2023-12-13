using System.Reflection;
using System;

namespace Laboration4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menuChoice=0;
            int personCounter = 0;
            List<Person> Persons = new List<Person>();
            while (menuChoice != 3)
            {
                Console.WriteLine("\n Vad vill du göra nu? \n 1. Lägga till personer i listan.  " +
                    "\n 2. Skriva ut alla personer som lagts till i listan. " +
                    "\n 3. Avsluta programmet. ");
             string menuChoiceInput=Console.ReadLine();
                while (!int.TryParse(menuChoiceInput, out menuChoice) || menuChoice > 3 || menuChoice < 1)
                {
                    Console.WriteLine("Skriv in en siffra mellan 1 och 3");
                    menuChoiceInput = Console.ReadLine();
                }
                switch (menuChoice)
                {
                    case 1:
                        AddPerson();

                        break;
                    case 2:
                        ListPersons();
                        break;

                }
            }
            void AddPerson()
            {
                //Här initialiserar jag de variabler som behöver användas senare i metoden
                int birthYear;
                int birthMonth;
                int birthDay;
                int genderChoice;
                Console.WriteLine("Skriv in namnet på personen");
                string name = Console.ReadLine();
                //För varje input från användaren har jag skapat en while-loop som kommer loopa och uppmana användaren om korrekt input  
                //tills programmet får det.
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Du kan inte lämna detta fält tomt. Försök igen.");
                    name = Console.ReadLine();
                }
                Console.WriteLine($"Ange {name}s ögonfärg");
                string eyeColor = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(eyeColor))
                {
                    Console.WriteLine("Du kan inte lämna detta fält tomt.");
                    eyeColor = Console.ReadLine();
                }
                Console.WriteLine($"Ange {name}s födelseår, fyra siffror.");
                string birthInputYear = Console.ReadLine();
                while (!int.TryParse(birthInputYear, out birthYear) || int.Parse(birthInputYear) > 2023 || int.Parse(birthInputYear) < 1900)
                {
                    Console.WriteLine("Du måste skriva in en giltig siffra mellan 1900 och 2023, och detta fält kan inte lämnas tomt.");
                    birthInputYear = Console.ReadLine();
                }
                Console.WriteLine($"Ange {name}s födelesmånad, siffra mellan 1 och 12");
                string birthInputMonth = Console.ReadLine();
                while (!int.TryParse(birthInputMonth, out birthMonth) || int.Parse(birthInputMonth) > 12 || int.Parse(birthInputMonth) < 1)
                {
                    Console.WriteLine("Du måste skriva in en giltig siffra mellan 1 och 12, och detta fält kan inte lämnas tomt");
                    birthInputMonth= Console.ReadLine();
                }
                Console.WriteLine($"Ange {name}s födelesdag");
                string birthInputDay = Console.ReadLine();
                while (!int.TryParse(birthInputDay, out birthDay) || int.Parse(birthInputDay) > 31 || int.Parse(birthInputDay) < 1)
                {
                    Console.WriteLine("Du måste skriva in en giltig siffra mellan 1 och 31, och detta fält kan inte lämnas tomt");
                    birthInputDay= Console.ReadLine();
                }
                DateOnly birthDate = new DateOnly(birthYear, birthMonth, birthDay);
                Console.WriteLine($"Ange {name}s kön: Kvinna= 0, Man= 1 eller Annat= 2");
                string genderInputChoice = Console.ReadLine();
                while (!int.TryParse(genderInputChoice, out genderChoice) || int.Parse(genderInputChoice) > 2 || int.Parse(genderInputChoice) < 0)
                {
                    Console.WriteLine("Du måste skriva 0, 1 eller 2, och detta fält kan inte lämnas tomt");
                    genderInputChoice= Console.ReadLine();
                }
                Gender personGender = (Gender)genderChoice;
                Console.WriteLine($"Skriv in hårlängd på {name}");
                string hairLength = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(hairLength))
                {
                    Console.WriteLine("Detta fält kan inte lämnas tomt. Försök igen.");
                    hairLength = Console.ReadLine();
                }
                Console.WriteLine($"Skriv in hårfärg på {name}");
                string hairColor = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(hairColor))
                {
                    Console.WriteLine("Detta fält kan inte lämnas tomt. Försök igen.");
                    hairColor = Console.ReadLine();
                }
                Hair personHair = new Hair(hairLength, hairColor);
                //Programmet använder nu den validerade inputen för att skapa ett nytt objekt av klassen "Person" och lägga till det i listan
                //"Persons. För att hålla koll på vilken plats i listan som personen ska läggas till i använder jag variabeln personCounter.
                //För varje gång metoden AddPerson anropas och fullföljs av användaren så kommer variabeln personCounter att öka med 1.
                Persons.Insert(personCounter, new Person(name, eyeColor, birthDate, personHair, personGender));
                personCounter = personCounter++;
            }
            void ListPersons()
            {
                foreach (Person person in Persons)
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }
    }
}