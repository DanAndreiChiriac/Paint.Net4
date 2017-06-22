namespace PaintDotNet.Serialization
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;

    public sealed class SerializationFallbackBinder : SerializationBinder
    {
        private List<Assembly> assemblies = new List<Assembly>();
        private Type nextRequiredBaseType;

        public void AddAssembly(Assembly assembly)
        {
            this.assemblies.Add(assembly);
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            if (!this.IsTypeAllowed(assemblyName, typeName))
            {
                throw new FormatException("invalid Type");
            }
            Type c = null;
            foreach (Assembly assembly in this.assemblies)
            {
                c = this.TryBindToType(assembly, typeName);
                if (c != null)
                {
                    break;
                }
            }
            if (c == null)
            {
                string str = typeName + ", " + assemblyName;
                try
                {
                    c = Type.GetType(str, false, true);
                }
                catch (FileLoadException)
                {
                    c = null;
                }
            }
            if (this.nextRequiredBaseType != null)
            {
                if (!this.nextRequiredBaseType.IsAssignableFrom(c))
                {
                    throw new InvalidCastException();
                }
                this.nextRequiredBaseType = null;
            }
            if ((c != null) && !this.IsTypeAllowed(c))
            {
                throw new FormatException("Invalid type");
            }
            return c;
        }

        private bool IsTypeAllowed(Type type) => 
            (!typeof(TempFileCollection).IsAssignableFrom(type) && !typeof(FileSystemInfo).IsAssignableFrom(type));

        private bool IsTypeAllowed(string assemblyName, string typeName) => 
            ((!typeName.Equals("System.CodeDom.Compiler.TempFileCollection") && !typeName.Equals("System.IO.FileInfo")) && (!typeName.Equals("System.IO.DirectoryInfo") && !typeName.Contains("IWbemClassObjectFreeThreaded")));

        public void SetNextRequiredBaseType(Type type)
        {
            this.nextRequiredBaseType = type;
        }

        private Type TryBindToType(Assembly assembly, string typeName) => 
            assembly.GetType(typeName, false, true);
    }
}

