
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using static System.DateTime;
События. Есть поле(матрица) на этом поле размещюатся рыбки.Есть кошка котоая ходит по этому полю еслли она натыкаеться на жту рыбку -сьедает.Сьела +ккал, если ходит то -ккал.Определить норму максимума и минимума ккалорий. (события кошка сьела,кошка умерла)

namespace ConsoleApp4
{

    class Program
    {
        public delegate void CatMessage(string message);
        public event CatMessage Notify; 
        public int N { get; set; }
        public int count = 0;
        public int M { get; set; }
        public int[,] matrix = { };
        public Program()
        {
            N = 4;
            M = 4;
        }
        public Program(int n, int m)
        {
            matrix = new int[n, m];
            this.N = n;
            this.M = m;
        }
        public int this[int x, int y]
        {

            get { return matrix[x, y]; }
            set { matrix[x, y] = value; }

        }
        public void Vvod()
        {
            Random r1 = new Random();
            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.M; j++)
                {
                    this.matrix[i, j] = 0;

                }
            }
            int n = r1.Next(0, N-1);
            int m = r1.Next(0, M-1);
            matrix[n, m] = 1;
            count = 1;
        }
        public void Create_Cat()
        {
            Random r1 = new Random((int)Now.Ticks);

            int n = r1.Next(0, N);
            int m = r1.Next(0, M);
            do
            {
                if (IndexOf(1).Item1 == n && IndexOf(1).Item2 == m)
                {
                    Random p1 = new Random((int)Now.Ticks);
                    Random p2 = new Random((int)Now.Ticks);
                    n = p1.Next(0, N);
                    m = p2.Next(0, M);
                    matrix[n, m] = 3;

                }
                else
                {
                    matrix[n, m] = 3;
                }
            } while (IndexOf(1).Item1 == n && IndexOf(1).Item2 == m);
          
        }
        public void Create_Fish()
        {
            if (count == 0)
            {
                Random r1 = new Random((int)Now.Ticks);
                Random r2 = new Random((int)Now.Ticks);
                int n = r1.Next(0, N);
                int m = r2.Next(0, M);
          
                if (IndexOf(3).Item1 == n && IndexOf(3).Item2 == m)
                {
           
                    /*
                    while (IndexOf(3).Item1 != n || IndexOf(3).Item2 != m)
                    {
                        
                            n = r1.Next(0, N)%(n-1);
                            m = r2.Next(0, M)%(m-1);
                        if (IndexOf(3).Item1 != n && IndexOf(3).Item2 != m)
                        {
                            matrix[n, m] = 1;
                            count = 1;
                            
                        }
                    }*/
                    Create_Fish();
                }
                else
                {
                    matrix[n, m] = 1;
                    count = 1;
                }
            }
        
        }
        public bool Eat_OR_NOT(int n, int m)
        {
            if (IndexOf(1).Item1 == n && IndexOf(1).Item2 == m)
                return true;

            return false;
        }
        public void Move_Cat()
        {
            int calorie = 600;

            
            Console.WriteLine("press to move:\n      8\n" +
                "4            6\n" +
             "      2");
            
            while (calorie >= 0 && calorie <= 5000)
            {
                int c_p1 = IndexOf(3).Item1;
                int c_p2 = IndexOf(3).Item2;

                int key = int.Parse(Console.ReadLine());
                switch (key)
                {
                    case 8:
                        {
                            if (c_p1 - 1 >= 0)
                            {
                                if (Eat_OR_NOT(c_p1 - 1, c_p2))
                                {
                                    matrix[c_p1 - 1, c_p2] = matrix[c_p1, c_p2];
                                    matrix[c_p1, c_p2] = 0;
                                    count = 0;
                                    Create_Fish();
                                    calorie += 150;
                                    if (Notify != null) Notify("Cat ate a fish");

                                }
                                else
                                {
                                    calorie -= 150;
                                    matrix[c_p1 - 1, c_p2] = matrix[c_p1, c_p2];
                                    matrix[c_p1, c_p2] = 0;
                                }
                               
                                //Console.WriteLine($"calorie: {calorie}");
                            }
                            else
                                Console.WriteLine("invalid move");
                            break;
                        }
                    case 4:
                        {
                            if (c_p2 - 1 >= 0)
                            {
                                if (Eat_OR_NOT(c_p1, c_p2 - 1))
                                {
                                    matrix[c_p1, c_p2 - 1] = matrix[c_p1, c_p2];
                                    matrix[c_p1, c_p2] = 0;
                                    count = 0;
                                    calorie += 150;
                                    Create_Fish();

                                    if (Notify != null) Notify("Cat ate a fish");

                                }
                                else
                                {
                                    calorie -= 150;
                                    matrix[c_p1, c_p2 - 1] = matrix[c_p1, c_p2];
                                    matrix[c_p1, c_p2] = 0;
                                }
                                
                                //Console.WriteLine($"calorie: {calorie}");
                            }
                            else
                                Console.WriteLine("invalid move");
                            break;
                        }
                    case 6:
                        {
                            if (c_p2 + 1 < M)
                            {

                                if (Eat_OR_NOT(c_p1, c_p2 + 1))
                                {
                                    matrix[c_p1, c_p2 + 1] = matrix[c_p1, c_p2];
                                    matrix[c_p1, c_p2] = 0;
                                    count = 0;
                                    calorie += 150;
                                    Create_Fish();
                                    if (Notify != null) Notify("Cat ate a fish");

                                }
                                else
                                {
                                    calorie -= 150;
                                    matrix[c_p1, c_p2 + 1] = matrix[c_p1, c_p2];
                                    matrix[c_p1, c_p2] = 0;

                                }
                                
                                //Console.WriteLine($"calorie: {calorie}");
                            }
                            else
                                Console.WriteLine("invalid move");
                            break;

                        }
                    case 2:
                        {
                            if (c_p1 + 1 < N)
                            {
         
                                if (Eat_OR_NOT(c_p1 + 1, c_p2))
                                {
                                matrix[c_p1 + 1, c_p2] = matrix[c_p1, c_p2];
                                    matrix[c_p1, c_p2] = 0;
                                    count = 0;
                                    calorie += 150;
                                    Create_Fish();
                                    if (Notify != null) Notify("Cat ate a fish");
                                }
                                else
                                {
                             matrix[c_p1 + 1, c_p2] = matrix[c_p1, c_p2];
                                    matrix[c_p1, c_p2] = 0;
                                    calorie -= 150;

                                }
                                
                                
                            }
                            else
                                Console.WriteLine("invalid move");
                            break;

                        }

                }
                Console.WriteLine($"calorie: {calorie}");
                if (calorie < 0 && (Notify != null)) Notify("D I E D");
                if (calorie > 5000 && (Notify != null)) Notify("D I E D");
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {

                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine("\n");
                }

            }
            

        }
        
        public Tuple<int,int> IndexOf(int x)
        {
            
            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.M; j++)
                {
                    if (matrix[i,j].Equals(x))
                    {
     
                        return Tuple.Create(i,j);
                    }

                }
            }
            return Tuple.Create(-1,-1);
        }
   
        
        public void Show()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                 
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
    }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            int N = 3;
            int M = 3;
            Program m = new Program(N,M);
            m.Notify += DisplayMessage;

            m.Vvod();
            m.Create_Cat();
            m.Show();
            
                
                m.Move_Cat();
                Console.WriteLine();
          
            Console.ReadKey();
            
        }
    }
}
