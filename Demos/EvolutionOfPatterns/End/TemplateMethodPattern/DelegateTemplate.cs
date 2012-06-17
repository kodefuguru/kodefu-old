namespace TemplateMethodPattern
{
    using System;

    class DelegateTemplate
    {
        private Action primitiveOperation1;
        private Action primitiveOperation2;

        public DelegateTemplate(Action primitiveOperation1, Action primitiveOperation2)
        {
            this.primitiveOperation1 = primitiveOperation1;
            this.primitiveOperation2 = primitiveOperation2;
        }

        public void TemplateMethod()
        {
            primitiveOperation1();
            primitiveOperation2();
            Console.WriteLine("End");
        }
    }
}