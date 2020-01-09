using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CLPanelEscalera
{
    public class PanelEscalera:Panel
    {
        Size available;
        double altoDeseado, anchoDeseado;
        protected override Size MeasureOverride(Size availableSize)
        {
            available = availableSize;
            altoDeseado = 0;
            anchoDeseado = 0;
            foreach (Windows.UI.Xaml.UIElement child in Children)
            {
                child.Measure(availableSize);
                altoDeseado += child.DesiredSize.Height;
                if (child.DesiredSize.Width > anchoDeseado)
                {
                    anchoDeseado = child.DesiredSize.Width;
                }

            }
            return availableSize;

        }

        protected override Size ArrangeOverride(Size finalSize)
        {

            int count = 1;
            double x_actual, y_actual, salto, tabulacion;
            salto = (available.Height - altoDeseado) / (Children.Count() -1);
            tabulacion = (available.Width - anchoDeseado) / (Children.Count() -1);
            x_actual = 0;
            y_actual = 0;
            Point anchorPoint = new Point(0, 0);

            foreach (UIElement child in Children)
            {                
                child.Arrange(new Rect(anchorPoint, child.DesiredSize));
                anchorPoint.X += tabulacion;
                anchorPoint.Y += salto + child.DesiredSize.Height;
               
            }
            return finalSize;
        }

    }
}
