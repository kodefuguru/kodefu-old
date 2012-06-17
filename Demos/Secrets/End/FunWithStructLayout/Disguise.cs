namespace FunWithStructLayout
{
    using System.Runtime.InteropServices;
    
    [StructLayout(LayoutKind.Explicit)]
    public class Disguise
    {
        [FieldOffset(0)]
        private Person person;

        [FieldOffset(0)]
        private Ninja ninja;

        public Person Person
        {
            get { return person; }
            set { person = value; }
        }

        public Ninja Ninja
        {
            get { return ninja; }
            set { ninja = value; }
        } 
    }
}
