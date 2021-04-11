using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescretModel
{
    class PostmenAlgoritm
    {
        public static int roadLength = 0;
        public static void PostmenMain()
        {
            int[,] input = ReadData.ReadInput(@"C:\Users\Ne1P\Desktop\8 семестр\Дескретні моделі\DescretModel\DescretModel\bin\Resours\inputLab2.txt");
            
            Console.WriteLine();
            Console.WriteLine("Введіть точку старту від 1 до "+ input.GetLength(0));

            int startPoint = 0;
            try
            {
                startPoint = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Буковки не підходять !!!\n");
            }
            if(!(startPoint>=1 & startPoint<= input.GetLength(0)))
            {
                Console.WriteLine("Некоректне число !!!\n");
                PostmenMain();
            }

            List<int> visitedPoint = new List<int>();
            visitedPoint.Add(--startPoint);
            
            while (visitedPoint.Count != input.GetLength(0))
                Step(visitedPoint, input, startPoint);
            if (input[visitedPoint.First(), visitedPoint.Last()] == 0)
            {
                Console.WriteLine("Немає шляху з точки " + (visitedPoint.Last()+1) + " в " + (visitedPoint.First()+1));
                Console.WriteLine("\n Результати");
                foreach (var item in visitedPoint)
                {
                    Console.Write((item + 1) + " -> ");
                }
                Console.WriteLine("\nДовжина шляху: " + roadLength);
            }
            else
            {
                roadLength += input[visitedPoint.First(), visitedPoint.Last()];
                Console.WriteLine("\n Результати");
                //Console.Write(startPoint);

                foreach (var item in visitedPoint)
                {
                    Console.Write((item + 1) + " -> ");
                }
                Console.WriteLine(visitedPoint.First() + 1);
                Console.WriteLine("\nДовжина шляху: " + roadLength);
            }
            
            
        }

        public static void Step(List<int> visitedPoint, int[,] input, int startPoint)
        {
            startPoint--;

            int minElement = 99;
            int minI = 0;
            

            if (visitedPoint.Count==0)
            {
                for (int i = 0; i < input.GetLength(0) ; i++)
                {
                    if ((input[startPoint, i] > 0 && input[startPoint, i] < minElement) & !visitedPoint.Contains(i))
                    {
                        minElement = input[startPoint, i];
                        minI = i;
                    }
                }

                visitedPoint.Add(minI);
                roadLength += minElement;
            }
            else
            {
                for (int i = 0; i < input.GetLength(0); i++)
                {
                    if ((input[visitedPoint.Last(), i] > 0 && input[visitedPoint.Last(), i] < minElement) &  !visitedPoint.Contains(i))
                    {
                        minElement = input[visitedPoint.Last(), i];
                        minI = i;
                    }
                }
                visitedPoint.Add(minI);
                roadLength += minElement;
            }
            
        }
    }
}
