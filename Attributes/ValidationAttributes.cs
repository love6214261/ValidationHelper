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