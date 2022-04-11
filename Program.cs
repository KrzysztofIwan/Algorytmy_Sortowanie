using System;
using System.Runtime;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;



namespace Algorytmy_Sortowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            // menu
            Console.Write("Podaj ile liczb ma znajdować się w twojej tablicy: ");
            int numbers = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n\n------------------------------------------------\n\n");
            Console.WriteLine("Co chcesz zrobić z tablicą?: ");
            Console.WriteLine("1 - sorted to high");
            Console.WriteLine("2 - reversed");
            Console.WriteLine("3 - unique");
            Console.WriteLine("4 - do nothing just random");
            Console.Write("Wybór: ");
            string option = Console.ReadLine();
            Console.Write("\n------------------------------------------------\n\n");

            // Base array 1
            int[] arr = new int[numbers];
            arr = ArrGenerator(numbers);
            // Base array 2
            int[] arrBase = new int[numbers];
            int pomocniczaBase = 0;
            foreach (int i in arr)
            {
                arrBase[pomocniczaBase] = i;
                pomocniczaBase++;
                if (pomocniczaBase == numbers)
                {
                    continue;
                }
            }


            if (option == "1")
            {
                Array.Sort(arr);
            } else if (option == "2")
            {
                Array.Reverse(arr);
            } else if (option == "3")
            {
                IEnumerable<int> uniqueArr = arr.Distinct<int>();
                arr = uniqueArr.ToArray();
            }else if(option == "4") {}
            else
            {
                Console.Write("\n\n------------------------------------------------\n\n");
                Console.WriteLine("Nie ma takiej opcji");
                Console.Write("\n\n------------------------------------------------\n\n");
                Environment.Exit(0);
            }

            // InsertSort array 
            int[] arr2 = new int[numbers];
            int pomocnicza = 0;
            foreach(int i in arr)
            {
                arr2[pomocnicza] = i;
                pomocnicza++;
                if (pomocnicza == numbers)
                {
                    continue;
                }
            }

            // MergeSort array
            int[] arr3 = new int[numbers];
            int pomocnicza2 = 0;
            foreach (int i in arr)
            {
                arr3[pomocnicza2] = i;
                pomocnicza2++;
                if (pomocnicza2 == numbers)
                {
                    continue;
                }
            }

            // QuickSort classice array
            int[] arr4 = new int[numbers];
            int pomocnicza3 = 0;
            foreach (int i in arr)
            {
                arr4[pomocnicza3] = i;
                pomocnicza3++;
                if (pomocnicza3 == numbers)
                {
                    continue;
                }
            }
            // QuickSort metod array
            int[] arr5 = new int[numbers];
            int pomocnicza4 = 0;
            foreach (int i in arr)
            {
                arr5[pomocnicza4] = i;
                pomocnicza4++;
                if (pomocnicza4 == numbers)
                {
                    continue;
                }
            }
            /*Console.Write("Wygenerowana Tablica: ");
            foreach (int i in arrBase)
            {
                Console.Write("[" + i + "]" + " ");
            }*/
            int[] InsertionSortArr = InsertionSort(arr2);
            Console.Write("Insertion Sort ");
           /* foreach (int i in InsertionSortArr)
            {
                Console.Write("["+i +"]" + " ");
            }*/
            Console.Write("\n\n------------------------------------------------\n\n");
            var stopWatchMS = new Stopwatch();
            stopWatchMS.Start();
            MergSort ob = new MergSort();
            stopWatchMS.Stop();
            Console.WriteLine("Czas Algorytmu: " + stopWatchMS.Elapsed.TotalMilliseconds + " ms");
            Console.Write("Merge Sort ");

           /* foreach (int i in arr3)
            {
                Console.Write("[" + i + "]" + " ");
            }*/
            Console.Write("\n\n------------------------------------------------\n\n");
            var stopWatchQSC = new Stopwatch();
            double sum = 0;
            stopWatchQSC.Start();
            QuickSortClassical(arr4,0,arr4.Length - 1);
            sum += stopWatchQSC.Elapsed.TotalMilliseconds;
            stopWatchQSC.Stop();

            Console.WriteLine("Czas Algorytmu: " + sum + " ms");
            Console.Write("Quick Sort Classice ");

            /*foreach (int i in arr4)
            {
                Console.Write("[" + i + "]" + " ");
            }*/
            Console.Write("\n\n------------------------------------------------\n\n");
            // Quick Sort Metod
            var stopWatchQS = new Stopwatch();
            stopWatchQS.Start();
            Array.Sort(arr5);
            stopWatchQS.Stop();
            var time = stopWatchQS.Elapsed;
            time += time;
            Console.WriteLine("Czas Algorytmu: " + time.TotalMilliseconds + " ms");
            Console.Write("Quick Sort Metod ");
            /*foreach (int i in arr5)
            {
                Console.Write("[" + i + "]" + " ");
            }*/
            Console.Write("\n\n------------------------------------------------\n\n");

        }
        // FUNKCJE
        public static int[] ArrGenerator(int numbers)
        {
            var random = new Random();
            int[] arr = new int[numbers];
            for (int i = 0; i < numbers; i++)
            {
                // losowanie wartości od 0 do x-1
                // x <- dowolna liczba > 0
                int b = random.Next(numbers);
                arr[i] = b;
            }
            return arr;
        }

        // Insertion Sort Function 
        public static int[] InsertionSort(int[] arrToSort)
        {
            var stopwatchIS = new Stopwatch();
            stopwatchIS.Start();
            int lenght = arrToSort.Length;
            int[] InsertionSortArr = new int[lenght];
            for (int i = 1; i < lenght; i++)
            {
                int key = arrToSort[i];
                int j = i - 1;
                while(j >= 0 && arrToSort[j] > key)
                {
                    arrToSort[j + 1] = arrToSort[j];
                    j = j - 1;
                }
                arrToSort[j + 1] = key;
            }
            InsertionSortArr = arrToSort;
            stopwatchIS.Stop();
            Console.WriteLine("Czas Algorytmu: " + stopwatchIS.Elapsed.TotalMilliseconds + " ms");
            return InsertionSortArr;
        }

        // Quick Sort Classical
        public static void QuickSortClassical(int[] arrToSort, int left, int right)
        {
            var stopWatchQSC = new Stopwatch();
            stopWatchQSC.Start();
            var x = left;
            var y = right;
            var pom = arrToSort[(x + y) / 2];
            while(y > x)
            {
                while(arrToSort[x] < pom) { x++; }
                while(arrToSort[y] > pom) { y--; }
                if(y >= x)
                {
                    //swap 
                    var tmp = arrToSort[x];
                    arrToSort[x++] = arrToSort[y];
                    arrToSort[y--] = tmp;
                }
            }
            if(left < y) { QuickSortClassical(arrToSort, left, y); }
            if(x < right) { QuickSortClassical(arrToSort, x, right); }
            stopWatchQSC.Stop();
            double sum =0;
            
        }
        
    }
        
    class MergSort
    {
        //Merge Sort Function
        public void Merge(int[] arrToSort, int x, int y, int z)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = y - x + 1;
            int n2 = z - y;
            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;
            // Copy data to temp arrays
            for (i = 0; i < n1; i++)
            {
                L[i] = arrToSort[i + x];
            }
            for (j = 0; j < n2; j++)
            {
                R[j] = arrToSort[y + 1 + j];
            }
            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;
            // Initial index of merged
            // subarray array
            int k = x;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arrToSort[k] = L[i];
                    i++;
                }
                else
                {
                    arrToSort[k] = R[j];
                    j++;
                }
                k++;
            }
            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arrToSort[k] = L[i];
                i++;
                k++;
            }
            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arrToSort[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that
        // sorts arr[x..z] using
        // merge()
        public void MergeSort(int[] MergeSortArr1, int x, int z)
        {
            if (z > x)
            {
                // Find the middle
                // point
                int y = x + ((z - x)/ 2);
                // Sort first and
                // second halves
                MergeSort(MergeSortArr1, x, y);
                MergeSort(MergeSortArr1, y + 1, z);

                // Merge the sorted halves
                Merge(MergeSortArr1, x, y, z); 
            }
        }
    }
}
