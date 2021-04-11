using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescretModel
{
    class KommviagerAlgoritm
    {
        public static void kommviagerAlgoritm()
        {
            int[,] input = ReadData.ReadInput(@"C:\Users\Ne1P\Desktop\8 семестр\Дескретні моделі\DescretModel\DescretModel\bin\Resours\inputLab3.txt");
            Console.WriteLine();
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    if (input[i, j] == 0)
                    {
                        input[i, j] = -1;
                    }
                    //Console.Write(input[i, j] + "\t");

                }
            }

            int startPoint = 0;

            Console.WriteLine();
            Console.WriteLine("Введіть точку старту від 1 до " + input.GetLength(0));
            try
            {
                startPoint = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Буковки не підходять !!!\n");
            }
            if (!(startPoint >= 1 & startPoint <= input.GetLength(0)))
            {
                Console.WriteLine("Некоректне число !!!\n");
                findBaseLarg(input, startPoint);
            }

            int baseLarg = findBaseLarg(input, startPoint);
            creatRoad(input, startPoint, baseLarg);
        //    int[] roadX = new int[] { 0, 3, 5, 1, 4, };
        //    int[] roadY = new int[] { 3, 5, 1, 4, 2, };
        
        //stepLerg(input, roadX, roadY);
        }
        public static void creatRoad(int[,]input, int startPoint,int baseLarg)
        {
            List<int> rdX = new List<int>();
            List<int> rdY = new List<int>();
            int countIteration = 0;
            List<string> stepName = new List<string>();
            List<int[]> stepRoad = new List<int[]>();

            if (countIteration == 0)
            {
                rdX.Add((startPoint - 1));
                int i = startPoint - 1;
                    for (int j = 0; j < input.GetLength(0); j++)
                    {
                        if (input[i,j] >0 )
                        {
                            rdY.Add(j);
                            int[] roadX = new int[rdX.Count()];
                            int[] roadY = new int[rdY.Count()];
                            int k = 0;
                            Console.Write("Рядок: ");
                            foreach (var item in rdX)
                            {
                                roadX[k] = item;
                                Console.Write(roadX[k] + "\t");
                                k++;
                                
                            }
                            Console.WriteLine();
                            k = 0;
                            Console.Write("Стовбець: ");
                            foreach (var item in rdY)
                            {
                                roadY[k] = item;
                                Console.Write(roadY[k] + "\t");
                                k++;
                                
                            }
                            Console.WriteLine();

                            if (stepLerg(input,roadX,roadY)<=baseLarg)
                            {
                                Console.WriteLine("Pidhodutb");
                                Console.WriteLine("\n\n");
                            }
                            else
                            {
                                Console.WriteLine("NePidhodutb");
                                Console.WriteLine("\n\n");
                            }

                            
                        }
                        rdY.Clear();
                    }
                
            }
            
        }

        public static int stepLerg(int[,] input, int[] roadX,int[] roadY)
        {
            int[,] tempData = input;
            int[] minj = new int[tempData.GetLength(0)];
            int[] mink = new int[tempData.GetLength(1)];

            int roadL = 0; // Значення для оцінки маршруту
            int rCoef1 = 0; // коуфіцієнт для довжини пройденого шляху
            int rCoef2 = 0;
            int rCoef3 = 0;

            for (int i = 0; i < (roadX.Length); i++)
            {
                rCoef1 += input[roadX[i], roadY[i]];
            }
            Console.WriteLine("rCoef1 " + rCoef1);
            for (int i = 0; i < minj.Length; i++)
            {
                mink[i] = 101;
                minj[i] = 101;
            }


            
                // Пошук мінімума рядка
                for (int j = 0; j < tempData.GetLength(0); j++)
                {
                    for (int k = 0; k < tempData.GetLength(1); k++)
                    {
                            if (!roadX.Contains(j))
                            {
                                if (!roadY.Contains(k))
                                {
                                    if ((tempData[j, k] > 0) && tempData[j, k] < mink[j])
                                    {
                                        mink[j] = tempData[j, k];
                                    }
                                }

                            }
                        
                    }
                }
                for (int k = 0; k < mink.Length; k++)
                {
                    if (mink[k]==101)
                    {
                        mink[k] = 0;
                    }
                    rCoef2 += mink[k];
                }
                Console.WriteLine("rCoef2 " + rCoef2);
                // Віднімання з кожного значення його мінімуми
                for (int j = 0; j < tempData.GetLength(0); j++)
                {
                    for (int k = 0; k < tempData.GetLength(1); k++)
                    {
                        
                            if (!roadX.Contains(j))
                            {
                                if (!roadY.Contains(k))
                                {
                                    if (tempData[j, k] > 0)
                                    {
                                        tempData[j, k] -= mink[j];
                                    }
                                }
                            }
                        
                    }
                }

            Console.WriteLine("\nМінімальні значення в рядку:");
            foreach (var item in mink)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            for (int i = 0; i < tempData.GetLength(0); i++)
            {

                for (int j = 0; j < tempData.GetLength(1); j++)
                    Console.Write(tempData[i, j] + "\t");
                Console.WriteLine();
            }
            // пошук мінімумів стовпця
            for (int j = 0; j < tempData.GetLength(0); j++)
            {
                for (int k = 0; k < tempData.GetLength(1); k++)
                {
                    
                        if (!roadX.Contains(k))
                        {
                            if (!roadY.Contains(j))
                            {
                                if ((tempData[k, j] >= 0) && tempData[k, j] < minj[j])
                                {
                                    minj[j] = tempData[k, j];
                                }
                            }

                        }
                    
                }
            }
            for (int k = 0; k < minj.Length; k++)
            {
                if (minj[k] == 101)
                {
                    minj[k] = 0;
                }
                rCoef3 += minj[k];
            }
            Console.WriteLine("rCoef3 "+ rCoef3);
            Console.WriteLine("\nМінімальні значення в стовбцях:");
            foreach (var item in minj)
            {
                Console.Write(item+"\t");
            }
            Console.WriteLine("\n");

            for (int i = 0; i < tempData.GetLength(0); i++)
            {

                for (int j = 0; j < tempData.GetLength(1); j++)
                    Console.Write(tempData[i, j] + "\t");
                Console.WriteLine();
            }


            roadL = rCoef1 + rCoef2 + rCoef3;

            Console.WriteLine("Довжина пройденого шляху: " + roadL);
            return roadL;
        }

        public static int  roadLength = 0;
        public static int findBaseLarg(int[,] input, int startPoint)
        {
            List<int> visitedPoint = new List<int>();
            visitedPoint.Add(--startPoint);

            while (visitedPoint.Count != input.GetLength(0))
                Step(visitedPoint, input, startPoint);
            if (input[visitedPoint.First(), visitedPoint.Last()] == 0)
            {
                Console.WriteLine("Немає шляху з точки " + (visitedPoint.Last() + 1) + " в " + (visitedPoint.First() + 1));
                Console.WriteLine("\n Результати");
                foreach (var item in visitedPoint)
                {
                    Console.Write((item + 1) + " -> ");
                }
                Console.WriteLine("\nБазова довжина шляху: " + roadLength);
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
                Console.WriteLine("\nБазова довжина шляху: " + roadLength);
            }


            return roadLength;
        }
        public static void Step(List<int> visitedPoint, int[,] input, int startPoint)
        {
            startPoint--;

            int minElement = 99;
            int minI = 0;


            if (visitedPoint.Count == 0)
            {
                for (int i = 0; i < input.GetLength(0); i++)
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
                    if ((input[visitedPoint.Last(), i] > 0 && input[visitedPoint.Last(), i] < minElement) & !visitedPoint.Contains(i))
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
