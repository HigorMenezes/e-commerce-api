namespace e_commerce_api.src.Exceptions
{
    [System.Serializable]
    public class CustomerException : System.Exception
    {
        public CustomerException() { }
        public CustomerException(string message) : base(message) { }
        public CustomerException(string message, System.Exception inner) : base(message, inner) { }
        protected CustomerException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

