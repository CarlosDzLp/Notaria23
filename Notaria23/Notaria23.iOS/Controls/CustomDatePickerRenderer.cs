﻿using System;
using Notaria23.iOS.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(DatePicker),typeof(CustomDatePickerRenderer))]
namespace Notaria23.iOS.Controls
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                Control.Layer.CornerRadius = 0;
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
                Control.Layer.BorderWidth = 0;
                Control.ClipsToBounds = false;
            }
        }
    }
}
