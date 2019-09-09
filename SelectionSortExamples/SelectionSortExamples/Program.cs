using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSortExamples
{
    class Program
    {
        const double min = -10.00;
        const double max = 65.00;

        static double[] data;
        static void Main(string[] args)
        {
            for (int i = 1000; i <= 1000000; i *= 10)
            {
                Console.WriteLine($"Dataset size: {i}");
                Populate(i);
                Console.WriteLine(BubbleSort());
                Console.WriteLine(InsertionSort());
                Console.WriteLine(SelectionSort()+"\n");
            }
            Console.WriteLine("\n...Processing finished...");
            Console.ReadLine();
        }

        static void Populate(int size)
        {
            data = new double[size];
            Random rnd = new Random();
            for(int i = 0; i < size; i++)
            {
                /*A way of generating doubles within a range*/
                data[i] = Math.Round((rnd.NextDouble()*(max - min) + min),2);
            }
        }

        static void Display<T>(T[] arr)
        {
            foreach(T x in arr)
                Console.Write($"{x} ");
        }

        static string BubbleSort()
        {
            double[] temp = new double[data.Length];
            data.CopyTo(temp, 0);
            Stopwatch sw = new Stopwatch();
            bool check = false;
            //Display(temp);
            /*Improved Bubble sort*/
            sw.Start();
            for(int outer = 0; outer < temp.Length; outer++)
            {
                check = false;
                for(int inner = 0; inner < (temp.Length-1)-outer; inner++)
                {
                    if(temp[inner] > temp[inner+1])
                    {
                        double swap = temp[inner];
                        temp[inner] = temp[inner + 1];
                        temp[inner + 1] = swap;
                        check = true;
                    }
                }
                if (!check)
                    break;
            }
            sw.Stop();
            //Display(temp);
            return $"Bubble Sort Time: {sw.ElapsedMilliseconds}ms";
        }

        static string InsertionSort()
        {
            double[] temp = new double[data.Length];
            data.CopyTo(temp, 0);
            double swap;
            int inner;
            Stopwatch sw = new Stopwatch();
            //Display(temp);
            /*Insertion sort*/
            sw.Start();
            for(int outer = 0; outer < data.Length; outer++)
            {
                inner = outer;
                swap = temp[outer];
                while (inner > 0 && temp[inner-1] >= swap)
                {
                    temp[inner] = temp[inner - 1];
                    inner--;
                }
                temp[inner] = swap;
            }
            sw.Stop();
            //Display(temp);
            return $"Insertion Sort Time: {sw.ElapsedMilliseconds}ms";
        }

        static string SelectionSort()
        {
            double[] temp = new double[data.Length];
            data.CopyTo(temp, 0);
            Stopwatch sw = new Stopwatch();
            //Display(temp);
            /*Selection sort*/
            sw.Start();
            for (int outter = 0; outter < temp.Length; outter++)
            {
                int min = outter;//Create a starting point for the lowest number.
                for (int inner = outter + 1; inner < temp.Length; inner++)//Linear search the rest of the data for the lowest value
                {
                    if (temp[inner] < temp[min])
                        min = inner;//Store the lowest number in the min variable
                }
                double swap = temp[outter];//Once the lowest value is found perform the swap.
                temp[outter] = temp[min];
                temp[min] = swap;
            }
            sw.Stop();
            //Display(temp);
            return $"Selection Sort Time: {sw.ElapsedMilliseconds}ms";
        }
    }
}
