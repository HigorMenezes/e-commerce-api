namespace e_commerce_api.src.Exceptions.CustomerExceptions
{
    [System.Serializable]
    public class CustomerNotFoundException : System.Exception
    {
        public CustomerNotFoundException() { }
        public CustomerNotFoundException(string message) : base(message) { }
        public CustomerNotFoundException(string message, System.Exception inner) : base(message, inner) { }
        protected CustomerNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}