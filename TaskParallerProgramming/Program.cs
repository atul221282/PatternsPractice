using System;
using System.Linq;
using System.Threading.Tasks;

namespace TaskParallerProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            TaskScheduler.UnobservedTaskException += new EventHandler<UnobservedTaskExceptionEventArgs>(TaskUnobservedException_Handler);

            TestMethod();

            Console.ReadLine();
        }

        private static void TaskUnobservedException_Handler(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
            e.SetObserved();
        }

        private static Task<int> TestMethod()
        {
            Task<int> x = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var gg = DateTime.Now.ToString("dd-MMM-yyyy");
                }
                int x2 = 0;
                int y2 = 1110;
                var gg2 = y2 / x2;
                return 5;
            });

            Task<int> y = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var gg = DateTime.Now.ToString("dd-MMM-yyyy");
                }

                return 0;
            });

            Task<int> z = Task.Factory.StartNew(() =>
            {
                return x.Result / y.Result;
            });

            var pp = new Task<int>[] { y, x, z };

            while (pp.Length > 0)
            {
                int index = Task.WaitAny(pp);
                var finishedTask = pp[index];
                if (finishedTask.Exception == null)
                    return finishedTask;

                pp = pp.Where(t => t != finishedTask).ToArray();
            }

            throw new InvalidOperationException("All tasks failed");
        }

        private static int Subtract(int x, int y)
        {
            return x - y;
        }

        private static int Add(int x, int y)
        {
            return x + y;
        }

    }
}