using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CloseCodeExample codeExample = new CloseCodeExample();

            codeExample.Work("Fun1");

            codeExample.Work2("Fun2");
            codeExample.Work2("Fun3");

            var container = new UnityContainer();

            container.RegisterType<IExampleFunction, ExampleFuction1>("Fun1");
            container.RegisterType<IExampleFunction, ExampleFuction2>("Fun2");
            container.RegisterType<IExampleFunction, ExampleFuction3>("Fun3");


            CloseCodeExample2 codeExample2 = new CloseCodeExample2(container);
                        
            codeExample2.Work("Fun1");
            codeExample2.Work("Fun2");

            Console.WriteLine("---------------------------------");

            codeExample2.Work(new List<string>() { "Fun2", "Fun3", "Fun1" });

            Console.ReadKey();

        }
    }
}
