using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescretModel
{
    class KruskalAlgoritm
    {
        public static void kruskalMain()
        {
            int[,] input = ReadData.ReadInput(@"C:\Users\Ne1P\Desktop\8 семестр\Дескретні моделі\DescretModel\DescretModel\bin\Resours\inputLab1.txt");

            //var graph = new Graph();
            //int matrixL = (int)Math.Sqrt(input.Length);

            //for (int i = 0; i < matrixL; i++)
            //{
            //    graph.AddVertex(Convert.ToString(i));
            //}

            //for (int i = 0; i < matrixL; i++)
            //{
            //    for (int j=i+1; j < matrixL; j++)
            //    {
            //        if (input[i,j] != 0)
            //        {
            //            graph.AddEdge(Convert.ToString(i), Convert.ToString(j), input[i, j]);
            //        }
            //    }

            //}
            Console.WriteLine();
            Console.WriteLine("Мінімальне дерево: ");
            Console.WriteLine();
            for (int i = 0; i < input.GetLength(0)-1; i++)
            {
                FindMinElement(input);
            }
            
        }

        public static void FindMinElement(int[,] input)
        {
            int minElement = 99;
            int minI = 0;
            int minJ = 0;
            for (int i = 0; i < input.GetLength(0); i++)
            { 
                for (int j = i+1; j < input.GetLength(1); j++)
                { 
                    if(input[i,j]>0 && input[i, j] < minElement)
                    {
                        minElement = input[i, j];
                        minI = i;
                        minJ = j;
                    }
                }
            }
            
            Console.WriteLine("Ребро вагою "+minElement+" з вершинами: " +(minI+1) + ", " + (minJ+1));

            input[ minI, minJ] = 0;

        }
    }
}
