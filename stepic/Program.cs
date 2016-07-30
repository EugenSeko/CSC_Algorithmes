using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



/*
 В первой строке задано два целых числа 1≤n≤50000 и 1≤m≤50000 — количество отрезков и точек на прямой,
 * соответственно. Следующие n строк содержат по два целых числа ai и bi (ai≤bi) — координаты концов 
 * отрезков. Последняя строка содержит m целых чисел — координаты точек. Все координаты не превышают 10^8 
 * по модулю. Точка считается принадлежащей отрезку, если она находится внутри него или на границе. Для
 * каждой точки в порядке появления во вводе выведите, скольким отрезкам она принадлежит.
 */

namespace stepic
{
   public class MainClass
    {
       static int index;  // counter for binarySearch
       static bool tail; // switch for quickSearch


      public  static void Main(String[] args)
        {
            //  int ntest = 50000;
            //  int mtest = 50000;
            // Test1(1, ntest, mtest, true);
            //  Test2(1, ntest, mtest, true);
            //  Test3(1, ntest, mtest, true);

            Test(100, (int)1E6, 1000, true,false);
            Test(100, (int)1E6, 1000, false,false);MainClass.tail = true;
            Test(100, (int)1E6, 1000, true, false);
            Test(100, (int)1E6, 1000, false, false);




            Console.ReadKey();

            int n, m;
 //start input
            string s = Console.ReadLine();
            string[] sep = s.Split(' ');
            n = Int32.Parse(sep[0]);
            m = Int32.Parse(sep[1]);

            int[] A = new int[n];
            int[] B = new int[n];
            int[] M = new int[m];

            for (int i = 0; i < n; i++)
            {
                s = Console.ReadLine();
                sep = s.Split(' ');
                A[i] = Int32.Parse(sep[0]);
                B[i] = Int32.Parse(sep[1]);
            }
            s = Console.ReadLine();
            sep = s.Split(' ');
            for (int i = 0; i < m; i++)
            {
                M[i] = Int32.Parse(sep[i]);
            }
 //end input
 //start body and output
            int a, b;
            quicksort(A, 0, A.Length - 1);
            quicksort(B, 0, B.Length - 1);
            for (int i = 0; i < M.Length; i++)
            {
                binarySearch(M[i], A, 0, A.Length);
                a = index;
                binarySearchB(M[i], B, 0, B.Length);
                b = index;

                Console.Write((a - b) + " ");

            }
                Console.ReadKey();
    }



    static void quicksort(int[] A, int l, int r)
        {
            int[] m;
            if (!tail)
            {
                if (l >= r)
                {
                    return;
                }
                m = partition(A, l, r);
                quicksort(A, l, m[0] - 1);
                quicksort(A, m[1] + 1, r);
            }
            if (tail) {
                while (l < r){
                m = partition(A, l, r);
                quicksort(A, l, m[0] - 1);
                l = m[1] + 1;
                }
            }     
        }
 
    static int[] partition(int[] A, int l, int r)
        {
            int[]_out= new int[2];    // 0-left,1-right
            Random random = new Random();
            int rand = random.Next(l, r);
            int temp;
            temp = A[l];
            A[l] = A[rand];
            A[rand] = temp;
            
            int p = A[l];
            int j = l;
            int eq = l;
            
   
            for (int i = l + 1; i < r +1; i++)
            {
                if (A[i] <= p)
                {
                    j++;
                    temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                }

            }
                temp = A[l];
                A[l] = A[j];
                A[j] = temp;
            _out[1] = j;

            for (int i = l; i < j; i++)
            {
                if (A[i] == p)
                {
                    j--;
                    temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                }
            }
            _out[0] = j;

            return _out;
        }

    static void binarySearch(int point,int[]array,int l,int r)
        {
            int m = l + ((r - l) / 2);
            if (l >= r) {
                 if (r == array.Length - 1 && array[r]<point)
                 {
                     index = r + 1;
                     return;
                 }
                 else
                 {
                 index = r;
                 return;
                 }
                 
             }

             if (point < array[m]) binarySearch(point, array, l, m);
             if (point >= array[m]) binarySearch(point, array, m + 1, r);
         }

    static void binarySearchB(int point, int[] array, int l, int r)
    {
        int m = l + ((r - l) / 2);
        if (l == r)
        {
            if (r == array.Length - 1 && array[r] < point)
            {
                index = r+1;
                return;
            }
            else
            {
                index = r;
                return;
            }

        }

        if (point <= array[m]) binarySearchB(point, array, l, m);
        if (point > array[m]) binarySearchB(point, array, m + 1, r);
    }

        // TESTS // // // //

