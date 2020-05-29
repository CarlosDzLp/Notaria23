using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Notaria23.Views.Principal.Template
{
    public partial class AccordionViewTemplate : ContentView
    {
        #region Bindable Properties
        public static BindableProperty HeaderBackgroundColorProperty =
            BindableProperty.Create(nameof(HeaderBackgroundColor),
                typeof(Color),
                typeof(AccordionViewTemplate),
                defaultValue: Color.Transparent,
                propertyChanged: (bindable, oldVal, newVal) =>
                {
                    ((AccordionViewTemplate)bindable).UpdateHeaderBackgroundColor();
                });

        public static BindableProperty HeaderOpenedBackgroundColorProperty =
            BindableProperty.Create(nameof(HeaderOpenedBackgroundColor),
                typeof(Color),
                typeof(AccordionViewTemplate),
                defaultValue: Color.Transparent,
                propertyChanged: (bindable, oldVal, newVal) =>
                {
                    ((AccordionViewTemplate)bindable).UpdateHeaderBackgroundColor();
                });

        public static BindableProperty HeaderTextColorProperty =
            BindableProperty.Create(nameof(HeaderTextColor),
                typeof(Color),
                typeof(AccordionViewTemplate),
                defaultValue: Color.Black,
                propertyChanged: (bindable, oldVal, newVal) =>
                {
                    ((AccordionViewTemplate)bindable).UpdateHeaderTextColor((Color)newVal);
                });

        public static BindableProperty HeaderTextProperty =
            BindableProperty.Create(nameof(HeaderTextProperty),
                typeof(string),
                typeof(AccordionViewTemplate),
                propertyChanged: (bindable, oldVal, newVal) =>
                {
                    ((AccordionViewTemplate)bindable).UpdateHeaderText((string)newVal);
                });

        public static BindableProperty IsBodyVisibleProperty =
            BindableProperty.Create(nameof(IsBodyVisible),
                typeof(bool),
                typeof(AccordionViewTemplate),
                defaultValue: true,
                propertyChanged: (bindable, oldVal, newVal) =>
                {
                    ((AccordionViewTemplate)bindable).UpdateBodyVisibility((bool)newVal);
                });




        public static readonly BindableProperty BodyContentProperty =
            BindableProperty.Create(nameof(BodyContent),
                typeof(ContentView),
                typeof(AccordionViewTemplate), coerceValue: BodyContentCoerceValue);

        private static object BodyContentCoerceValue(BindableObject bindableObject, object value)
        {
            if (bindableObject != null && value != null && value is ContentView)
            {
                AccordionViewTemplate instance = (AccordionViewTemplate)bindableObject;

                instance.Body.Content = (ContentView)value;
            }
            return value;
        }
        #endregion

        #region String Properties
        public ContentView BodyContent
        {
            get { return (ContentView)GetValue(BodyContentProperty); }
            set { SetValue(BodyContentProperty, value); }
        }
        public Color HeaderBackgroundColor
        {
            get
            {
                return (Color)GetValue(HeaderBackgroundColorProperty);
            }
            set
            {
                SetValue(HeaderBackgroundColorProperty, value);
            }
        }
        public Color HeaderOpenedBackgroundColor
        {
            get
            {
                return (Color)GetValue(HeaderOpenedBackgroundColorProperty);
            }
            set
            {
                SetValue(HeaderOpenedBackgroundColorProperty, value);
            }
        }
        public Color HeaderTextColor
        {
            get
            {
                return (Color)GetValue(HeaderTextColorProperty);
            }
            set
            {
                SetValue(HeaderTextColorProperty, value);
            }
        }
        public string HeaderText
        {
            get
            {
                return (string)GetValue(HeaderTextProperty);
            }
            set
            {
                SetValue(HeaderTextProperty, value);
            }
        }

        public bool IsBodyVisible
        {
            get
            {
                return (bool)GetValue(IsBodyVisibleProperty);
            }
            set
            {
                SetValue(IsBodyVisibleProperty, value);
            }
        }
        #endregion
        public AccordionViewTemplate()
        {
            InitializeComponent();
            IsBodyVisible = false;
        }
        #region Methods
        /// <summary>
        /// Updates the color of the header background.
        /// </summary>
        /// <param name="color">Color.</param>
        public void UpdateHeaderBackgroundColor(Color color)
        {
            HeaderView.BackgroundColor = color;
        }

        /// <summary>
        /// Updates the color of the header background.
        /// </summary>
        public void UpdateHeaderBackgroundColor()
        {
            if (IsBodyVisible)
            {
                HeaderView.BackgroundColor = HeaderBackgroundColor;
                BodyView.BackgroundColor = HeaderOpenedBackgroundColor;
            }
            else
            {
                HeaderView.BackgroundColor = HeaderBackgroundColor;
                BodyView.BackgroundColor = HeaderOpenedBackgroundColor;
            }
        }

        /// <summary>
        /// Updates the color of the header text.
        /// </summary>
        /// <param name="color">Color.</param>
        public void UpdateHeaderTextColor(Color color)
        {
            HeaderLabel.TextColor = color;
        }


        /// <summary>
        /// Updates the header text.
        /// </summary>
        /// <param name="text">Text.</param>
        public void UpdateHeaderText(string text)
        {
            HeaderLabel.Text = text;
        }
        public void UpdateBodyVisibility(bool isVisible)
        {
            BodyView.IsVisible = isVisible;
            if (isVisible)
            {
                IndicatorLabel.RotateTo(180, 100);
            }
            else
            {
                IndicatorLabel.RotateTo(0, 100);
            }
        }
        private void Handle_Tapped(object sender, System.EventArgs e)
        {
            IsBodyVisible = !IsBodyVisible;
            UpdateHeaderBackgroundColor();
        }
        #endregion
    }
}
