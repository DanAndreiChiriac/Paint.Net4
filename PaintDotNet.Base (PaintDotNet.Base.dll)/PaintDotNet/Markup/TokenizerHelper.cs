namespace PaintDotNet.Markup
{
    using System;
    using System.Globalization;
    using System.Text;

    internal sealed class TokenizerHelper
    {
        private char _argSeparator;
        private int _charIndex;
        private int _currentTokenIndex;
        private int _currentTokenLength;
        private bool _foundSeparator;
        private char _quoteChar;
        private string _str;
        private int _strLen;
        private static readonly Func<int, string, string> getSeparatorDelimitedFormatStringFn = Func.Memoize<int, string, string>(new Func<int, string, string>(TokenizerHelper.GetSeparatorDelimitedFormatStringImpl));

        internal TokenizerHelper(string str, IFormatProvider formatProvider)
        {
            char numericListSeparator = GetNumericListSeparator(formatProvider);
            this.Initialize(str, '\'', numericListSeparator);
        }

        internal TokenizerHelper(string str, char quoteChar, char separator)
        {
            this.Initialize(str, quoteChar, separator);
        }

        internal static string ConvertToString(string format, IFormatProvider formatProvider, params object[] fieldValues)
        {
            char numericListSeparator = GetNumericListSeparator(formatProvider);
            string separatorDelimitedFormatString = GetSeparatorDelimitedFormatString(fieldValues.Length, format);
            object[] args = new object[fieldValues.Length + 1];
            args[0] = numericListSeparator;
            for (int i = 1; i < args.Length; i++)
            {
                args[i] = fieldValues[i - 1];
            }
            return string.Format(formatProvider, separatorDelimitedFormatString, args);
        }

        internal string GetCurrentToken()
        {
            if (this._currentTokenIndex < 0)
            {
                return null;
            }
            return this._str.Substring(this._currentTokenIndex, this._currentTokenLength);
        }

        internal static char GetNumericListSeparator(IFormatProvider provider)
        {
            char ch = ',';
            NumberFormatInfo instance = NumberFormatInfo.GetInstance(provider);
            if ((instance.NumberDecimalSeparator.Length > 0) && (ch == instance.NumberDecimalSeparator[0]))
            {
                ch = ';';
            }
            return ch;
        }

        internal static string GetSeparatorDelimitedFormatString(int fieldCount, string fieldFormat) => 
            getSeparatorDelimitedFormatStringFn(fieldCount, fieldFormat);

        private static string GetSeparatorDelimitedFormatStringImpl(int fieldCount, string fieldFormat)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < fieldCount; i++)
            {
                builder.Append("{");
                builder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "{0}", i + 1);
                if (fieldFormat != null)
                {
                    builder.Append(":");
                    builder.Append(fieldFormat);
                }
                builder.Append("}");
                if (i != (fieldCount - 1))
                {
                    builder.Append("{0}");
                }
            }
            return builder.ToString();
        }

        private void Initialize(string str, char quoteChar, char separator)
        {
            this._str = str;
            this._strLen = (str == null) ? 0 : str.Length;
            this._currentTokenIndex = -1;
            this._quoteChar = quoteChar;
            this._argSeparator = separator;
            while (this._charIndex < this._strLen)
            {
                if (!char.IsWhiteSpace(this._str, this._charIndex))
                {
                    return;
                }
                this._charIndex++;
            }
        }

        internal void LastTokenRequired()
        {
            if (this._charIndex != this._strLen)
            {
                throw new InvalidOperationException("extra data encountered");
            }
        }

        internal bool NextToken() => 
            this.NextToken(false);

        internal bool NextToken(bool allowQuotedToken) => 
            this.NextToken(allowQuotedToken, this._argSeparator);

        internal bool NextToken(bool allowQuotedToken, char separator)
        {
            this._currentTokenIndex = -1;
            this._foundSeparator = false;
            if (this._charIndex >= this._strLen)
            {
                return false;
            }
            char c = this._str[this._charIndex];
            int num = 0;
            if (allowQuotedToken && (c == this._quoteChar))
            {
                num++;
                this._charIndex++;
            }
            int num2 = this._charIndex;
            int num3 = 0;
            while (this._charIndex < this._strLen)
            {
                c = this._str[this._charIndex];
                if (num > 0)
                {
                    if (c != this._quoteChar)
                    {
                        goto Label_00AA;
                    }
                    num--;
                    if (num != 0)
                    {
                        goto Label_00AA;
                    }
                    this._charIndex++;
                    break;
                }
                if (char.IsWhiteSpace(c) || (c == separator))
                {
                    if (c == separator)
                    {
                        this._foundSeparator = true;
                    }
                    break;
                }
            Label_00AA:
                this._charIndex++;
                num3++;
            }
            if (num > 0)
            {
                throw new InvalidOperationException("missing end quote");
            }
            this.ScanToNextToken(separator);
            this._currentTokenIndex = num2;
            this._currentTokenLength = num3;
            if (this._currentTokenLength < 1)
            {
                throw new InvalidOperationException("empty token");
            }
            return true;
        }

        internal string NextTokenRequired()
        {
            if (!this.NextToken(false))
            {
                throw new InvalidOperationException("premature string termination");
            }
            return this.GetCurrentToken();
        }

        internal string NextTokenRequired(bool allowQuotedToken)
        {
            if (!this.NextToken(allowQuotedToken))
            {
                throw new InvalidOperationException("premature string termination");
            }
            return this.GetCurrentToken();
        }

        private void ScanToNextToken(char separator)
        {
            if (this._charIndex < this._strLen)
            {
                char c = this._str[this._charIndex];
                if ((c != separator) && !char.IsWhiteSpace(c))
                {
                    throw new InvalidOperationException("extra data encountered");
                }
                int num = 0;
                while (this._charIndex < this._strLen)
                {
                    c = this._str[this._charIndex];
                    if (c == separator)
                    {
                        this._foundSeparator = true;
                        num++;
                        this._charIndex++;
                        if (num > 1)
                        {
                            throw new InvalidOperationException("empty token");
                        }
                    }
                    else
                    {
                        if (!char.IsWhiteSpace(c))
                        {
                            break;
                        }
                        this._charIndex++;
                    }
                }
                if ((num > 0) && (this._charIndex >= this._strLen))
                {
                    throw new InvalidOperationException("empty token");
                }
            }
        }

        internal bool FoundSeparator =>
            this._foundSeparator;
    }
}

