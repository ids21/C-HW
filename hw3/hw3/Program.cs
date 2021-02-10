using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hw3
{
    class Program
    {
        static void count_words(StreamReader file)
        {
           
            try
            {
                string s = "";
                string[] textMass;
                while (file.EndOfStream != true)
                {
                    s += file.ReadLine();
                }
                textMass = s.Split(' ');
                Console.Write(textMass.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void reverse_file(StreamReader a,StreamWriter b)
        {
            try
            {
                string s = "";
                string[] textMass;
                while (a.EndOfStream != true)
                {
                    s += a.ReadLine();
                }
                textMass = s.Split(' ');
                for (int i = textMass.Length-1; i >= 0; i--)
                {
                    //Console.WriteLine(textMass[i]);
                    b.Write(textMass[i] + " ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
        
        static void letter(StreamReader file_in)
        {
            try
            {
                string s="";
                string[] textMass;
                int count=1;
                string[] maxMass=null;
                while (file_in.EndOfStream != true)
                {
                    s += file_in.ReadLine();
                }
                textMass = s.Split(' ');
                s ="";
                int max = 0;
                int i = 0;
                while(i < textMass.Length-1)
                {
                    
                    for (int j = i+1; j < textMass.Length; j++)
                    {
                        if (textMass[i][textMass[i].Length - 1] == textMass[i + 1][0])
                        {
                            if (textMass[i][textMass[i].Length - 1] == textMass[j][0])
                            {
                                count += 1;
                               
                            }
                        }
                       
                    }
                    if (count > max)
                    {
                        max = count;
                      
                    }
                    count = 1;
                    i++;
                    
                }
                //for (int k = 0; k < maxMass.Length; k++)
                    Console.Write(s);
                
          
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static int[,] multiply(int[,] arr1, int[,] arr2)
        {
            int[,] temp = new int[arr1.GetLength(0), arr2.GetLength(1)];
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
        }
     
        static void Matr_mult(StreamReader a,StreamWriter b)
        {
            while (a.EndOfStream != true)
            {
                int n = int.Parse(a.ReadLine());
             
                int[,] A = new int[n, n];

                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {

                        A[i, j] = int.Parse(a.ReadLine());
                    }
                }
                int m = int.Parse(a.ReadLine());
                int[,] B = new int[m, m];
                for (int i = 0; i < B.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {

                        B[i, j] = int.Parse(a.ReadLine());
                    }
                }

                int[,] c = multiply(A, B);
                Console.WriteLine("\nМатрица C:");
                b.WriteLine(Convert.ToString(c.GetLength(0)));
                for (int i = 0; i < c.GetLength(0); i++)
                {
                    for (int j = 0; j < c.GetLength(1); j++)
                    {
                        b.WriteLine(c[i, j]);
                    }
                   
                }
            }
        
            
        }
        static void Write_Matrix()
        {
            StreamReader matrix = new StreamReader("matrix.txt");
            StreamWriter out_sr = new StreamWriter("output.txt");
            Matr_mult(matrix, out_sr);
            matrix.Close();
            out_sr.Close();

            StreamReader new_matrix = new StreamReader("output.txt");
            StreamWriter new_out_sr = new StreamWriter(new FileStream("matrix.txt",FileMode.Append,FileAccess.Write));

            while (new_matrix.EndOfStream != true)
            {
                int n = int.Parse(new_matrix.ReadLine());
                new_out_sr.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        new_out_sr.WriteLine(new_matrix.ReadLine());
                    }
                    new_out_sr.WriteLine();
                }
                new_out_sr.WriteLine();
            }
            new_matrix.Close();
            new_out_sr.Close();

        }
        static void QueBin(BinaryReader a,BinaryReader b, BinaryWriter c)
        {
            int i = a.ReadInt32();
            int j = b.ReadInt32();
   
            while (a.PeekChar() != -1 && b.PeekChar() != -1)
            {
                    if (i <= j)
                    {
                        c.Write(i);
                        i = a.ReadInt32();
                       
                    }
                    else
                    {
                        c.Write(j);
                        j = b.ReadInt32();
                    }
            }

            /*while(a.PeekChar() > -1)
            {
             c.Write(a.ReadInt32());
            }
            while (b.PeekChar() > -1)
            {
                c.Write(b.ReadInt32());
            }
            */
        }
        static void EvenOddBin(BinaryReader a, BinaryReader b, BinaryWriter c)
        {
            int i = a.ReadInt32();
            int j = b.ReadInt32();

            while (a.PeekChar() != -1 && b.PeekChar() != -1)
            {
                if (i < j)
                {
                    c.Write(i);
                    i = a.ReadInt32();

                }
                else
                {
                    c.Write(j);
                    j = b.ReadInt32();
                }
            }
            while (a.ReadInt32() != -1)
            {
                if (i != -1) //i = a.ReadInt32();
                    c.Write(i);
            }
            while (b.ReadInt32() != -1)
            {
                if (j != -1) //j = b.ReadInt32();
                    c.Write(j);


            }



        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            //StreamReader matrix = new StreamReader("matrix.txt");
            StreamWriter out_sr = new StreamWriter("output.txt");
            //count_words(sr);
            //reverse_file(sr, out_sr);
            //letter(sr);
            //Write_Matrix();
            
            using (BinaryWriter writer = new BinaryWriter(File.Open("bin_out.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 == 0)
                        writer.Write(i);
                }
                writer.Close();
            }
            
                using (BinaryWriter write1 = new BinaryWriter(File.Open("bin_out1.txt", FileMode.OpenOrCreate)))
                {
                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 != 0)
                    {
                        write1.Write(i);
                    }
                }
                write1.Close();
                }
            
            using (BinaryReader write1 = new BinaryReader(File.Open("bin_out1.txt", FileMode.Open)))
            {
                using (BinaryReader writer = new BinaryReader(File.Open("bin_out.txt", FileMode.Open)))
                {
                    using (BinaryWriter write2 = new BinaryWriter(File.Open("bin_out2.txt", FileMode.OpenOrCreate)))
                    {

                        QueBin(writer, write1, write2);
                        write2.Close();
                    }
                    writer.Close();
                }
                
                write1.Close();
                
            }
            using (BinaryReader write2 = new BinaryReader(File.Open("bin_out2.txt", FileMode.Open)))
            {
                while(write2.PeekChar() > -1 )
                Console.Write(write2.ReadInt32());
                write2.Close();
            }
                sr.Close();
            //matrix.Close();

            out_sr.Close();
            Console.ReadKey();
        }
    }
}
