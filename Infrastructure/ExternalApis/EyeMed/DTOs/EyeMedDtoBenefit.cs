namespace InsuranceAPIv2.Infrastructure.ExternalApis.EyeMed.DTOs
{
    public class EyeMedDtoBenefit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public bool? IsFullCoverage { get; set; }
    }       
}
