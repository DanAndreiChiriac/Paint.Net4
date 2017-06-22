namespace PaintDotNet.ObjectModel
{
    using System;
    using System.Windows;

    public sealed class PropertyPath
    {
        private System.Windows.PropertyPath wpfPropertyPath;

        public PropertyPath(object parameter)
        {
            this.wpfPropertyPath = new System.Windows.PropertyPath(parameter);
        }

        public PropertyPath(string path, params object[] pathParameters)
        {
            this.wpfPropertyPath = new System.Windows.PropertyPath(path, pathParameters);
        }

        internal System.Windows.PropertyPath WpfPropertyPath =>
            this.wpfPropertyPath;
    }
}

