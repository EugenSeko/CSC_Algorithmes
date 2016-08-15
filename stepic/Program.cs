using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



/*
 Первая строка содержит число  1≤n≤10^4, вторая — n натуральных чисел,
 не превышающих 10. 
 Выведите упорядоченную по неубыванию последовательность этих чисел.
 */

namespace stepic
{
    public class MainClass
    {
       
        public static void Main(String[] args)
        {

             int n =Convert.ToInt32(Console.ReadLine());
             string s = Console.ReadLine();

             int[] A = new int[n];

             string[] S = s.Split(' ');
             for (int i = 0; i < n; i++)
             {
                 A[i] = Convert.ToInt32(S[i]);
             } 

            A = CountSort(A);
            for (int i = 0; i < n; i++)
            {
                Console.Write(A[i] + " ");
            }
            
           

            Console.ReadKey();
        }
        public static int[] CountSort(int[] A)
        {
            int[] B = new int[10];
            int[] Asort = new int[A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                B[A[i]]++;
            }
            for (int i = 1; i < B.Length; i++)
            {
                B[i] = B[i] + B[i - 1];
            }
            for (int i = A.Length-1; i > -1; i--)
            {
                Asort[B[A[i]]-1] = A[i];
                B[A[i]] -= 1; 
            }
            return Asort;
        }

    }
}
