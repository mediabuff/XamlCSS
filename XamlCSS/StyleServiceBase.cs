﻿using System;
using System.Collections.Generic;

namespace XamlCSS
{
    public abstract class StyleServiceBase<TStyle, TDependencyObject, TDependencyProperty> : INativeStyleService<TStyle, TDependencyObject, TDependencyProperty>
        where TDependencyObject : class
        where TDependencyProperty : class
        where TStyle : class
    {
        protected const string StyleSheetStyleKey = "StyleSheetStyle";

        public TStyle CreateFrom(IDictionary<TDependencyProperty, object> dict, Type forType)
        {
            TStyle style = CreateStyle(forType);

            foreach (var i in dict)
            {
                AddSetter(style, i.Key, i.Value);
            }

            return style;
        }

        protected abstract TStyle CreateStyle(Type forType);

        protected abstract void AddSetter(TStyle style, TDependencyProperty property, object value);

        public abstract IDictionary<TDependencyProperty, object> GetStyleAsDictionary(TStyle style);

        public abstract void SetStyle(TDependencyObject visualElement, TStyle style);

        public string GetStyleResourceKey(string styleSheetId, Type type, string selector)
        {
            return $"{StyleSheetStyleKey}_{styleSheetId}_${type.FullName}_{selector}";
        }

        public string BaseStyleResourceKey { get { return StyleSheetStyleKey; } }
    }
}