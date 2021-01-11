using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Walterlv.Demo.AllFonts
{
    internal class FontPresenter : Decorator
    {
        protected override Size MeasureOverride(Size constraint)
        {
            try
            {
                return base.MeasureOverride(constraint);
            }
            catch (Exception ex)
            {
                ReplaceToSafeChildAsync();
                return new Size();
            }
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            try
            {
                return base.ArrangeOverride(arrangeSize);
            }
            catch (Exception ex)
            {
                ReplaceToSafeChildAsync();
                return new Size();
            }
        }

        private DispatcherOperation ReplaceToSafeChildAsync() => Dispatcher.InvokeAsync(() =>
        {
            Child = new TextBlock
            {
                Foreground = Brushes.Red,
                Text = (Child as TextBlock)?.Text ?? "null",
            };
        });
    }
}
