namespace PaintDotNet.ObjectModel
{
    using PaintDotNet;
    using PaintDotNet.Diagnostics;
    using System;
    using System.Windows;

    public static class PropertyPathUtil
    {
        public static PaintDotNet.ObjectModel.PropertyPath Combine(DependencyProperty a, DependencyProperty b)
        {
            VerifyPropertyTypes(a, b);
            return new PaintDotNet.ObjectModel.PropertyPath(a.Name + "." + b.Name, Array.Empty<object>());
        }

        public static PaintDotNet.ObjectModel.PropertyPath Combine(DependencyProperty a, DependencyProperty b, DependencyProperty c)
        {
            VerifyPropertyTypes(a, b);
            VerifyPropertyTypes(b, c);
            string[] textArray1 = new string[] { a.Name, ".", b.Name, ".", c.Name };
            return new PaintDotNet.ObjectModel.PropertyPath(string.Concat(textArray1), Array.Empty<object>());
        }

        public static PaintDotNet.ObjectModel.PropertyPath Combine(DependencyProperty a, DependencyProperty b, DependencyProperty c, DependencyProperty d)
        {
            VerifyPropertyTypes(a, b);
            VerifyPropertyTypes(b, c);
            VerifyPropertyTypes(c, d);
            string[] textArray1 = new string[] { a.Name, ".", b.Name, ".", c.Name, ".", d.Name };
            return new PaintDotNet.ObjectModel.PropertyPath(string.Concat(textArray1), Array.Empty<object>());
        }

        private static void VerifyPropertyTypes(DependencyProperty a, DependencyProperty b)
        {
            Validate.Begin().IsNotNull<DependencyProperty>(a, "a").IsNotNull<DependencyProperty>(b, "b").Check();
            if (!a.PropertyType.IsAssignableFrom(b.OwnerType))
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
        }
    }
}

