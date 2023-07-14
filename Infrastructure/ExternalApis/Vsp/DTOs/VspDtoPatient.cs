namespace InsuranceAPIv2.Infrastructure.ExternalApis.Vsp.DTOs
{
    public class VspDtoPatient
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Corporation { get; set; } = string.Empty;
    }
}
