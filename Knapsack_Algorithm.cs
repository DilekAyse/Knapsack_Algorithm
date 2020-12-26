using System;
namespace ConsoleApp2
{
    class Optimization
    {

        // returns max of two integers 
        static int Max(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else
                return num2;
        }

        // returns max values in knapsack
        static int SirtCantasi(int W, int[] weight, int[] value, int n)
        {
            int i, w;
            int[,] TotalValue = new int[n + 1, W + 1]; 

            // bottom up approach        
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        TotalValue[i, w] = 0;
                    else if (weight[i - 1] <= w)
                        TotalValue[i, w] = Math.Max(value[i - 1]
                               + TotalValue[i - 1, w - weight[i - 1]], TotalValue[i - 1, w]);
                    else
                        TotalValue[i, w] = TotalValue[i - 1, w];
                }
            }

            return TotalValue[n, W];
        }

        // entry point
        static void Main()
        {
            int a = 1;
            while ( a == 1)
            {
                int x = 0;
                Console.Write("Kaç adet value değeri bulunacak..: ");
                x = Convert.ToInt32(Console.ReadLine());
                int[] Values = new int[x];

                for (int z = 0; z < x; z++)
                {
                    Console.Write("Value Değerlerini Giriniz...: ");
                    Values[z] = Convert.ToInt32(Console.ReadLine());
                }

                // int[] Values = new int[] { 1, 3, 4, 5, 6};
                //int[] Weights = new int[] { 2, 1, 3, 2 };

                int k = 0;
                Console.Write(Environment.NewLine + "Kaç adet weight değeri bulunacak..: ");
                k = Convert.ToInt32(Console.ReadLine());
                int[] Weights = new int[k];

                for (int j = 0; j < k; j++)
                {
                    Console.Write("Weight Değerlerini Giriniz : ");
                    Weights[j] = Convert.ToInt32(Console.ReadLine());
                }

                Console.Write(Environment.NewLine + "Limit değerini giriniz..: ");

                int limit = Convert.ToInt32(Console.ReadLine());
                int n = Weights.Length;

                Console.WriteLine("Total value: {0}", SirtCantasi(limit, Weights, Values, n));
               


                Console.Write("Başka bir işlem yapacak mısınız?(1/0)...: ");
                a = Convert.ToInt32(Console.ReadLine());
            }
              
            
        }
    }
}

