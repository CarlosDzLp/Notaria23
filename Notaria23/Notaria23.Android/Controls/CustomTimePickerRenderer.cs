using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Notaria23.Droid.Controls;
using Android.Content;

[assembly:ExportRenderer(typeof(TimePicker),typeof(CustomTimePickerRenderer))]
namespace Notaria23.Droid.Controls
{
    public class CustomTimePickerRenderer : TimePickerRenderer
    {
        public CustomTimePickerRenderer(Context context):base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);
            Control.Background = null;
        }
    }
}
