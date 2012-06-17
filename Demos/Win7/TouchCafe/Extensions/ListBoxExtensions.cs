namespace TouchCafe
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public static class ListBoxExtensions
    {
        public static T GetItem<T>(this ListBox box, Point point) where T : class
        {

            UIElement element = (UIElement)box.InputHitTest(point);

            while (true)
            {

                if (element == box)
                {

                    return default(T);

                }

                T item = box.ItemContainerGenerator.ItemFromContainer(element) as T;

                if (item != null)
                {

                    return item;

                }

                element = (UIElement)VisualTreeHelper.GetParent(element);

            }
        }
    }
}
