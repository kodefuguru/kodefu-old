namespace CommandPattern
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            var results = command.Execute().Results;
            Console.WriteLine(results);

            bool condition = false;
            DelegateCommand delegateCommand = new DelegateCommand(() => Console.WriteLine("Hello World!"), () => condition);
            delegateCommand.Execute();
            condition = true;
            delegateCommand.Execute();
        }

        
    }
}
