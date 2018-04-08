using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Validators
{
    sealed public class MajorAttribute : ValidationAttribute
    {
        private int years;

        public MajorAttribute(int years) : base()
        {
            this.years = years;
        }
        public override bool IsValid(object value)
        {
            if( value is DateTime)
            {
                var dt = (DateTime) value;
                if (dt.AddYears(years) <= DateTime.Now)
                    return true;
            }
            return false;
        }
    }
}
