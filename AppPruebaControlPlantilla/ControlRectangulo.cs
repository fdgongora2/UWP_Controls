
using System.Collections.Generic;

using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace AppPruebaControlPlantilla
{
    public sealed class ControlRectangulo : Control
    {
        Canvas Lienzo;
        double alto, ancho;
        
        public ControlRectangulo()
        {
            this.DefaultStyleKey = typeof(ControlRectangulo);
            SizeChanged += alCambiarTamanio;
        }

        protected override void OnApplyTemplate()
        {
            Lienzo = GetTemplateChild("Lienzo") as Canvas;
        }

        void alCambiarTamanio (object sender, SizeChangedEventArgs e)
        {
            alto = e.NewSize.Height;
            ancho = e.NewSize.Width;
            pintar_Elemento();
        }



        private void pintar_Elemento()
        {
            Lienzo.Children.Clear();
            Rectangle Rect_Aux = new Rectangle()
            {
                Width = ancho/2,
                Height = alto/2,
                Fill = new SolidColorBrush(Colors.Red)
            };

            Lienzo.Children.Add(Rect_Aux);
            Canvas.SetTop(Rect_Aux, 0);
            Canvas.SetLeft(Rect_Aux, 0);

        }
    }
}
