namespace PaintDotNet.ObjectModel
{
    using PaintDotNet.Diagnostics;
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    internal sealed class DelegateMultiValueConverter : IMultiValueConverter
    {
        private Func<object, object[]> convertBackFn;
        private Func<object[], object> convertFn;

        public DelegateMultiValueConverter(Func<object[], object> convertFn) : this(convertFn, null)
        {
        }

        public DelegateMultiValueConverter(Func<object[], object> convertFn, Func<object, object[]> convertBackFn)
        {
            Validate.IsNotNull<Func<object[], object>>(convertFn, "convertFn");
            this.convertFn = convertFn;
            this.convertBackFn = convertBackFn;
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == DependencyProperty.UnsetValue)
                {
                    return DependencyProperty.UnsetValue;
                }
            }
            return this.convertFn(values);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value == DependencyProperty.UnsetValue)
            {
                object[] objArray = new object[targetTypes.Length];
                for (int i = 0; i < objArray.Length; i++)
                {
                    objArray[i] = DependencyProperty.UnsetValue;
                }
                return objArray;
            }
            return this.convertBackFn?.Invoke(value);
        }
    }
}

