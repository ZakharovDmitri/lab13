using System;
using System.Collections.Generic;
using System.Text;

namespace lab13
{
	public class Document : IComparable
	{

		public int CompareTo(object obj)
		{
			Document d = new Document();
			Document d1 = new Document("12345", 1999);

			if (d.Year < d1.Year) return -1;
			else if (d.Year == d1.Year) return 0;
			else return 1;
		}
		int year;
		protected static Random rnd = new Random();
		static string[] NameDoc = { "Договор о неразглашении", "Договор о предоставлении услуг", "Договор у дружбе и границе", "Приказ о приеме на работу", "Приказ о продлении карантина", "Протокол разногласий" };
		static string MakeDoc()
		{
			return NameDoc[rnd.Next(NameDoc.Length)];
		}
		public string Name { get; set; }
		public int Year
		{
			get { return year; }
			set
			{
				if (value < 0) year = 2020;
				else if (value > 2020) year = 2020;
				else year = value;
			}
		}

		public Document()
		{
			Name = MakeDoc();
			Year = rnd.Next(1900, 2020);
		}

		public Document(string n, int y)
		{
			Name = n;
			Year = y;
		}

		public virtual void Show()
		{
			Console.WriteLine($"Название документа - {Name} , год его создания - {Year} ");
		}

		public override string ToString()
		{
			return Name + ", год создания - " + Year;
		}
	}
}
