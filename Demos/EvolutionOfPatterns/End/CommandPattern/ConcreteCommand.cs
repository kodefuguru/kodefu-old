namespace CommandPattern
{
    class ConcreteCommand : Command
    {
        private string results;

        public ConcreteCommand(Receiver receiver) : base(receiver)
        {
        }

        public override string Results
        {
            get
            {
                return results;
            }
        }

        public override Command Execute()
        {
            results = receiver.GetData();
            
            return this;
        }
    }
}