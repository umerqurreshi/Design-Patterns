using System;

namespace SingletonDesignPattern // Use Singleton when you have logic which is used by several classes
                                 // e.g. error logging. A SINGLE instance of this class is created
{
    class Program
    {
        static void Main(string[] args)
        {
            Log instance = Log.Instance;
            Log instance2 = Log.Instance; // Only SINGLE instance will be created....proof below

            // Note how both names will be Mark - proving that we only ever have a single instance 
            // of the Singleton class. 
            instance.Name = "Tim";
            instance2.Name = "Mark";

            Console.WriteLine($"{instance2.Name} {instance.Name}");

            // After we create the instance, we can call the methods in the Singleton class
            instance.LogError("Let's pretend this is an error");
        }
    }

    public sealed class Log
    {
        // A private static instance of the same class
        // .NET guarantees thread safety for static initialization
        private static readonly Log instance = new Log();
        public string Name { get; set; }

        // A private constructor to restrict the object creation from outside
        private Log()
        {

        }

        public static Log Instance
        {
            get
            {
                return instance;
            }
        }

        public void LogError(string error)
        {
            //Trace.TraceError(error); // Configure trace listener in web.config for live apps
            //For this example let's just use console to log
            Console.WriteLine(error);
        }

        public void LogError(Exception ex)
        {
            //Trace.TraceError(ex.ToString());
            Console.WriteLine(ex);
        }
    }
}
