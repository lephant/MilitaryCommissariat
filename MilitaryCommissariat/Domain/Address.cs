namespace MilitaryCommissariat.Domain
{
    public class Address
    {
        public long DrafteeId { get; set; }
        public string MunicipalDistrict { get; set; }
        public string MailIndex { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string HousingNumber { get; set; }
        public string Apartment { get; set; }
        public string HomePhone { get; set; }
    }
}
