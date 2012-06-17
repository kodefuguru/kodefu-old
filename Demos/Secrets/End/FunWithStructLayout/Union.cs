namespace FunWithStructLayout
{
    using System.Runtime.InteropServices;
    
    [StructLayout(LayoutKind.Explicit)]
    public struct Union
    {
        [FieldOffset(0)]
        private byte b;

        [FieldOffset(0)]
        private char c;

        [FieldOffset(0)]
        private float f;

        [FieldOffset(0)]
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
