using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ClassLibraryPanelCircular
{
    public class PanelCircular : Panel
    {

        Size available;
        protected override Size MeasureOverride(Size availableSize)
        {
            available = availableSize;
            foreach (UIElement child in Children)
            {
                child.Measure(new Size(300,300));
               
            }
            return availableSize;

        }

        protected override Size ArrangeOverride(Size finalSize)
        {

            int count = 1;
            double x, y;
            float angulo, radio;
            angulo = 360 / Children.Count();
            RotateTransform rotar = new RotateTransform();
            rotar.Angle = angulo;

            radio =  (float) Math.Min(available.Height, available.Width);
            foreach (UIElement child in Children)
            {
                x = Math.Cos(count * angulo) * radio;
                y = Math.Sin(count * angulo) * radio;
                Point anchorPoint = new Point(x + radio, y + radio);
                child.Arrange(new Rect(anchorPoint, child.DesiredSize));
               
                count++;
            }
            return finalSize;
        }
    }
}
