using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haszowanie
{
    public class Hashing
    {
        public List<object>[] table;
        int maxElementsInLists; //%
        int minElementsInLists; //%
        int capacity;

        public int Capacity { get => capacity; set => capacity = value; }

        public Hashing(int capacity, int minElementsInLists = 1, int maxElementsInLists = 3)
        {
            table = new List<object>[findPrime(capacity)];
            this.capacity = table.Length;
            this.minElementsInLists = minElementsInLists;
            this.maxElementsInLists = maxElementsInLists;
        }


        public void Add(object x )
        {

            long position = FindPosition(x);
            if (table[position] == null)
                table[position] = new List<object>();
            table[position].Add(x);

            CheckisFull(table);
        }
        public void Delete(object x)
        {

            long position = FindPosition(x);

            table[position].Remove(x);
            CheckIsEmpty(table);
        }
        public bool Include(object x)
        {
            long position = FindPosition(x);
            return table[position] == null || table[position].IndexOf(x) == -1 ? false : true;
        }
        private long FindPosition(object x)
        {
            float value;
            long position;
            if (float.TryParse(x.ToString(), out value))
                position = HashNumber(value);
            else
                position = HashString(x.ToString());

            return position;
        }
        private long HashNumber(float x)
        {
            double alpha = (Math.Sqrt(5) - 1) / 2;
            return (int)(capacity * ((alpha * x) % 1));
        }
        private long HashString(string str)
        {
            //TODO: 
            throw new NotImplementedException();
        }
        private int findPrime(int capacity)
        {
            //TODO: szukanie najbliższej liczyby pierwszej liczbie podanej jako pojemność
            return capacity;
        }
        private void CheckisFull(List<object>[] table)
        {
            double avg = table.Average((x ) => { if (x != null) return x.Count; else  return 0; });
            double avg2 = avg * 100 / capacity;
            if (avg2 > maxElementsInLists * capacity / 100)
                IncreaseTable();
          
        }

        private void CheckIsEmpty(List<object>[] table)
        {
            double avg = table.Average((x) => { if (x != null) return x.Count; else return 0; }) * 100 / capacity;
       
             if (avg < minElementsInLists * capacity / 100  )
                ReduceTable();
        }


        private void addAgain(object x, List<object>[] table )
        {
            long position = FindPosition(x);
            if (table[position] == null)
                table[position] = new List<object>();
            table[position].Add(x);

        }

        private void ReduceTable()
        {
            capacity = findPrime(capacity / 2);
            List<object>[] newTable = new List<object>[capacity];
            foreach (var item in table)
            {
                foreach (var item1 in item)
                {
                    addAgain(item, newTable);
                }
            }
            table = newTable;
        }

        private void IncreaseTable()
        {
            capacity = findPrime(2 * capacity);
            List<object>[] newTable = new List<object>[capacity];
            foreach (var item in table)
            {
                if(item != null)
                foreach (var item1 in item)
                {
                    addAgain(item1, newTable);
                }
            }
            table = newTable;
        }
        public void Print()
        {
            foreach (var item in table)
            {
                if (item != null)
                {
                    foreach (var item1 in item)
                    {
                        Console.Write(item1 + " | ");
                    }
                }
                    Console.WriteLine();
            }
        }
    }
}
