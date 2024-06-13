using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bai_2_lab_8
{
    internal class Program
    {
        class Program
        {
            static object lock1 = new object();
            static object lock2 = new object();

            static void Thread1FunctionLab8()
            {
                bool lock1Acquired = false;
                bool lock2Acquired = false;

                try
                {
                  
                    lock1Acquired = Monitor.TryEnter(lock1, TimeSpan.FromMilliseconds(1000));
                    if (lock1Acquired)
                    {
                        Debug.Log("Thread 1 locked lock1");

                        Thread.Sleep(100);
                        Debug.Log("Thread 1 is waiting for lock2");

                        
                        lock2Acquired = Monitor.TryEnter(lock2, TimeSpan.FromMilliseconds(1000));
                        if (lock2Acquired)
                        {
                            Debug.Log("Thread 1 locked lock2");
                        }
                        else
                        {
                            Debug.Log("Thread 1 could not lock lock2");
                        }
                    }
                    else
                    {
                        Debug.Log("Thread 1 could not lock lock1");
                    }
                }
                finally
                {
             
                    if (lock2Acquired) Monitor.Exit(lock2);
                    if (lock1Acquired) Monitor.Exit(lock1);
                }
            }

            static void Thread2FunctionLab8()
            {
                bool lock1Acquired = false;
                bool lock2Acquired = false;

                try
                {
              
                    lock2Acquired = Monitor.TryEnter(lock2, TimeSpan.FromMilliseconds(1000));
                    if (lock2Acquired)
                    {
                        Debug.Log("Thread 2 locked lock2");

                        Thread.Sleep(100);
                        Debug.Log("Thread 2 is waiting for lock1");

                   
                        lock1Acquired = Monitor.TryEnter(lock1, TimeSpan.FromMilliseconds(1000));
                        if (lock1Acquired)
                        {
                            Debug.Log("Thread 2 locked lock1");
                        }
                        else
                        {
                            Debug.Log("Thread 2 could not lock lock1");
                        }
                    }
                    else
                    {
                        Debug.Log("Thread 2 could not lock lock2");
                    }
                }
                finally
                {
              
                    if (lock1Acquired) Monitor.Exit(lock1);
                    if (lock2Acquired) Monitor.Exit(lock2);
                }
            }

            public static void bai2()
            {
                Thread thread1 = new Thread(Thread1FunctionLab8);
                Thread thread2 = new Thread(Thread2FunctionLab8);

                thread1.Start();
                thread2.Start();
                thread1.Join();
                thread2.Join();
                Debug.Log("end start");
            }

            static void Main(string[] args)
            {
                bai2();
            }
        }
    }
}
