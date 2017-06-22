namespace PaintDotNet.Interop
{
    using PaintDotNet.ComponentModel;
    using PaintDotNet.Functional;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;

    public static class VariantUtils
    {
        private static VarEnum invalidVariantType = VarEnum.VT_NULL;

        public static bool CanConvert(object managedValue) => 
            ((managedValue == null) || IsManagedTypeSupported(managedValue.GetType()));

        public static Type GetManagedType(VarEnum variantType)
        {
            Type managedTypeCore = GetManagedTypeCore(variantType);
            if (managedTypeCore == null)
            {
                throw new NotSupportedException();
            }
            return managedTypeCore;
        }

        private static Type GetManagedTypeCore(VarEnum variantType)
        {
            if (variantType <= (VarEnum.VT_VECTOR | VarEnum.VT_LPWSTR))
            {
                switch (variantType)
                {
                    case VarEnum.VT_NULL:
                        return typeof(void);

                    case VarEnum.VT_I2:
                        return typeof(short);

                    case VarEnum.VT_I4:
                    case VarEnum.VT_INT:
                        return typeof(int);

                    case VarEnum.VT_R4:
                        return typeof(float);

                    case VarEnum.VT_R8:
                        return typeof(double);

                    case VarEnum.VT_CY:
                    case VarEnum.VT_DECIMAL:
                        return typeof(decimal);

                    case VarEnum.VT_DATE:
                        return typeof(DateTime);

                    case VarEnum.VT_BSTR:
                    case VarEnum.VT_LPSTR:
                    case VarEnum.VT_LPWSTR:
                        return typeof(string);

                    case VarEnum.VT_DISPATCH:
                    case VarEnum.VT_UNKNOWN:
                        return typeof(IObjectRef);

                    case VarEnum.VT_BOOL:
                        return typeof(bool);

                    case VarEnum.VT_I1:
                        return typeof(sbyte);

                    case VarEnum.VT_UI1:
                        return typeof(byte);

                    case VarEnum.VT_UI2:
                        return typeof(ushort);

                    case VarEnum.VT_UI4:
                    case VarEnum.VT_UINT:
                        return typeof(uint);

                    case VarEnum.VT_I8:
                        return typeof(long);

                    case VarEnum.VT_UI8:
                        return typeof(ulong);

                    case VarEnum.VT_FILETIME:
                        return typeof(System.Runtime.InteropServices.ComTypes.FILETIME);

                    case VarEnum.VT_BLOB:
                    case (VarEnum.VT_VECTOR | VarEnum.VT_UI1):
                        return typeof(IList<byte>);

                    case VarEnum.VT_CLSID:
                        return typeof(Guid);

                    case (VarEnum.VT_VECTOR | VarEnum.VT_I2):
                        return typeof(IList<short>);

                    case (VarEnum.VT_VECTOR | VarEnum.VT_I4):
                    case (VarEnum.VT_VECTOR | VarEnum.VT_INT):
                        return typeof(IList<int>);

                    case (VarEnum.VT_VECTOR | VarEnum.VT_R4):
                        return typeof(IList<float>);

                    case (VarEnum.VT_VECTOR | VarEnum.VT_R8):
                        return typeof(IList<double>);

                    case (VarEnum.VT_VECTOR | VarEnum.VT_CY):
                        return typeof(IList<decimal>);

                    case (VarEnum.VT_VECTOR | VarEnum.VT_DATE):
                        return typeof(IList<DateTime>);

                    case (VarEnum.VT_VECTOR | VarEnum.VT_BSTR):
                    case (VarEnum.VT_VECTOR | VarEnum.VT_LPSTR):
                    case (VarEnum.VT_VECTOR | VarEnum.VT_LPWSTR):
                        return typeof(IList<string>);

                    case (VarEnum.VT_VECTOR | VarEnum.VT_BOOL):
                        return typeof(IList<bool>);

                    case (VarEnum.VT_VECTOR | VarEnum.VT_I1):
                        return typeof(IList<sbyte>);

                    case (VarEnum.VT_VECTOR | VarEnum.VT_UI2):
                        return typeof(IList<ushort>);

                    case (VarEnum.VT_VECTOR | VarEnum.VT_UI4):
                    case (VarEnum.VT_VECTOR | VarEnum.VT_UINT):
                        return typeof(IList<uint>);

                    case (VarEnum.VT_VECTOR | VarEnum.VT_I8):
                        return typeof(IList<long>);

                    case (VarEnum.VT_VECTOR | VarEnum.VT_UI8):
                        return typeof(IList<ulong>);
                }
            }
            else
            {
                if (variantType == (VarEnum.VT_VECTOR | VarEnum.VT_FILETIME))
                {
                    return typeof(IList<System.Runtime.InteropServices.ComTypes.FILETIME>);
                }
                if (variantType == (VarEnum.VT_VECTOR | VarEnum.VT_CLSID))
                {
                    return typeof(IList<Guid>);
                }
                if (variantType != VarEnum.VT_BYREF)
                {
                }
            }
            return null;
        }

        public static VarEnum GetVariantType<T>() => 
            GetVariantType(typeof(T));

        public static VarEnum GetVariantType(Type managedType)
        {
            VarEnum variantTypeCore = GetVariantTypeCore(managedType);
            if (variantTypeCore == invalidVariantType)
            {
                throw new NotSupportedException();
            }
            return variantTypeCore;
        }

        private static VarEnum GetVariantTypeCore(Type managedType)
        {
            if (!typeof(void).IsAssignableFrom(managedType) && !typeof(Unit).IsAssignableFrom(managedType))
            {
                if (typeof(sbyte).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_I1;
                }
                if (typeof(byte).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_UI1;
                }
                if (typeof(short).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_I2;
                }
                if (typeof(ushort).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_UI2;
                }
                if (typeof(int).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_I4;
                }
                if (typeof(uint).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_UI4;
                }
                if (typeof(long).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_I8;
                }
                if (typeof(ulong).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_UI8;
                }
                if (typeof(float).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_R4;
                }
                if (typeof(double).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_R8;
                }
                if (typeof(bool).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_BOOL;
                }
                if (typeof(decimal).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_DECIMAL;
                }
                if (typeof(DateTime).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_DATE;
                }
                if (typeof(System.Runtime.InteropServices.ComTypes.FILETIME).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_FILETIME;
                }
                if (typeof(Guid).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_CLSID;
                }
                if (typeof(string).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_BSTR;
                }
                if (typeof(IObjectRef).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_UNKNOWN;
                }
                if (typeof(IList<sbyte>).IsAssignableFrom(managedType))
                {
                    return (VarEnum.VT_VECTOR | VarEnum.VT_I1);
                }
                if (typeof(IList<byte>).IsAssignableFrom(managedType))
                {
                    return VarEnum.VT_BLOB;
                }
                if (typeof(IList<short>).IsAssignableFrom(managedType))
                {
                    return (VarEnum.VT_VECTOR | VarEnum.VT_I2);
                }
                if (typeof(IList<ushort>).IsAssignableFrom(managedType))
                {
                    return (VarEnum.VT_VECTOR | VarEnum.VT_UI2);
                }
                if (typeof(IList<int>).IsAssignableFrom(managedType))
                {
                    return (VarEnum.VT_VECTOR | VarEnum.VT_I4);
                }
                if (typeof(IList<uint>).IsAssignableFrom(managedType))
                {
                    return (VarEnum.VT_VECTOR | VarEnum.VT_UI4);
                }
                if (typeof(IList<long>).IsAssignableFrom(managedType))
                {
                    return (VarEnum.VT_VECTOR | VarEnum.VT_I8);
                }
                if (typeof(IList<ulong>).IsAssignableFrom(managedType))
                {
                    return (VarEnum.VT_VECTOR | VarEnum.VT_UI8);
                }
                if (typeof(IList<float>).IsAssignableFrom(managedType))
                {
                    return (VarEnum.VT_VECTOR | VarEnum.VT_R4);
                }
                if (typeof(IList<double>).IsAssignableFrom(managedType))
                {
                    return (VarEnum.VT_VECTOR | VarEnum.VT_R8);
                }
                if (typeof(IList<bool>).IsAssignableFrom(managedType))
                {
                    return (VarEnum.VT_VECTOR | VarEnum.VT_BOOL);
                }
                if (typeof(IList<decimal>).IsAssignableFrom(managedType))
                {
                    return (VarEnum.VT_VECTOR | VarEnum.VT_CY);
                }
                if (typeof(IList<DateTime>).IsAssignableFrom(managedType))
                {
                    return (VarEnum.VT_VECTOR | VarEnum.VT_DATE);
                }
                if (typeof(IList<System.Runtime.InteropServices.ComTypes.FILETIME>).IsAssignableFrom(managedType))
                {
                    return (VarEnum.VT_VECTOR | VarEnum.VT_FILETIME);
                }
                if (typeof(IList<Guid>).IsAssignableFrom(managedType))
                {
                    return (VarEnum.VT_VECTOR | VarEnum.VT_CLSID);
                }
                if (typeof(IList<string>).IsAssignableFrom(managedType))
                {
                    return (VarEnum.VT_VECTOR | VarEnum.VT_BSTR);
                }
            }
            return VarEnum.VT_NULL;
        }

        public static bool IsManagedTypeSupported<T>() => 
            IsManagedTypeSupported(typeof(T));

        public static bool IsManagedTypeSupported(Type managedType) => 
            (GetVariantTypeCore(managedType) != invalidVariantType);

        public static bool IsVariantTypeSupported(VarEnum variantType) => 
            (GetManagedTypeCore(variantType) != null);
    }
}

