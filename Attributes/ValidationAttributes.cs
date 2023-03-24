using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationTool
{
    public class ValidationAttributes
    {
        public class NotNullOrEmptyAttribute: System.Attribute
        {
            private string _errorContext = "";
            public string ErrorContext
            {
                get { return _errorContext; }
            }
            public NotNullOrEmptyAttribute(string errorContext)
            {
                this._errorContext = errorContext; 
            }
        }
    }
}