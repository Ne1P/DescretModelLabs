using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescretModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            chengLabs();

            Console.ReadKey();
        }

        static void chengLabs()
        {
            Console.WriteLine("Привіт! Яку лабораторну ви хочете обрати:\n\n" +
                "1) Побудова мінімального остового дерева;\n"+
                "2) Задача листоноші;\n"+
                "3) Задача комівояжера;\n"+
                "4) Потокові алгоритми\n"+
                "5) Ізоморфізм графів\n");

            Console.WriteLine("Введіть цифру від 1 до 5.");

            int temp = 0;


            try
            {
                temp = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Буковки не підходять !!!\n");
            }
            
            switch (temp)
            {
                    case 1:
                        Console.WriteLine("1) Побудова мінімального остового дерева\n");
                        KruskalAlgoritm.kruskalMain();
                        break;
                    case 2:
                        Console.WriteLine("2) Задача листоноші\n");
                        PostmenAlgoritm.PostmenMain();
                        break;
                    case 3:
                        Console.WriteLine("3) Задача комівояжера\n");
                        KommviagerAlgoritm.kommviagerAlgoritm();
                        break;
                    case 4:
                        Console.WriteLine("4) Потокові алгоритми\n");
                        break;
                    case 5:
                        Console.WriteLine("5) ////\n");
                        break;
                    default:
                        Console.WriteLine("Введено некоректне значення, повторіть спробу!\n");
                        chengLabs();
                        break;
            }
        }
    }
}
