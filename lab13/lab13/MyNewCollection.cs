using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;


namespace lab13
{

    public class CollectionHandlerEventArgs:System.EventArgs
    {
        public string NameCollection { get; set; }
        public string ChangeCollection { get; set; }
        public object Obj { get; set; }

        public CollectionHandlerEventArgs(string name,string type,object obj)
        {
            NameCollection = name;
            ChangeCollection = type;
            Obj = obj;
        }

        public override string ToString()
        {
            return "Имя коллекции: " + this.NameCollection + " Тип изменения: " + this.ChangeCollection + " Объект: " + this.Obj;
        }
    }

    delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    class MyNewCollection<T>:MyHashTable<T>
    {
        public string Name { get; set; }
        
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;
        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionCountChanged != null)
                CollectionCountChanged(source, args);
        }

        public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionReferenceChanged != null)
                CollectionReferenceChanged(source, args);
        }

        public override void RemoveKey(T key)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.Name, "delete", key));
            Console.WriteLine(new CollectionHandlerEventArgs(this.Name, "delete", key));
            base.RemoveKey(key);

        }

        public override void Add(int index,T o)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.Name, "add", o));
            Console.WriteLine(new CollectionHandlerEventArgs(this.Name, "add", o));
            base.Add(index, o);
        }

       

    }

    public class JournalEntry
    {
        public string Name { get; set; }
        public string Change { get; set; }
        public object ObjData { get; set; }

        public JournalEntry(string name, string type, object obj)
        {
            Name = name;
            Change = type;
            ObjData = obj;
        }

        public override string ToString()
        {
            return "Имя коллекции: " + this.Name + " Тип изменения: " + this.Change + " Объект: " + this.ObjData;
        }

    }

    public class Journal
    {
        private List<JournalEntry> journal;
        public Journal()
        {
            journal = new List<JournalEntry>();
        }

        public void CollectionCountChange(object sourse,CollectionHandlerEventArgs e)
        {
            JournalEntry je = new JournalEntry(e.NameCollection, e.ChangeCollection, e.Obj.ToString());
            journal.Add(je);
        }
        public void CollectionReferenceChange(object sourse, CollectionHandlerEventArgs e)
        {
            JournalEntry je = new JournalEntry(e.NameCollection, e.ChangeCollection, e.Obj.ToString());
            journal.Add(je);
        }

        public override string ToString()
        {
            foreach(JournalEntry item in journal)
            {
                Console.WriteLine(item.ToString());
            }
            return "";
        }
    }
}
