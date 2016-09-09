using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



/*
Задача на программирование: наибольшая последовательнократная подпоследовательность

Дано целое число 1≤n≤10^3 и массив A[1…n] натуральных чисел, не превосходящих
2⋅10^9. Выведите максимальное 1≤k≤n, для которого найдётся подпоследовательность
1≤i1<i2<…<ik≤n длины k, в которой каждый элемент делится на предыдущий 
(формально: для  всех 1≤j<k, A[ij]|A[ij+1] ).

Sample Input:
4
3 6 7 12
Sample Output:
3
 */
namespace stepic
{
    public class MainClass
    {
       
        public static void Main(String[] args)
        {

            int n = Convert.ToInt32(Console.ReadLine());
            string[] s = Console.ReadLine().Split(' ');
            int[] A = new int[n];
            for (int i = 0; i < n; i++)
            {
                A[i]=Convert.ToInt32(s[i]);
            }

            int[] D=new int[n];
            int max=-1;
            int index = -1;

            for (int i = 0; i < n; i++)
            {
                D[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (A[i] % A[j] == 0 && D[j]>=D[i])
                    {
                        D[i]++;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (D[i] > max)
                {
                    max = D[i];
                    index = i;
                }
            }
            Console.WriteLine(max);
           // Console.WriteLine(index);

            Console.ReadKey();
        }

    }
}
