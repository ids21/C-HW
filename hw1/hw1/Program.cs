using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1
{
    class Program
    {

static int[] displace(int[] a, int n)
        {
            int[] temp = new int[n];
            int j = a.Length - 1;
            for (int i = 0; i < a.Length; i++)
            {
                temp[i] = a[j];
                j++;
                if (j == a.Length) j = 0;
                Console.WriteLine(j);

            }
            return temp;
        }
        static int inver(int[] arr)
        {
            int count = 0;
            for (int i = 0; i <arr.Length - 1; i++)
               for (int j=i+1;j<arr.Length;j++)
                    if (arr[j]<arr[i]) count++;
            
            return count;
        }
        static int[,] multiply(int[,] arr1, int[,] arr2)
        {
            int[,] temp = new int[arr1.GetLength(0),arr2.GetLength(1)];
            try
            {
                
                for (int i = 0; i < arr1.GetLength(0); i++)
                {
                    for (int j = 0; j < arr2.GetLength(1); j++)
                        for (int k = 0; k < arr2.GetLength(0); k++)
                        {
                            {
                                temp[i, j] += arr1[i, k] * arr2[k, j];
                            }
                        }
                }
            }
            catch
            {
                if (arr1.GetLength(1) != arr2.GetLength(0))
                    Console.WriteLine("incorect sizeof arrays");
            }
            return temp;
        }/*
        static void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
        static void print_perestanovku(int[] arr)
        {
         
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();

        }
        static void Generation(int[] a, int i)
        {
            if (i == a.Length)
            {
                print_perestanovku(a);
                
            }

            else
            {
                for (int j = i; j < a.Length; j++)
                {
                    Swap(a, i, j);
                  
                    Generation(a, i + 1);
          
                    Swap(a, i, j);
              
                }
            }
        }
        static void Perestanovki()
        {
            int n = 5;
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i;
            }
            Generation(arr,0);
        }*/
        static void Print_Matrix(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void selection_sort(int[] a, int n)
        {
            int k ,x ;
            for (int i = 0; i < n; i++)
            {
                k = i;
                x = a[i];
                for (int j = i + 1; j < n; j++)
                {
                    if (a[j] < x)
                    {
                        k = j;
                        x = a[j];
                    }
                }
                a[k] = a[i];
                a[i] = x;
            }
           
        }
        static void insertion_sort(int[] a, int n)
        {
            int k, x;
            for (int i = 1; i < n; i++)
            {
                k = i;
                x = a[i];
                while (k>0 && a[k-1] > a[k] )
                {
                    int temp = a[k - 1];
                    a[k - 1] = a[k];
                    a[k] = temp;
                    k -= 1;
                      
                }
            }
             
            

        }
        static void Palindrom()
        {

            int n = 0;
            int x = Convert.ToInt32(Console.ReadLine());
            int num = x;
            while (num > 0)
            {
                num /= 10;
                n++;
                //Console.WriteLine(num);

            }
            int[] arr = new int[n];
            for (int i = n - 1; i >= 0; i--)
            {
                arr[i] = x % 10;
                x /= 10;
            }
            bool f = true;
            for (int i = 0; i < n / 2; i++)
            {
                if (arr[i] != arr[n - i - 1])
                {
                    f = false;
                }

            }
            if (f)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
        }
        static void NOD()
        {
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            while ((x != 0) & (y != 0))
            {
                if (x > y)
                    x %= y;
                else
                    y %= x;
            }
            Console.WriteLine(Math.Max(y, x));
        }
        static void NaimVhod()
        {
            int n = 5;
            int[] a = new int[n];
            int[] b = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = Int32.Parse(Console.ReadLine());
            }

            for (int j = 0; j < b.Length; j++)
            {
                b[j] = Int32.Parse(Console.ReadLine());
            }
            bool f = false;


            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                f = false;
                for (int j = 0; j < n; j++)
                    if (a[i] == b[j])
                    {
                        f = true;
                        break;
                    }
                if (!f)
                {
                    list.Add(a[i]);
                }
            }
            if (list.Count == 0) Console.WriteLine("list is empty");
            else
            {
                int[] array = list.ToArray();
                int min = array[0];
                for (int i = 0; i < array.Length; i++)
                {
                    if (list[i] <= min)
                        min = list[i];
                    Console.Write(array[i] + " ");
                }
                Console.WriteLine();
                Console.Write("min= " + min);
            }
            Console.ReadKey();
        }
        static void Sort()
        {
            Console.WriteLine("количество элементов массива");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = rnd.Next(0, 10);
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
            insertion_sort(a, n);
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.ReadKey();
        }
        static void Displace()
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            int[] b = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = rnd.Next(0, 10);
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
            b = displace(a, n);
            for (int i = 0; i < n; i++)
            {
                Console.Write(b[i] + " ");
            }
            Console.WriteLine();
        }
        static void Count_inver()
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                //a[i] = rnd.Next(0, 10);
                a[i] = int.Parse(Console.ReadLine());
                Console.Write(a[i] + " ");
        
            }
            Console.WriteLine();
            int count = 0;
            count=inver(a);
            Console.WriteLine(count);
            Console.ReadKey();
        }
        static void Matr_mult()
        {
            int n = 3;
            int[,] A = new int[n, n];
            Random rnd = new Random();
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {

                    A[i, j] = rnd.Next(1, 10);
                }
            }
            int[,] B = new int[n, n];
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {

                    B[i, j] = rnd.Next(1, 10);
                }
            }
            Console.WriteLine("\nМатрица A:");
            Print_Matrix(A);
            Console.WriteLine("\nМатрица B:");
            Print_Matrix(B);
            int[,] c = multiply(A, B);
            Console.WriteLine("\nМатрица C:");
            Print_Matrix(c);
        }
        static void Weather()
        {
            int months = 12;
            int daysInFeb = System.DateTime.DaysInMonth(2018, 2);
            int daysInJan = System.DateTime.DaysInMonth(2018, 1);
            int daysInMar = System.DateTime.DaysInMonth(2018, 3);
            int daysInApr = System.DateTime.DaysInMonth(2018, 4);
            int daysInMay = System.DateTime.DaysInMonth(2018, 5);
            int daysInJun = System.DateTime.DaysInMonth(2018, 6);
            int daysInJul = System.DateTime.DaysInMonth(2018, 7);
            int daysInAug = System.DateTime.DaysInMonth(2018, 8);
            int daysInSep = System.DateTime.DaysInMonth(2018, 9);
            int daysInOct = System.DateTime.DaysInMonth(2018, 10);
            int daysInNov = System.DateTime.DaysInMonth(2018, 11);
            int daysInDec = System.DateTime.DaysInMonth(2018, 12);
            Random rnd = new Random();

            List<List<int>> list = new List<List<int>>();    //динамический двумерный массив
            List<int> row = new List<int>();

            row = new List<int>();
            for (int j = 0; j < daysInJan; j++)
            {
                row.Add(rnd.Next(0, 5));
            }
            list.Add(row);

            row = new List<int>();
            for (int j = 0; j < daysInFeb; j++)
            {
                row.Add(rnd.Next(0, 5));
            }
            list.Add(row);

            row = new List<int>();
            for (int j = 0; j < daysInMar; j++)
            {
                row.Add(rnd.Next(0, 5));
            }
            list.Add(row);

            row = new List<int>();
            for (int j = 0; j < daysInApr; j++)
            {
                row.Add(rnd.Next(0, 5));
            }
            list.Add(row);

            row = new List<int>();
            for (int j = 0; j < daysInMay; j++)
            {
                row.Add(rnd.Next(0, 5));
            }
            list.Add(row);

            row = new List<int>();
            for (int j = 0; j < daysInJun; j++)
            {
                row.Add(rnd.Next(0, 5));
            }
            list.Add(row);

            row = new List<int>();
            for (int j = 0; j < daysInJul; j++)
            {
                row.Add(rnd.Next(0, 5));
            }
            list.Add(row);

            row = new List<int>();
            for (int j = 0; j < daysInAug; j++)
            {
                row.Add(rnd.Next(0, 5));
            }
            list.Add(row);

            row = new List<int>();
            for (int j = 0; j < daysInSep; j++)
            {
                row.Add(rnd.Next(0, 5));
            }
            list.Add(row);

            row = new List<int>();
            for (int j = 0; j < daysInOct; j++)
            {
                row.Add(rnd.Next(0, 5));
            }
            list.Add(row);

            row = new List<int>();
            for (int j = 0; j < daysInNov; j++)
            {
                row.Add(rnd.Next(0, 5));
            }
            list.Add(row);

            row = new List<int>();
            for (int j = 0; j < daysInDec; j++)
            {
                row.Add(rnd.Next(0, 5));
            }
            list.Add(row);


            for (int i = 0; i < months; i++)                   
            {
                int sum = 0;
                for (int j = 0; j < list[i].Count; j++)
                {
                    Console.Write(list[i][j] + " ");
                    sum += list[i][j];
                }
                Console.WriteLine();
                Console.Write("average rainfall is " + sum / list[i].Count + " mm");
                Console.WriteLine();

            }
        }
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
        static void Selection_sort()
        {
            int n = 5;
            int[] a = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = Int32.Parse(Console.ReadLine());
            }
            selection_sort(a, n);
            for (int i = 0; i < n; i++)
                Console.Write(a[i] + " ");
        }
        static void Quick_sort()
        {
            int n = 5;
            int[] a = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = Int32.Parse(Console.ReadLine());
            }
            quicksort(a,0,n-1);
            for (int i = 0; i < n; i++)
                Console.Write(a[i] + " ");
        }
        static void Main(string[] args)
        {
            //Palindrom();
            //NOD();
            //NaimVhod();
            //Sort();  
            //Displace();
            //Count_inver();
            //Matr_mult();
            //Weather();
            //Selection_sort();
            //Quick_sort();
            
            /*
            int[,] graph = { { 0, 1, 1, 0, 0, 0, 1 }, // матрица смежности
                             { 1, 0, 1, 1, 0, 0, 0 },
                             { 1, 1, 0, 0, 0, 0, 0 },
                             { 0, 1, 0, 0, 1, 0, 0 },
                             { 0, 0, 0, 1, 0, 1, 0 },
                             { 0, 0, 0, 0, 1, 0, 1 },
                             { 1, 0, 0, 0, 0, 1, 0 }};
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (graph[i, j] == 1 && graph[j, i] == 1)
                        Console.WriteLine("way from " + i + "to " + j);
                }
            }
            */
            Console.ReadKey();
        }
    }
   
}
