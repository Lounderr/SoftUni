using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    internal class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            IComparable objValue = obj as IComparable;

            return objValue.CompareTo(minValue) >= minValue && objValue.CompareTo(maxValue) <= maxValue;
        }
    }
}
