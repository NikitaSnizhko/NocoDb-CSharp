namespace NocoDb.Utils
{
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }
    }
}