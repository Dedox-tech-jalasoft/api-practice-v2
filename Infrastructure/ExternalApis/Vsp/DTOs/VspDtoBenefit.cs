namespace InsuranceAPIv2.Infrastructure.ExternalApis.Vsp.DTOs
{
    public class VspDtoBenefit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;    
        public string Description { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
    }
}
