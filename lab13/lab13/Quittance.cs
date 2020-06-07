using System;
using System.Collections.Generic;
using System.Text;

namespace lab13
{
    public class Quittance : Document
    {
        public string Type { get; set; }

        static string[] TypeName = { "Багажная", "Доковая", "Грузовая", "Парцельная", "Товароскладочная" };
        static string MakeType()
        {
            return TypeName[rnd.Next(TypeName.Length)];
        }

        public Quittance()
        {
            Name = "Квитанция";
            Year = rnd.Next(1900, 2020);
            Type = MakeType();
        }

        public Quittance(int y, string t)
        {
            Name = "Квитанция";
            Year = y;
            Type = t;
        }

        public override void Show()
        {
            Console.WriteLine($"{Type} {Name}  , год создания - {Year}");
        }

        public override string ToString()
        {
            return Name + " " + Type + ", год создания - " + Year;
        }
    }
}
