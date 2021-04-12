using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescretModel
{
    class FordaFalckersonaAlgorithm
    {
        public static List<int> maxWeight = new List<int>();
        public static void FordaFalckersonaMain()
        {
            int[,] input = ReadData.ReadInput(@"C:\Users\Ne1P\Desktop\8 семестр\Дескретні моделі\DescretModel\DescretModel\bin\Resours\inputLab4.txt");

            stepOne(input);

            Console.WriteLine("Пропускна здатність графа: " + maxWeight.Sum());
        }

        public static void stepOne(int[,] input)
        {
            int[,] tempData = input;

            List<int> visitVertex = new List<int>();
            visitVertex.Add(0);
            int finishVertex = tempData.GetLength(0);
            int stepVertex = 0;
            Console.WriteLine("Vertex 0 Edhe weight INF");
            while ((stepVertex+1)  != finishVertex)
            {
                
                stepVertex = canVisit(tempData, stepVertex);
                if (stepVertex == 0)
                    return;
                visitVertex.Add(stepVertex);
            }

            int[] visitArr = new int[visitVertex.Count()];
            int v = 0;

            int minEdgeWeight = 0;

            foreach (var item in visitVertex)
            {
                visitArr[v] = item;
                v++;
            }
            int[] edgeWeight = new int[visitArr.Length - 1];

            for (int i = 0; i < visitArr.Length - 1; i++)
            {
                edgeWeight[i] = tempData[visitArr[i], visitArr[i + 1]];
            }
           
            minEdgeWeight = edgeWeight.Min();
           
            for (int i = 0; i < visitArr.Count()-1; i++)
            {
                tempData[visitArr[i], visitArr[i + 1]] -= minEdgeWeight;
                tempData[visitArr[i+1], visitArr[i]] += minEdgeWeight;
            }
            Console.WriteLine();

            //for (int i = 0; i < tempData.GetLength(0); i++)
            //{
            //    for (int j = 0; j < tempData.GetLength(1); j++)
            //    {
            //        Console.Write(tempData[i, j] + "\t");
            //    }
            //    Console.WriteLine();
            //}

            Console.Write("\nfMin = ");
            foreach (var item in edgeWeight)
            {
                Console.Write(item + " ");
            }
            Console.Write(" = "+minEdgeWeight+"\n\n");
            maxWeight.Add(minEdgeWeight);
            stepOne(tempData);
        }
        public static int canVisit(int[,] Graph, int currentVertex)
        {
            int canVisitVertex = new int();

            int maxEdgeValue = 0;
            for (int i = 0; i < Graph.GetLength(0); i++)
            {
                if (Graph[currentVertex,i]>0)
                {
                    if (maxEdgeValue< Graph[currentVertex, i])
                    {
                        maxEdgeValue = Graph[currentVertex, i];
                        canVisitVertex= i;
                    }
                }
            }
            if (canVisitVertex==0)
            {
                Console.WriteLine("Finish");
                return 0;
            }
            else
            {
                Console.WriteLine("Vertex " + (canVisitVertex + 1) + " Edge weight " + maxEdgeValue);
                return canVisitVertex;
            }
        }
    }
}
