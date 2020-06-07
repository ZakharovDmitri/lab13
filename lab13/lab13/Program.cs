using System;


namespace lab13
{
    class Program
    {
        public static MyHashTable<Document> collection = new MyHashTable<Document>();
        public static Check c = new Check(2020, "Тестовый", 6666);

        static int ReadNumber(string invitation, int minValue, int maxValue) // Проверка корректности ввода числа
        { //Отбирает только целые числа в границах от minValue до maxValue
            bool ok;
            int value;
            do
            {
                Console.WriteLine(invitation);
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out value);
                if (!ok || value < minValue || value > maxValue)
                    Console.WriteLine($"Неправильный формат ввода. Пожалуйста, введите число от {minValue} до {maxValue}");
            } while (!ok || value < minValue || value > maxValue);
            return value;
        }



        static void PrintMenuMain()
        {
            Console.WriteLine("1. Создать коллекцию\n" +
                    "2. Напечатать\n" +
                    "3. Добавить элемент(Элемент уже создан)\n" +
                    "4. Найти добавленный элемент\n" +
                    "5. Удалить добавленный нами элемент\n" +
                    "6. Клонировать\n" +
                    "7. Выход\n");
        }

        static void PrintMenuMainMain()
        {
            Console.WriteLine("1. Часть 1\n" +
                    "2. Часть 2\n" +
                    "3. Выход\n");
        }

        static void PrintMenuPart1()
        {
            int choice;
            do
            {
                PrintMenuMain();



                choice = ReadNumber("Введите номер желаемой опции", 1, 7);

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        CreateCollection();

                        break;
                    case 2:
                        Console.Clear();
                        collection.PrintList();
                        break;
                    case 3:
                        Console.Clear();
                        AddCheck();
                        break;
                    case 4:
                        Console.Clear();
                        Find();
                        break;
                    case 5:
                        Console.Clear();
                        Delete();
                        break;
                    case 6:
                        Console.Clear();
                        
                        break;

                }

            } while (choice != 7);
        }

        static void PrintMenuPart2()
        {
            MyNewCollection<Document> l1 = new MyNewCollection<Document>();
            l1.Name = "Name";
            Document d = new Document();
            Document c = new Document();
            Check c1 = new Check();
            Journal j1 = new Journal();
            Journal j2 = new Journal();
            l1.Add(1,d);
            l1.Add(2, c);
            l1.RemoveKey(c1);
            l1.PrintList();
            l1.CollectionCountChanged += new CollectionHandler(j1.CollectionCountChange);
            l1.CollectionReferenceChanged += new CollectionHandler(j2.CollectionReferenceChange);


        }

            static void PrintInputMenu(out int option)
            {
                Console.Clear();
                option = ReadNumber("Введите размер коллекции для формирования, не больше 100", 0, 100);
            }



            static void CreateCollection()
            {
                PrintInputMenu(out int option);
                collection = new MyHashTable<Document>(option);
            }

            static void AddCheck()
            {

                collection.Add(1, c);
            }

            static void Delete()
            {

                collection.RemoveKey(c);
            }

            static void Find()
            {

                collection.Search(c);
            }


            static void Main(string[] args)
            {

                int choice;
            
                do
                {
                    
                    PrintMenuMainMain();
                

                    choice = ReadNumber("Введите номер желаемой опции", 1, 3);
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                        PrintMenuPart2();

                            break;
                        case 2:
                            Console.Clear();
                            PrintMenuPart1();
                            break;
                        
                    }
                } while (choice != 3);


            }
        }
    }

