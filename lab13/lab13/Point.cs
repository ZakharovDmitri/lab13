using System;
using System.Collections.Generic;
using System.Text;

namespace lab13
{
    public class Point<T>
    {
        public object key;
        public int value;
        public Point<T> next;
        public Point(T s)
        {
            key = s;
            value = key.GetHashCode();
            next = null;
        }


        public Point()
        {
            Random rnd = new Random();
            int m = rnd.Next(1, 5);
            switch (m)
            {
                case 1:
                    Document d = new Document();
                    key = d;
                    value = key.GetHashCode();
                    next = null;
                    break;
                case 2:
                    Quittance q = new Quittance();
                    key = q;
                    value = key.GetHashCode();

                    next = null;
                    break;
                case 3:
                    Check c = new Check();
                    key = c;
                    value = key.GetHashCode();
                    next = null;
                    break;
                case 4:
                    Waybill w = new Waybill();
                    key = w;
                    value = key.GetHashCode();
                    next = null;
                    break;
            }
        }

        public override string ToString()
        {
            return key + " : " + value.ToString();
        }
        public override int GetHashCode()
        {
            return key.GetHashCode();
        }

    }

   

    public class MyHashTable<T> : ICloneable/*, IEnumerable<T>*/
    {
        MyHashTable<T> data;


        //    class MyNumerator<T> : IEnumerator<T>
        //    {
        //        Point<T> beg;//начало коллекции
        //        Point<T> current;//текущий

        //        public object Current
        //        {
        //            get
        //            {
        //                return current.key;
        //            }
        //        }

        //        public MyNumerator(MyHashTable<T> collection)
        //        {
        //            beg = collection.Beg;
        //            current = null;
        //        }

        //        object IEnumerator.Current
        //        {
        //            get { return current; }
        //        }

        //        public void Dispose()
        //        {

        //        }

        //        public bool MoveNext()
        //        {

        //            if (current == null)
        //                current = beg;
        //            else
        //                current = current.next;
        //            return current != null;

        //        }

        //        public void Reset()
        //        {
        //            current = this.beg;
        //        }



        //    }
        //    public IEnumerator<T> GetEnumerator()
        //    {
        //        return new MyNumerator<T>(this);
        //    }

        //    IEnumerator IEnumerable.GetEnumerator()
        //    {
        //        return GetEnumerator();
        //    }


        Point<T> beg = null;
        
        public MyHashTable<T> this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }

        public object Clone()
        {
            return new MyHashTable<T>(this.Length);
        }

        public MyHashTable<T> ShallowCopy()
        {
            return (MyHashTable<T>)this.MemberwiseClone();
        }

        

        public Point<T> End
        {
            get
            {
                if (beg == null) return beg;
                Point<T> p = beg;
                while (p.next != null)
                {
                    p = p.next;

                }
                return p;
            }
        }

        public Point<T> Beg
        {
            get { return beg; }
            set { beg = value; }
        }

        public int Length
        {
            get
            {
                if (beg == null) return 0;
                int len = 0;
                Point<T> p = beg;
                while (p != null)
                {
                    p = p.next;
                    len++;
                }
                return len;

            }
        }

        public MyHashTable()
        {
            beg = null;
            
        }

        public MyHashTable(int size)
        {
            
            beg = new Point<T>();
            
            for (int i = 0; i < size - 1; i++)
            {
                Point<T> temp = new Point<T>();
                temp.next = beg;
                beg = temp;
            }
        }

        public MyHashTable(params T[] mas)
        {
            
            beg = new Point<T>();
            beg.key = mas[0];
            Point<T> p = beg;
            for (int i = 1; i < mas.Length; i++)
            {
                Point<T> temp = new Point<T>();
                temp.key = mas[i];
                p.next = temp;
                p = temp;
            }
        }

        public void PrintList()
        {
            if (beg == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }
            Point<T> p = beg;
            while (p != null)
            {
                Console.WriteLine(p);
                p = p.next;
            }
        }

        public virtual void Add(int index, T o)
        {
            Point<T> temp = new Point<T>(o);
            if (index < 0)
                Console.WriteLine("Index out of range");
            if (index > Length + 1)
                Console.WriteLine("Index out of range");
            if (index == 1)
            {

                if (beg == null)
                {
                    beg = temp;
                }
                else
                {
                    temp.next = beg;
                    beg = temp;
                }
            }
            else if (index == Length + 1)
            {

                End.next = temp;
                End.key = temp.key;

            }
            else
            {

                int count = 1;
                Point<T> p = beg;
                while (count != index - 1)
                {
                    p = p.next;
                    count++;
                }


                Point<T> next;
                next = p.next;
                p.next = temp;
                temp.next = next;
            }

        }

        public virtual void RemoveKey(T key)
        {
            if (Length == 0)
            {
                Console.WriteLine("Список пустой");
                return;
            }

            if (Length == 1 && Beg.key.Equals(key))
            {
                beg = null;
                return;
            }
            if (Length == 1 && !Beg.key.Equals(key))
            {
                Console.WriteLine("Элемента нет в списке");
                return;
            }

            if (Beg.key.Equals(key))
            {
                beg = beg.next;
                return;
            }

            Point<T> p = beg;
            while (p.next.next != null && !p.next.key.Equals(key)) p = p.next;

            if (!p.next.key.Equals(key))
            {
                Console.WriteLine("Элемента нет в списке");
                return;
            }

            p.next = p.next.next;
        }

        public void Search(T key)
        {
            if (Length == 0)
            {
                Console.WriteLine("Список пустой");
                return;

            }
            if (Beg.key.Equals(key))
            {
                Console.WriteLine($"Наш элемент найден, его хэш-код - {beg.value}");
                return;
            }

            if (Length == 1 && !Beg.key.Equals(key))
            {
                Console.WriteLine("Элемента нет в списке");
                return;
            }

            if (Length == 1 && Beg.key.Equals(key))
            {
                Console.WriteLine($"Наш элемент найден, его хэш-код - {beg.value}");
                return;
            }

            Point<T> p = beg;
            while (p.next.next != null && !p.next.key.Equals(key)) p = p.next;

            if (!p.next.key.Equals(key))
            {
                Console.WriteLine("Элемента нет в списке");
                return;
            }

            Console.WriteLine($"Наш элемент найден, его хэш-код - {p.next.value}");

        }

        public void Clear()
        {
            beg = null;
        }

        public void Sort()
        {
            
        }

    }
}
