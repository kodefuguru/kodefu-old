namespace TemplateMethodPattern
{
    using System;

    class ConcreteClassB : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("B1");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("B2");
        }
    }
}