namespace MilitaryCommissariat.Domain
{
    public class Relative
    {
        public long Id { get; set; }
        public long DragteeId { get; set; }
        public string FullName { get; set; }
        public int BirthYear { get; set; }
        public string BirthPlace { get; set; }
        public string WorkPlace { get; set; }
    }
}
