using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration4
{
    public class Person
    {
        //class properties
        public string Name { get; set; }
        public string EyeColor { get; set; }
        public DateOnly BirthDate { get; set; }
        public Hair PersonHair { get; set; }
        public Gender PersonGender { get; set; }

        //constructor
        public Person(string name, string eyeColor, DateOnly birthDate, Hair personHair, Gender personGender)
        {
            Name = name;
            EyeColor = eyeColor;
            BirthDate = birthDate;
            PersonHair = personHair;
            PersonGender = personGender;
        }

        //ToString metod som gör om datan till string och formatterar den för utskrift.
        public override string ToString()
        {
            return
            $"\nNamn: {Name}" +
            $"\nÖgonfärg: {EyeColor}" +
            $"\nFödelsdag: {BirthDate}" +
            $"\nHårlängd: {PersonHair.Length} " +
            $"\nHårfärg: {PersonHair.Color}" +
            $"\nKön: {PersonGender}";
        }

    }
}
