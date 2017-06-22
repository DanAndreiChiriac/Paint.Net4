namespace PaintDotNet.IO
{
    using System;
    using System.IO;

    public static class StreamUtil
    {
        public static long CopyStream(Stream input, Stream output) => 
            CopyStream(input, output, -1L);

        public static long CopyStream(Stream input, Stream output, long maxBytes)
        {
            int num2;
            int num3;
            long num = 0L;
            byte[] buffer = new byte[0x1000];
            do
            {
                num2 = input.Read(buffer, 0, buffer.Length);
                if (num2 == 0)
                {
                    return num;
                }
                if ((maxBytes != -1L) && ((num + num2) > maxBytes))
                {
                    num3 = (int) (maxBytes - num);
                }
                else
                {
                    num3 = num2;
                }
                output.Write(buffer, 0, num2);
                num += num3;
            }
            while (num3 == num2);
            return num;
        }
    }
}

