using System;
using System.Collections.Generic;
using System.Text;

namespace lab13
{
    public class Waybill : Document, IComparable
    {

        public new int CompareTo(object obj1)
        {
            Waybill w1 = new Waybill();
            Waybill w2 = new Waybill("1234", 2019);

            if (w1.Year > w2.Year) return -1;
            else if (w1.Year == w2.Year) return 0;
            else return 1;
        }

        static string[] TypeName = { "Товарная", "Товарно-транспортная", "Авиационная", "Железнодорожная", "Автотранспортная", "Транспортная" };
        static string MakeType()
        {
            return TypeName[rnd.Next(TypeName.Length)];
        }
        public Waybill()
        {
            Name = MakeType();
            Year = rnd.Next(1900, 2020);
        }
        public Waybill(string n, int y) : base(n, y) { }

        public override void Show()
        {
            Console.WriteLine($"{Name} Накладная , год создания - {Year}");
        }

        public override string ToString()
        {
            return Name + " накладная" + ", год создания - " + Year;
        }
    }
}
