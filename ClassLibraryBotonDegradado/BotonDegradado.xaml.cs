using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace ClassLibraryBotonDegradado
{
    public sealed partial class BotonDegradado : UserControl
    {

        GradientStop gradientStop1, gradientStop2;

        public Color ColorInicial
        {
            get { return (Color)GetValue(ColorInicialProperty); }
            set { SetValue(ColorInicialProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ColorInicial.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorInicialProperty =
            DependencyProperty.Register("ColorInicial", typeof(Color), typeof(BotonDegradado), new PropertyMetadata(Colors.White, OnColorChanged));

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as BotonDegradado).OnColorChanged(e);
        }

        private void OnColorChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == ColorInicialProperty)
                gradientStop1.Color = (Color)e.NewValue;
            if (e.Property == ColorFinalProperty)
                gradientStop2.Color = (Color)e.NewValue; ;
        }

        public Color ColorFinal
        {
            get { return (Color)GetValue(ColorFinalProperty); }
            set { SetValue(ColorFinalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ColorFinal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorFinalProperty =
            DependencyProperty.Register("ColorFinal", typeof(Color), typeof(BotonDegradado), new PropertyMetadata(Colors.White, OnColorChanged));
        

        public BotonDegradado()
        {
            this.InitializeComponent();                             

            gradientStop1 = new GradientStop
            {
                Offset = 0,
                Color = this.ColorInicial
            };
            gradientStop2 = new GradientStop
            {
                Offset = 1,
                Color = this.ColorFinal
            };

            LinearGradientBrush brush = new LinearGradientBrush();
            brush.GradientStops.Add(gradientStop1);
            brush.GradientStops.Add(gradientStop2);
            this.boton.Background = brush;
        }
    }
}
