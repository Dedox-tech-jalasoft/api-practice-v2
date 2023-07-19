namespace InsuranceAPIv2.Shared.Abstractions
{
    public class Result<T> where T : class
    {
        public T? Data { get; set; } = null;
        public Error? Error { get; set; } = null;
    }
}
