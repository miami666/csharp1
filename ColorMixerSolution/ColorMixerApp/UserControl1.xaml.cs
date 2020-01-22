using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorMixerApp
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class ColorMixer : UserControl
    {
        // RoutedEvent
        public static readonly RoutedEvent ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble,
              typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorMixer));

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        private void OnColorChanged(Color oldValue, Color newValue)
        {
            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(oldValue, newValue);
            args.RoutedEvent = ColorMixer.ColorChangedEvent;
            RaiseEvent(args);
        }

        // Felder
        public static readonly DependencyProperty ColorProperty;
        public static readonly DependencyProperty RedProperty;
        public static readonly DependencyProperty GreenProperty;
        public static readonly DependencyProperty BlueProperty;

        private Color? oldColor;

        // Eigenschaftswrapper
        public Color Color
        {
            get
            {
                return (Color)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }

        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }

        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }

        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        // Statischer Konstruktor
        static ColorMixer()
        {
            RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(ColorMixer),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(RGBPropertyChanged)));

            GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(ColorMixer),
                    new FrameworkPropertyMetadata(new PropertyChangedCallback(RGBPropertyChanged)));

            BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(ColorMixer),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(RGBPropertyChanged)));

            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ColorMixer),
                new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(ColorPropertyChanged)));

            CommandManager.RegisterClassCommandBinding(typeof(ColorMixer), new CommandBinding(ApplicationCommands.Undo, UndoCommand_Executed, UndoCommand_CanExecute));
        }

        private static void RGBPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorMixer colorPicker = sender as ColorMixer;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;
            colorPicker.Color = color;
        }

        private static void ColorPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorMixer colorPicker = (ColorMixer)sender;
            Color oldColor = (Color)e.OldValue;
            Color newColor = (Color)e.NewValue;
            colorPicker.Red = newColor.R;
            colorPicker.Green = newColor.G;
            colorPicker.Blue = newColor.B;
            colorPicker.oldColor = oldColor;
            colorPicker.OnColorChanged(oldColor, newColor);
        }

        // Command-Events
        private static void UndoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ColorMixer colorPicker = (ColorMixer)sender;
            e.CanExecute = colorPicker.oldColor.HasValue;
        }

        private static void UndoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ColorMixer colorPicker = (ColorMixer)sender;
            colorPicker.Color = (Color)colorPicker.oldColor;
        }


        public ColorMixer()
        {
            InitializeComponent();
        }
    }
}
