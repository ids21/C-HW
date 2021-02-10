using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{

    class Program
    {


        static void quicksort(int[] array, int start, int end)
        {
            int d = array[(end + start) / 2];

            int b = start;
            int e = end;
            do
            {
                while ((array[b] < d) && (b < end))
                    b++;
                while ((array[e] > d) && (e > start))
                    e--;
                if (b <= e)
                {
                    int temp = array[b];
                    array[b] = array[e];
                    array[e] = temp;
                    b++;
                    e--;
                }
            } while (b <= e);
            if (start < e)
                quicksort(array, start, e);
            if (b < end)
                quicksort(array, b, end);

        }

        static void swap(int i,int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
        static void permute(int[] str, int i, int n)
        {
            if (i == n)
                Console.WriteLine(str);
            else
            {
                for (int j = i; j < n; j++)
                {
                    swap(str[i],str[j]);
                    permute(str, i + 1, n);
                }
            }
        }
        static void Main(string[] args)
        {
            /*
            int[] a = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < a.Length; i++)
                {
                a[i] = rnd.Next(0,20);
                Console.Write(a[i] + " ");
                }
            Console.WriteLine();
            quicksort(a,0,a.Length-1);
            */
            int[] str = new int[3];
            for (int i = 0; i < 3; i++)
                str[i] = i+1;
            permute(str, 0,3);
            /*
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]+" ");
            }
            */
            Console.ReadKey();
        }
    }
}
