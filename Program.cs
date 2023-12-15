using System.Reflection;
using System;


namespace Laboration4
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
        //Jag använder variabeln personCounter för att hela tiden kunna hålla koll på hur många personer som lagts till i listan
        //som håller information så att varje person får en tom plats i listan när den läggs till. 
        //Utöver personCounter så deklarerar och tilldelar jag variabeln menuChoice som programmet kommer
        //använda för att hantera användarens input när användaren står i menyn.
        //Listan "Persons" skapas också här och jag anger att den ska lagra objekt av klassen "Person".
            int menuChoice=0;
            int personCounter = 0;
            List<Person> Persons = new List<Person>();
            while (menuChoice != 3)
            {
                Console.WriteLine("\n------------------------------------------------------------" +
                    "\n|    Vad vill du göra nu?                                  |" +
                    "\n|    1. Lägga till personer i listan.                      |" +
                    "\n|    2. Skriva ut alla personer som lagts till i listan.   |" +
                    "\n|    3. Avsluta programmet.                                |" +
                    "\n------------------------------------------------------------");
             string menuChoiceInput=Console.ReadLine();
                while (!int.TryParse(menuChoiceInput, out menuChoice) || menuChoice > 3 || menuChoice < 1)
                {
                    Console.WriteLine("\n Felaktigt val: Skriv in en siffra mellan 1 och 3 \n");
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
            //I denna metod frågar programmet användaren efter input för att lagra värden i de properties som Person-klassen har:
            //name, eyeColor, birthDate, gender och personHair. Sedan skapas ett nytt objekt av klassen Person där dessa värden lagras, 
            //samtidigt läggs detta objekt i listan Persons
            void AddPerson()
            {
                //Här initialiserar jag de variabler som behöver användas senare i metoden
                int birthYear;
                int birthMonth;
                int birthDay;
                int genderChoice;
                Console.WriteLine("\nSkriv in namnet på personen: \n");
                string name = Console.ReadLine();
                //För varje input från användaren har jag skapat en while-loop som kommer loopa och uppmana användaren om korrekt input  
                //tills programmet får det.
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Du kan inte lämna detta fält tomt. Försök igen.");
                    name = Console.ReadLine();
                }
                Console.WriteLine($"\nAnge {name}s ögonfärg: \n");
                string eyeColor = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(eyeColor))
                {
                    Console.WriteLine("Du kan inte lämna detta fält tomt. Försök igen");
                    eyeColor = Console.ReadLine();
                }
                Console.WriteLine($"\nAnge {name}s födelseår, fyra siffror: \n");
                string birthInputYear = Console.ReadLine();
                while (!int.TryParse(birthInputYear, out birthYear) || int.Parse(birthInputYear) > 2023 || int.Parse(birthInputYear) < 1900)
                {
                    Console.WriteLine("Du måste skriva in en giltig siffra mellan 1900 och 2023, och detta fält kan inte lämnas tomt.");
                    birthInputYear = Console.ReadLine();
                }
                Console.WriteLine($"\nAnge {name}s födelesmånad med en siffra mellan 1 och 12\n");
                string birthInputMonth = Console.ReadLine();
                while (!int.TryParse(birthInputMonth, out birthMonth) || int.Parse(birthInputMonth) > 12 || int.Parse(birthInputMonth) < 1)
                {
                    Console.WriteLine("Du måste skriva in en siffra mellan 1 och 12, och detta fält kan inte lämnas tomt");
                    birthInputMonth= Console.ReadLine();
                }
                Console.WriteLine($"\nAnge {name}s födelesdag:\n");
                string birthInputDay = Console.ReadLine();
                while (!int.TryParse(birthInputDay, out birthDay) || int.Parse(birthInputDay) > 31 || int.Parse(birthInputDay) < 1)
                {
                    Console.WriteLine("Du måste skriva in ett tal mellan 1 och 31, och detta fält kan inte lämnas tomt");
                    birthInputDay= Console.ReadLine();
                }
                DateOnly birthDate = new DateOnly(birthYear, birthMonth, birthDay);
                Console.WriteLine($"\nAnge {name}s kön: Kvinna= 0, Man= 1 eller Annat= 2\n");
                string genderInputChoice = Console.ReadLine();
                while (!int.TryParse(genderInputChoice, out genderChoice) || int.Parse(genderInputChoice) > 2 || int.Parse(genderInputChoice) < 0)
                {
                    Console.WriteLine("Du måste skriva 0, 1 eller 2, och detta fält kan inte lämnas tomt");
                    genderInputChoice= Console.ReadLine();
                }
                Gender personGender = (Gender)genderChoice;
                Console.WriteLine($"\nSkriv in hårlängd på {name}\n");
                string hairLength = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(hairLength))
                {
                    Console.WriteLine("Detta fält kan inte lämnas tomt. Försök igen.");
                    hairLength = Console.ReadLine();
                }
                Console.WriteLine($"\nSkriv in hårfärg på {name}\n");
                string hairColor = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(hairColor))
                {
                    Console.WriteLine("Detta fält kan inte lämnas tomt. Försök igen.");
                    hairColor = Console.ReadLine();
                }
                Hair personHair = new Hair(hairLength, hairColor);
                //Programmet använder nu den validerade inputen för att skapa ett nytt objekt av klassen "Person" och lägga till det i listan
                //"Persons. 
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