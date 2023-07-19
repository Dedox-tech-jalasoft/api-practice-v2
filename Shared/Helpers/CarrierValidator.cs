namespace InsuranceAPIv2.Shared.Helpers
{
    public static class CarrierValidator
    {
        public static bool DoesCarrierExist(int carrierId)
        {
            return Enum.IsDefined(typeof(Carrier), carrierId);
        }

        public static Carrier GetValidCarrierById (int carrierId)
        {
            return (Carrier)carrierId;
        }
    }
}