        static void Test(int times, int n,int max_val,bool is_random, bool write_res)
        {
            Stopwatch sw_run = new Stopwatch();

            for (int t = 0; t < times; t++){
                int[] Atest = new int[n];
                if (is_random) {
                    Random random = new Random();
                          for (int i = 0; i < n; i++)
                          {
                           Atest[i] = random.Next(0, max_val);
                           }
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        Atest[i] =  max_val;
                    }
                } 
                    
                sw_run.Start();
                quicksort(Atest, 0, Atest.Length - 1);
                sw_run.Stop();
                if (write_res){
                   foreach (int res in Atest){
                    Console.Write(res + " ");
                   }
                }
                
           }

            TimeSpan ts_run = sw_run.Elapsed;
            string runElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_run.Minutes, ts_run.Seconds, ts_run.Milliseconds);

            Console.WriteLine("");
            if(is_random)
            Console.WriteLine(" Test  (quickSearch,random data) ");
            else Console.WriteLine(" Test  (quickSearch, max data) ");
            Console.WriteLine("");
            Console.WriteLine(" Iterration       " + times);
            Console.WriteLine(" Lenght           " + n);
            Console.WriteLine(" max value        " + max_val);
            Console.WriteLine(" Run Elapsed Time " + runElapsedTime);
        }

        /*
            static void Test1(int times,int n,int m, bool mute)
         {
             Stopwatch sw_input = new Stopwatch();
             Stopwatch sw_output = new Stopwatch();
             Stopwatch sw_run = new Stopwatch();
             Stopwatch sw_total = new Stopwatch();

        sw_total.Start();
                    for (int t = 0; t < times; t++)
                    {
        sw_input.Start();
                    Random random = new Random();
                   int[]  Atest = new int[n];
                   int[]  Btest = new int[n];
                   int[]  Mtest = new int[m];

                    Atest[0]= -2147483648;
                    Btest[0]= -2147483648;

                    for (int i =1 ; i < n; i++)
                    {
                        Atest[i] = random.Next(0, (int)Math.Pow(10, 8));
                        Btest[i] = random.Next(Atest[i], (int)Math.Pow(10, 8));
                    }
                    for (int i = 0; i < m; i++)
                    {
                        Mtest[i] = random.Next(0, (int)Math.Pow(10, 8));
                    }
        sw_input.Stop();
        sw_run.Start();
                    int[,] Atree = Function(Mtest, Atest);
                    int[,] Btree = Function(Mtest, Btest);
                    int a_points, b_points_wa_overlaps;
        sw_run.Stop();
        sw_output.Start();
                    for (int i = 0; i < m; i++)
                    {
                        a_points = Atree[i, 7];
                        b_points_wa_overlaps = Btree[i, 7] - Btree[i, 0];
                      if(!mute)  Console.Write((a_points - b_points_wa_overlaps) + " ");
                    }
        sw_output.Stop();
                    }
        sw_total.Stop();

                  TimeSpan ts_input = sw_input.Elapsed;
                  TimeSpan ts_output = sw_output.Elapsed;
                  TimeSpan ts_run = sw_run.Elapsed;
                  TimeSpan ts_total = sw_total.Elapsed;

                  string inputElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_input.Minutes, ts_input.Seconds, ts_input.Milliseconds);
                  string runElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_run.Minutes, ts_run.Seconds, ts_run.Milliseconds);
                  string outputElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_output.Minutes, ts_output.Seconds, ts_output.Milliseconds);
                  string totalElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_total.Minutes, ts_total.Seconds, ts_total.Milliseconds);
                    Console.WriteLine("");
                    Console.WriteLine(" Test 1 (my method,random data) ");
                    Console.WriteLine(" Iterration          " + times );
                    Console.WriteLine(" Input Elapsed Time  " + inputElapsedTime);
                    Console.WriteLine(" Run Elapsed Time    " + runElapsedTime);
                    Console.WriteLine(" Output Elapsed Time " + outputElapsedTime);
                    Console.WriteLine(" Total Elapsed Time  " + totalElapsedTime);


                    double run =   ts_run.TotalMilliseconds;
                    double outp =  ts_output.TotalMilliseconds;
                    double inp =   ts_input.TotalMilliseconds;
                    double total = ts_total.TotalMilliseconds;

                    Console.WriteLine(" Input  " + ((inp / total) * 100) + " %");
                    Console.WriteLine(" Run    " + ((run / total) * 100) + " %");
                    Console.WriteLine(" Output " + ((outp /total) * 100) + " %");   
                }

            static void Test2(int times, int n, int m, bool mute)
            {
                Stopwatch sw_input = new Stopwatch();
                Stopwatch sw_output = new Stopwatch();
                Stopwatch sw_run = new Stopwatch();
                Stopwatch sw_total = new Stopwatch();

                sw_total.Start();
                for (int t = 0; t < times; t++)
                {
                    sw_input.Start();
                    int[] Atest = new int[n];
                    int[] Btest = new int[n];
                    int[] Mtest = new int[m];

                    Atest[0] = -2147483648;
                    Btest[0] = -2147483648;

                    for (int i = 1; i < n; i++)
                    {
                        Atest[i] = (int)Math.Pow(10, 8);
                        Btest[i] = (int)Math.Pow(10, 8);
                    }
                    for (int i = 0; i < m; i++)
                    {
                        Mtest[i] = (int)Math.Pow(10, 8);
                    }
                    sw_input.Stop();
                    sw_run.Start();
                    int[,] Atree = Function(Mtest, Atest);
                    int[,] Btree = Function(Mtest, Btest);
                    int a_points, b_points_wa_overlaps;
                    sw_run.Stop();
                    sw_output.Start();
                    for (int i = 0; i < m; i++)
                    {
                        a_points = Atree[i, 7];
                        b_points_wa_overlaps = Btree[i, 7] - Btree[i, 0];
                       if(!mute) Console.Write((a_points - b_points_wa_overlaps) + " ");
                    }
                    sw_output.Stop();
                }
                sw_total.Stop();

                TimeSpan ts_input = sw_input.Elapsed;
                TimeSpan ts_output = sw_output.Elapsed;
                TimeSpan ts_run = sw_run.Elapsed;
                TimeSpan ts_total = sw_total.Elapsed;

                string inputElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_input.Minutes, ts_input.Seconds, ts_input.Milliseconds);
                string runElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_run.Minutes, ts_run.Seconds, ts_run.Milliseconds);
                string outputElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_output.Minutes, ts_output.Seconds, ts_output.Milliseconds);
                string totalElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_total.Minutes, ts_total.Seconds, ts_total.Milliseconds);
                Console.WriteLine("");
                Console.WriteLine(" Test 2 (my method,max constant data)");
                Console.WriteLine(" Iterration          " + times);
                Console.WriteLine(" Input Elapsed Time  " + inputElapsedTime);
                Console.WriteLine(" Run Elapsed Time    " + runElapsedTime);
                Console.WriteLine(" Output Elapsed Time " + outputElapsedTime);
                Console.WriteLine(" Total Elapsed Time  " + totalElapsedTime);

                double run = ts_run.TotalMilliseconds;
                double outp = ts_output.TotalMilliseconds;
                double inp = ts_input.TotalMilliseconds;
                double total = ts_total.TotalMilliseconds;

                Console.WriteLine(" Input  " + ((inp / total) * 100) + " %");
                Console.WriteLine(" Run    " + ((run / total) * 100) + " %");
                Console.WriteLine(" Output " + ((outp / total) * 100) + " %");
            }

            static void Test3(int times, int n, int m, bool mute)
            {
                Stopwatch sw_input = new Stopwatch();
                Stopwatch sw_output = new Stopwatch();
                Stopwatch sw_run = new Stopwatch();
                Stopwatch sw_total = new Stopwatch();

                sw_total.Start();
                for (int t = 0; t < times; t++)
                {
                        Random random = new Random();
                    sw_input.Start();
                    int[] Atest = new int[n];
                    int[] Btest = new int[n];
                    int[] Mtest = new int[m];

                  //  Atest[0] = -2147483648;
                   // Btest[0] = -2147483648;

                    for (int i = 0; i < n; i++)
                    {
                        Atest[i] = random.Next(0, (int)Math.Pow(10,8));
                        Btest[i] = random.Next(0, (int)Math.Pow(10, 8));
                        }
                    for (int i = 0; i < m; i++)
                    {
                        Mtest[i] = random.Next(0, (int)Math.Pow(10, 8));
                        }
                    sw_input.Stop();
                    sw_run.Start();

                    quicksort(Atest, 0, Atest.Length - 1);
                    quicksort(Btest, 0, Btest.Length - 1);
           sw_run.Stop();
           sw_output.Start();
                        int a, b;
                        for (int i = 0; i < Mtest.Length; i++)
                        {
                            binarySearch(Mtest[i], Atest, 0, Atest.Length);
                            a = index;
                            binarySearchB(Mtest[i], Btest, 0, Btest.Length);
                            b = index;

                            if (!mute) Console.Write((a - b) + " ");

                        }
           sw_output.Stop();



                }
                sw_total.Stop();

                TimeSpan ts_input = sw_input.Elapsed;
                TimeSpan ts_output = sw_output.Elapsed;
                TimeSpan ts_run = sw_run.Elapsed;
                TimeSpan ts_total = sw_total.Elapsed;

                string inputElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_input.Minutes, ts_input.Seconds, ts_input.Milliseconds);
                string runElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_run.Minutes, ts_run.Seconds, ts_run.Milliseconds);
                string outputElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_output.Minutes, ts_output.Seconds, ts_output.Milliseconds);
                string totalElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_total.Minutes, ts_total.Seconds, ts_total.Milliseconds);
                Console.WriteLine("");
                Console.WriteLine(" Test 3  (bynary,random data) ");
                Console.WriteLine(" Iterration          " + times);
                Console.WriteLine(" Input Elapsed Time  " + inputElapsedTime);
                Console.WriteLine(" Run Elapsed Time    " + runElapsedTime);
                Console.WriteLine(" Output Elapsed Time " + outputElapsedTime);
                Console.WriteLine(" Total Elapsed Time  " + totalElapsedTime);

                double run = ts_run.TotalMilliseconds;
                double outp = ts_output.TotalMilliseconds;
                double inp = ts_input.TotalMilliseconds;
                double total = ts_total.TotalMilliseconds;

                Console.WriteLine(" Input  " + ((inp / total) * 100) + " %");
                Console.WriteLine(" Run    " + ((run / total) * 100) + " %");
                Console.WriteLine(" Output " + ((outp / total) * 100) + " %");
            }

            static void Test4(int times, int n, int m, bool mute)
                {
                    Stopwatch sw_input = new Stopwatch();
                    Stopwatch sw_output = new Stopwatch();
                    Stopwatch sw_run = new Stopwatch();
                    Stopwatch sw_total = new Stopwatch();

                    sw_total.Start();
                    for (int t = 0; t < times; t++)
                    {
                        Random random = new Random();
                        sw_input.Start();
                        int[] Atest = new int[n];
                        int[] Btest = new int[n];
                        int[] Mtest = new int[m];

                        //  Atest[0] = -2147483648;
                        // Btest[0] = -2147483648;

                        for (int i = 0; i < n; i++)
                        {
                            Atest[i] = (int)Math.Pow(10, 8);
                            Btest[i] = (int)Math.Pow(10, 8);
                        }
                        for (int i = 0; i < m; i++)
                        {
                            Mtest[i] = (int)Math.Pow(10, 8);
                        }
                        sw_input.Stop();
                        sw_run.Start();

                        quicksort(Atest, 0, Atest.Length - 1);
                        quicksort(Btest, 0, Btest.Length - 1);
                        sw_run.Stop();
                        sw_output.Start();
                         int a, b;
                        for (int i = 0; i < Mtest.Length; i++)
                        {
                            binarySearch(Mtest[i], Atest, 0, Atest.Length);
                            a = index;
                            binarySearchB(Mtest[i], Btest, 0, Btest.Length);
                            b = index;

                            if (!mute) Console.Write((a-b) + " ");

                        }
                        sw_output.Stop();



                    }
                    sw_total.Stop();

                    TimeSpan ts_input = sw_input.Elapsed;
                    TimeSpan ts_output = sw_output.Elapsed;
                    TimeSpan ts_run = sw_run.Elapsed;
                    TimeSpan ts_total = sw_total.Elapsed;

                    string inputElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_input.Minutes, ts_input.Seconds, ts_input.Milliseconds);
                    string runElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_run.Minutes, ts_run.Seconds, ts_run.Milliseconds);
                    string outputElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_output.Minutes, ts_output.Seconds, ts_output.Milliseconds);
                    string totalElapsedTime = string.Format("{0:00}:{1:00}:{2:000}", ts_total.Minutes, ts_total.Seconds, ts_total.Milliseconds);
                    Console.WriteLine("");
                    Console.WriteLine(" Test 3  (bynary,max data) ");
                    Console.WriteLine(" Iterration          " + times);
                    Console.WriteLine(" Input Elapsed Time  " + inputElapsedTime);
                    Console.WriteLine(" Run Elapsed Time    " + runElapsedTime);
                    Console.WriteLine(" Output Elapsed Time " + outputElapsedTime);
                    Console.WriteLine(" Total Elapsed Time  " + totalElapsedTime);

                    double run = ts_run.TotalMilliseconds;
                    double outp = ts_output.TotalMilliseconds;
                    double inp = ts_input.TotalMilliseconds;
                    double total = ts_total.TotalMilliseconds;

                    Console.WriteLine(" Input  " + ((inp / total) * 100) + " %");
                    Console.WriteLine(" Run    " + ((run / total) * 100) + " %");
                    Console.WriteLine(" Output " + ((outp / total) * 100) + " %");
                }


                */

    }
}
