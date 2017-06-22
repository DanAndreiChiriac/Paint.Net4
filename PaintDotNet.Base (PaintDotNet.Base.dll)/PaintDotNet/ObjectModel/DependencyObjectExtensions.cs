namespace PaintDotNet.ObjectModel
{
    using PaintDotNet;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Data;

    public static class DependencyObjectExtensions
    {
        public static void ClearAllBindings(this DependencyObject targetObject)
        {
            BindingOperations.ClearAllBindings(targetObject);
        }

        public static void ClearBinding(this DependencyObject targetObject, DependencyProperty targetProperty)
        {
            BindingOperations.ClearBinding(targetObject, targetProperty);
        }

        public static void CopyLocalValuesTo<T>(this T sourceObject, T destinationObject) where T: DependencyObject
        {
            LocalValueEnumerator localValueEnumerator = sourceObject.GetLocalValueEnumerator();
            while (localValueEnumerator.MoveNext())
            {
                LocalValueEntry current = localValueEnumerator.Current;
                destinationObject.SetValue(current.Property, current.Value);
            }
        }

        public static object GetDefaultValue(this DependencyObject targetObject, DependencyProperty property) => 
            property.GetMetadata(targetObject).DefaultValue;

        public static bool IsDataBound(this DependencyObject targetObject, DependencyProperty targetProperty) => 
            BindingOperations.IsDataBound(targetObject, targetProperty);

        public static void SetBinding(this DependencyObject targetObject, DependencyProperty targetProperty, object sourceObject, PaintDotNet.ObjectModel.PropertyPath sourcePath, PaintDotNet.ObjectModel.BindingMode mode)
        {
            targetObject.SetBinding(targetProperty, sourceObject, sourcePath, mode, null, null);
        }

        public static void SetBinding(this DependencyObject targetObject, DependencyProperty targetProperty, object sourceObject, PaintDotNet.ObjectModel.PropertyPath sourcePath, PaintDotNet.ObjectModel.BindingMode mode, Func<object, object> convertFn)
        {
            targetObject.SetBinding(targetProperty, sourceObject, sourcePath, mode, convertFn, null);
        }

        public static void SetBinding<TSource, TTarget>(this DependencyObject targetObject, DependencyProperty targetProperty, object sourceObject, PaintDotNet.ObjectModel.PropertyPath sourcePath, PaintDotNet.ObjectModel.BindingMode mode, Func<TSource, TTarget> convertFn)
        {
            targetObject.SetBinding<TSource, TTarget>(targetProperty, sourceObject, sourcePath, mode, convertFn, null);
        }

        public static void SetBinding(this DependencyObject targetObject, DependencyProperty targetProperty, object sourceObject, PaintDotNet.ObjectModel.PropertyPath sourcePath, PaintDotNet.ObjectModel.BindingMode mode, Func<object, object> convertFn, Func<object, object> convertBackFn)
        {
            DelegateValueConverter converter;
            if (convertFn == null)
            {
                if (convertBackFn != null)
                {
                    ExceptionUtil.ThrowArgumentException("convertFn", "if convertFn is null, then convertBackFn must also be null");
                }
                converter = null;
            }
            else
            {
                converter = new DelegateValueConverter(convertFn, convertBackFn);
            }
            Binding binding = new Binding {
                Source = sourceObject,
                Path = sourcePath.WpfPropertyPath,
                Mode = (System.Windows.Data.BindingMode) mode
            };
            if (converter != null)
            {
                binding.Converter = converter;
            }
            BindingOperations.SetBinding(targetObject, targetProperty, binding);
        }

        public static void SetBinding<TSource, TTarget>(this DependencyObject targetObject, DependencyProperty targetProperty, object sourceObject, PaintDotNet.ObjectModel.PropertyPath sourcePath, PaintDotNet.ObjectModel.BindingMode mode, Func<TSource, TTarget> convertFn, Func<TTarget, TSource> convertBackFn)
        {
            Func<object, object> func;
            Func<object, object> func2;
            if (convertFn == null)
            {
                func = null;
            }
            else
            {
                func = source => convertFn((TSource) source);
            }
            if (convertBackFn == null)
            {
                func2 = null;
            }
            else
            {
                func2 = target => convertBackFn((TTarget) target);
            }
            targetObject.SetBinding(targetProperty, sourceObject, sourcePath, mode, func, func2);
        }

        public static void SetMultiBinding(this DependencyObject targetObject, DependencyProperty targetProperty, object[] sourceObjects, PaintDotNet.ObjectModel.PropertyPath[] sourcePaths, PaintDotNet.ObjectModel.BindingMode mode, Func<object[], object> convertFn, Func<object, object[]> convertBackFn)
        {
            DelegateMultiValueConverter converter = new DelegateMultiValueConverter(convertFn, convertBackFn);
            MultiBinding binding = new MultiBinding();
            for (int i = 0; i < sourceObjects.Length; i++)
            {
                Binding item = new Binding {
                    Source = sourceObjects[i],
                    Path = sourcePaths[i].WpfPropertyPath,
                    Mode = (System.Windows.Data.BindingMode) mode
                };
                binding.Bindings.Add(item);
            }
            binding.Converter = converter;
            BindingOperations.SetBinding(targetObject, targetProperty, binding);
        }
    }
}

