namespace TemplateMethodPattern
{
    using System;

    class ConcreteClassA : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("A1");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("A2");
        }
    }
}