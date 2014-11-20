using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace AttachedBehaviorDemo.AttachedProperties
{
    public class Commands
    {
        public static ICommand GetTap(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(TapProperty);
        }

        public static void SetTap(DependencyObject obj, ICommand value)
        {
            obj.SetValue(TapProperty, value);
        }

        // Using a DependencyProperty as the backing store for Tap.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TapProperty =
            DependencyProperty.RegisterAttached("Tap",
            typeof(ICommand), 
            typeof(object), 
            new PropertyMetadata(null, OnTapCommandChanged));

        private static void OnTapCommandChanged(DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            var control = d as UIElement;
            if (control == null)
            {
                return;
            }

            control.Tapped += (obj, args) =>
            {
                ICommand command = e.NewValue as ICommand;
                //check if command is null

                //var parameter = control.GetValue(CommandParameterProperty);
                var parameter = GetCommandParameter(control);

                command.Execute(parameter);
            };
        }
        
        
        
        
        //CommandParameter
        public static object GetCommandParameter(DependencyObject obj)
        {
            return (object)obj.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(CommandParameterProperty, value);
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter",
            typeof(object), 
            typeof(object), 
            new PropertyMetadata(null));
    }
}
