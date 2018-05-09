using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace TestConsoleApp
{

    public interface IExampleFunction
    {
        void functionexample();
    }


    public class ExampleFuction1 : IExampleFunction
    {
        public void functionexample()
        {
            Console.WriteLine("ExampleFuction1.functionexample()  executed.");
        }

    }

    public class ExampleFuction2 : IExampleFunction
    {
        public void functionexample()
        {
            Console.WriteLine("ExampleFuction2.functionexample()  executed.");
        }

    }

    public class ExampleFuction3 : IExampleFunction
    {
        public void functionexample()
        {
            Console.WriteLine("ExampleFuction3.functionexample()  executed.");
        }

    }

    public class CloseCodeExample2
    {
        private readonly IUnityContainer _container;

        public CloseCodeExample2(IUnityContainer container)
        {
            _container = container;
        }

        public void Work(string switchcall)
        {
            var examplefunction= _container.Resolve<IExampleFunction>(switchcall);

            examplefunction.functionexample();
        }

        public void Work(List<string> switchcalls)
        {
            foreach (var item in switchcalls)
            {
                var examplefunction = _container.Resolve<IExampleFunction>(item);

                examplefunction.functionexample();
            }
            
        }
    }
}
