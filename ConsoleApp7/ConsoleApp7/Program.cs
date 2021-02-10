using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.DateTime;
namespace ConsoleApp7
{
    class Program
    {
     
        static int additional_check(int[] add_arr, int[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                if (add_arr[i] == 0 && mass[i] == 1) return i;
            }
            return -1;
        }

        private static int[] Check(int size, int[,] matrix, int[] mass, int[] add_arr)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                add_arr[size] = 1;
                if (matrix[size, i] == 1)
                {
                    mass[i] = 1;
                }
            }
            if (additional_check(add_arr, mass) != -1)
                return Check(additional_check(add_arr, mass), matrix, mass, add_arr);
            else
                return mass;

        }
        static void Main(string[] args)
        {
            int size = 4;
            int[,] matrix = new int[size, size];
            int[] mass = new int[size];
            int[] mass1 = new int[size];
            int[] add_arr = new int[size];

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                        matrix[i, j] = 1;
                    else
                        matrix[i, j] = -1;
                }
           
            Random rand = new Random((int)Now.Ticks);
            for (int i = 0; i < size; i++)
            {
                add_arr[i] = 0;
                mass[i] = 0;
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
            mass1 = Check(0, matrix, mass, add_arr);
            Console.WriteLine();

            for (int i = 0; i < mass1.Length; i++)
            {
                Console.Write(mass1[i] + " ");
            }
            Console.WriteLine();
            bool flag = true;
            for (int i = 0; i < mass1.Length ; i++)
            {
                if (mass1[i] == 0)
                {
                    Console.WriteLine("incoherent graph");
                    flag = false;
                    break;
                }
                
            }
            if(flag)
                Console.WriteLine("connected graph");
            Console.ReadKey();
        }
        
 
    }
}
