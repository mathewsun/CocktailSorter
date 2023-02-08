namespace CocktailSorter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //CocktailSorter<int> list = new CocktailSorter<int>();

            //List<int> unsortedList = new List<int>();

            //unsortedList.Add(89);
            //unsortedList.Add(15);
            //unsortedList.Add(12);
            //unsortedList.Add(45);
            //unsortedList.Add(1);

            int[] unsortedList = { 89, 15, 12, 45, 1 };

            CocktailSorter<int> sorter = new CocktailSorter<int>();

            sorter.Sort(unsortedList, Comparer<int>.Default);

            Console.WriteLine("Finish!");
        }
    }

    /// <summary>
    ///     Cocktail Sort is a variation of Bubble sort, where Cocktail
    ///     Sort traverses through a given array in both directions alternatively.
    /// </summary>
    /// <typeparam name="T">Array input type.</typeparam>
    public class CocktailSorter<T>
    {
        /// <summary>
        ///     Sorts array using Cocktail sort algorithm.
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <param name="comparer">Type of comparer for array elements.</param>
        public void Sort(T[] array, IComparer<T> comparer) => CocktailSort(array, comparer);

        private static void CocktailSort(IList<T> array, IComparer<T> comparer)
        {
            var swapped = true;

            var startIndex = 0;
            var endIndex = array.Count - 1;

            while (swapped)
            {
                for (var i = startIndex; i < endIndex; i++)
                {
                    if (comparer.Compare(array[i], array[i + 1]) != 1)
                    {
                        continue;
                    }

                    var highValue = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = highValue;
                }

                endIndex--;
                swapped = false;

                for (var i = endIndex; i > startIndex; i--)
                {
                    if (comparer.Compare(array[i], array[i - 1]) != -1)
                    {
                        continue;
                    }

                    var highValue = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = highValue;

                    swapped = true;
                }

                startIndex++;
            }
        }
    }
}