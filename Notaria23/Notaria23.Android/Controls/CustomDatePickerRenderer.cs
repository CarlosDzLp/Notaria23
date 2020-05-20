using System;
using Android.Content;
using Notaria23.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(DatePicker),typeof(CustomDatePickerRenderer))]
namespace Notaria23.Droid.Controls
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        public CustomDatePickerRenderer(Context context): base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            Control.Background = null;
        }
    }
}
