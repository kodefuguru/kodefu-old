namespace FunWithStructLayout
{
    using System.Runtime.InteropServices;
    
    public struct Union
    {
        private byte b;
        private char c;
        private float f;
        private int i;

        public byte Byte
        {
            get { return b; }
            set { b = value; }
        }

        public char Char
        {
            get { return c; }
            set { c = value; }
        }

        public float Float
        {
            get { return f; }
            set { f = value; }
        }

        public int Integer
        {
            get { return i; }
            set { i = value; }
        }
    }
}
