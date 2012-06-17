namespace CommandPattern
{
    abstract class Command
    {
        protected Receiver receiver;
  
        public Command(Receiver receiver)
   
        {
            this.receiver = receiver;
        }

        public abstract string Results { get; }

        public abstract Command Execute();
    }
}