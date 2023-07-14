namespace InsuranceAPIv2.Application.DTOs
{
    public class DtoPatient
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
    }
}
