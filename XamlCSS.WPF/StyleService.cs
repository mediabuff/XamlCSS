﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace XamlCSS.WPF
{
    public class StyleService : StyleServiceBase<Style, DependencyObject, DependencyProperty>
    {
        protected override void AddSetter(Style style, DependencyProperty property, object value)
        {
            style.Setters.Add(new Setter(property, value));
        }

        protected override Style CreateStyle(Type forType)
        {
            Style style;

            if (forType != null)
            {
                style = new Style(forType);
            }
            else
            {
                style = new Style();
            }

            return style;
        }

        public override IDictionary<DependencyProperty, object> GetStyleAsDictionary(Style style)
        {
            if (style == null)
            {
                return null;
            }

            return style.Setters.OfType<Setter>().ToDictionary(x => x.Property, x => x.Value);
        }
        public override void SetStyle(DependencyObject visualElement, Style style)
        {
            if (visualElement is FrameworkElement)
            {
                (visualElement as FrameworkElement).Style = style;
            }
            else if (visualElement is FrameworkContentElement)
            {
                (visualElement as FrameworkContentElement).Style = style;
            }
        }
    }
}
