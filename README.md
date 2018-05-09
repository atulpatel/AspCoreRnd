# AspCoreRnd

As a developer, you should know SOLID principles.



We all know them  SOLID principles.  Every developer knows what they are because every developer has to go through an interview process to get a job. Some can explain really good while interview.



Recently, I have been interviewed by a very reputed financial company.  They have 4 rounds of interview and almost 3 round has asked a question about SOLID principles. They all have asked very good interesting questions as it seems they were looking for some specific expertise. I have started working there and their code base is awesome. They are not working anywhere near what they asked in an interview. I also found some controllers code file has 2-3k  lines of code which is a presentation layer which serves data to UI. Though they have very nice onion architecture for the project. I hope whoever worked there all gone through those interview process and know about at least SOLID principles. These principles are not just to perform in the interview. We need to apply it in real code. Maybe they have their own reasons for not following them.



Anyway, here I wanted to show some example which I saw in their code base which can very easily make it closed for modification.



Check following code.



       

      public void Work(string switchoption)
        {
            switch (switchoption)
            {
                case "Fun1":
                    ///
                    /// So many lines of code
                    ///
                    break;
                case "Fun2":
                    ///
                    /// So many lines of code
                    ///
                    break;
                case "Fun3":
                    ///
                    /// So many lines of code
                    ///
                    break;
            }
        }





If you come across this kind of code or you may endup writing this kind of code then what at least should be done.  Above code is not closed because you don't know what kind of another case may arrive in future. What if a change in code for a particular case. You have to test all cases as you changed it the function. QA has to check every case. If something missed in testing then you may end up production bugs. Overall you are increasing the maintenance cost.



I do refactor it to the following levels.



At least have a private function for long lines of code for each case.



 public void Work(string switchoption)
        {
            switch (switchoption)
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







If you create private function then the code will at least increase readability.  By giving a proper name to function,  it describes that what that piece of code is doing. But still, it has an issue of what if we may need to write more cases there. This code is still not a closed code.



Instead of Switch case, you can implement Dictionary for the case.



    

        public void Work2(string switchoption)
        {
            Dictionary<string, Action> switchfunction = new Dictionary<string, Action>();
            switchfunction.Add("Fun1", function1);
            switchfunction.Add("Fun2", function2);
            switchfunction.Add("Fun3", function3);

            switchfunction[switchoption].Invoke();
        }




You can simply add a dictionary with string and Action type. Add all functions to dictionary collection.  Dictionary can pick a particular case by Key name and execute the function by invoking it. You can also generate this dictionary list from outside function and get it from any data store.  In case in future, you may need to add more cases then you don't have to change this function.  This way your existing function Work2 here in the example can be closed for modification.



This implementation has resolved our problem of closing the function "Work" for modification.  But we still have to add a new function to the class for adding new cases. It is also not following Single responsibility principle.



Implement Strategy pattern using Dependency Injection
Basic strategy pattern implementation explained here. http://www.dofactory.com/net/strategy-design-pattern



We can do it better way using dependency injection framework.   Nowadays everybody uses it as the so-called best practices.






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







Example work function.




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













  class Program
    {
        static void Main(string[] args)
        {
   
            

            //Container registration

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
