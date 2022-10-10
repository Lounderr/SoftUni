using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes;

namespace E02.ValidationAttributes.Attributes
{
    internal class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            return obj != null;
        }
    }
}
