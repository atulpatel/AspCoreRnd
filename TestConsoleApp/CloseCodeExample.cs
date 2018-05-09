using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public class CloseCodeExample
    {
        public void Work(string switchcall)
        {
            switch (switchcall)
            {
                case "Fun1":
                    function1();
                    break;
                case "Fun2":
                    function2();
                    break;
                case "Fun3":
                    function3();
                    break;
            }
        }

        public void Work2(string switchcall)
        {
            Dictionary<string, Action> switchfunction = new Dictionary<string, Action>();
            switchfunction.Add("Fun1", function1);
            switchfunction.Add("Fun2", function2);
            switchfunction.Add("Fun3", function3);

            switchfunction[switchcall].Invoke();
        }


        public void Work3(string switchcall)
        {
            Dictionary<string, Action> switchfunction = new Dictionary<string, Action>();
            switchfunction.Add("Fun1", function1);
            switchfunction.Add("Fun2", function2);
            switchfunction.Add("Fun3", function3);

            switchfunction[switchcall].Invoke();
        }

        private void function3()
        {
            Console.WriteLine("Function 3");
        }

        private void function2()
        {
            Console.WriteLine("Function 2");
        }

        private void function1()
        {
            Console.WriteLine("Function 1");
        }


    }

}
