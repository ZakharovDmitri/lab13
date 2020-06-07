using System;
using System.Collections.Generic;
using System.Text;

namespace lab13
{
	public class SortBySum : IComparer<Check>
	{
		public int Compare(Check c, Check c1)
		{

			if (c.Sum < c1.Sum) return -1;
			else if (c.Sum == c1.Sum) return 0;
			else return 1;
		}
	}
	public class Check : Quittance, ICloneable
	{
		public Check ShallowCopy()
		{
			return (Check)this.MemberwiseClone();
		}

		public object Clone()
		{
			return new Check(this.Year, "Клон  " + this.Type, this.Sum);
		}

		static string[] TypeName = { "Дорожный", "Магазинный", "Именной", "Расчетный", "Банковский", "Ордерный" };
		static string MakeType()
		{
			return TypeName[rnd.Next(TypeName.Length)];
		}

		int sum;

		public int Sum
		{
			get { return sum; }
			set
			{
				if (value < 0) sum = 0;
				else sum = value;
			}
		}

		public Check()
		{
			Name = "Чек";
			Year = rnd.Next(1900, 2020);
			Type = MakeType();
			Sum = rnd.Next(0, 99999);
		}

		public Check(int y, string t, int s)
		{
			Name = "Чек";
			Year = y;
			Type = t;
			Sum = s;
		}

		public override void Show()
		{
			Console.WriteLine($"{Type} {Name}  , год создания - {Year}, сумма на чеке = {Sum} ");
		}

		public override string ToString()
		{
			return Name + " " + Type + ", год создания - " + Year + " - Сумма - " + Sum;
		}
	}
}
