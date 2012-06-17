namespace CommandPattern
{
    abstract class Command
    {
        protected Receiver receiver;
  
        public Command(Receiver receiver)
   
        {
            this.receiver = receiver;
        }
   
        public abstract void Execute();
    }
}