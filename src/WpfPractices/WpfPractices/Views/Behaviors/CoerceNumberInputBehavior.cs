using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace WpfPractices.Views.Behaviors
{
    internal class CoerceNumberInputBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (AssociatedObject != null)
            {
                AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
            }
        }

        private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var numberIsPressed =
                e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 ||
                e.Key >= Key.D0 && e.Key <= Key.D9 ||
                e.ImeProcessedKey >= Key.NumPad0 && e.ImeProcessedKey <= Key.NumPad9 ||
                e.ImeProcessedKey >= Key.D0 && e.ImeProcessedKey <= Key.D9 ||
                e.Key == Key.Back ||
                e.Key == Key.Left ||
                e.Key == Key.Right;

            if (numberIsPressed)
            {
                if (e.KeyboardDevice.Modifiers != ModifierKeys.None)
                {
                    e.Handled = true;
                }
                return;
            }

            var dotIsPressed =
                e.ImeProcessedKey == Key.Decimal ||
                e.ImeProcessedKey == Key.OemPeriod ||
                e.Key == Key.Decimal ||
                e.Key == Key.OemPeriod;

            if (dotIsPressed)
            {
                if ((sender as TextBox).Text.Contains('.'))
                {
                    e.Handled = true;
                }
                return;
            }

            e.Handled = true;
        }
    }
}
