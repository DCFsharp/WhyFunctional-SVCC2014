using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CSMisc
{
    public static class Extensions
    {
        public static T WithRetry<T>(this Func<T> action)
        {
            var result = default(T);
            int retryCount = 0;

            bool succesful = false;
            do
            {
                System.Console.WriteLine("Retry {0}", retryCount);
                try
                {
                    if (retryCount == 0)
                        throw new Exception("Dummy error");
                    
                    result = action();
                    succesful = true;
                }
                catch (Exception ex)
                {
                    retryCount++;
                }
            } while (retryCount < 3 && !succesful);

            return result;
        }
    }

    public class RetryTest
    {
        public static void ExecuteFileTest()
        {
            // retry is an higerh order function because it takes a function is a parametr
            var filePath = "TextFile.txt";
            Func<string> read = () => System.IO.File.ReadAllText(filePath);
            var text = read.WithRetry();

            Console.WriteLine("Length text {0}", text.Length);
            // what's happend if I have a function that take a parameter ??
        }
    }
}