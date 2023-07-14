namespace InsuranceAPIv2.Application.DTOs
{
    public class DtoBenefit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;        
        public string Description { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public bool? IsFullCoverage { get; set; }
    }
}
