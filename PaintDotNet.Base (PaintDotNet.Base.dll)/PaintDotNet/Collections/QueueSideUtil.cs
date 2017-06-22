namespace PaintDotNet.Collections
{
    using PaintDotNet;
    using System;

    public static class QueueSideUtil
    {
        public static QueueSide Invert(QueueSide queueSide)
        {
            if (queueSide != QueueSide.Back)
            {
                if (queueSide == QueueSide.Front)
                {
                    return QueueSide.Back;
                }
            }
            else
            {
                return QueueSide.Front;
            }
            ExceptionUtil.ThrowInvalidEnumArgumentException<QueueSide>(queueSide, "queueSide");
            return (QueueSide) (-2147483648);
        }
    }
}

