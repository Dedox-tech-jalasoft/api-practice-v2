namespace InsuranceAPIv2.Shared.Abstractions
{
    public class Error
    {
        public string Message { get; set; } = string.Empty;
        public Code? Code { get; set; } = null;
    }
}
