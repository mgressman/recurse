using System;
using System.Collections;

namespace ConsoleApp4
{
    internal class Program
    {
        private void GetItems(dynamic item, ref object[] items)
        {
            if (!(item is IEnumerable))
            {
                Array.Resize(ref items, items.Length + 1);
                items[items.Length - 1] = item;
            }
            else
            {
                foreach (var i in item)
                {
                    if (!(i is IEnumerable))
                    {
                        Array.Resize(ref items, items.Length + 1);
                        items[items.Length - 1] = i;
                    }
                    else
                    {
                        this.GetItems(i, ref items);
                    }
                }
            }
        }

        private void Run()
        {
            var data = new object[] { 'a', 'b', 1, new object[] {'x', 'y', new object[] {1, 2, new[] {'e'}}, 'r', 't'}, 3, 4, 'i' };

            var items = new object[] { };

            this.GetItems(data, ref items);

            Console.WriteLine(string.Join(',', items));
            Console.ReadLine();
        }

        private static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }
    }
}
