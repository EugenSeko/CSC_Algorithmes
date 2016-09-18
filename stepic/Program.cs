using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



/*
Задача на программирование повышенной сложности: наибольшая 
невозрастающая подпоследовательность

Дано целое число 1≤n≤10^5 и массив A[1…n], содержащий
неотрицательные целые числа, не превосходящие 10^9. Найдите 
наибольшую невозрастающую подпоследовательность в A. В первой
строке выведите её длину k, во второй — её индексы
1≤i1<i2<…<ik≤n (таким образом, A[i1]≥A[i2]≥…≥A[in]).

Sample Input:
5
5 3 4 4 2
Sample Output:
4
1 3 4 5 
 */
namespace stepic
{
    public class MainClass
    {

        public static void Main(String[] args)
        {
            // input
            int n = Convert.ToInt32(Console.ReadLine());
            string[] s = Console.ReadLine().Split(' ');
            int[] A = new int[n];
            int[] Out;

            for (int i = 0; i < n; i++)
            {
                A[i] = Convert.ToInt32(s[i]);
            }
            // prog
            int[] D = new int[n + 1];
            int[] I = new int[n];
            int max = -1;
            int index = -1;
            D[0] = Int32.MaxValue;
            for (int i = 1; i < D.Length; i++)
            {
                D[i] = -1;
            }
            for (int i = 0; i < n; i++)
            {
                int j = DownBound(D, A[i]);
                if (A[i] > D[j] && A[i] <= D[j - 1])
                {
                    D[j] = A[i];
                    I[i] = j;
                    if (j > max)
                    {
                        max = j;
                        index = i;
                    }
                }
            }
            // output
            int[] _out = new int[index];
            for (int i = 0; i < _out.Length; i++)
            {
                _out[i] = -1;
            }
            int ind = 0;
            _out[ind] = index;
            for (int i = index; i > -1; i--)
            {
                if (I[index] - I[i] == 1 && A[index] <= A[i])
                {
                    _out[++ind] = i;
                    index = i;
                }
            }
            Console.WriteLine((max + 1));
            for (int i = _out.Length - 1; i >= 0; i--)
            {
                if (_out[i] != -1) Console.Write((_out[i] + 1) + " ");
            }
            Console.ReadKey();
        }

        static int DownBound(int[] A, int a)
        {
            int l = 0;
            int r = A.Length - 1;

            while (l != r)
            {
                int m = l + ((r - l) / 2);
                if (a > A[m])
                {
                    r = m;
                }
                if (a <= A[m])
                {
                    l = m + 1;
                }
            }
            return l;
        }
    }
}
