using System;

namespace MilitaryCommissariat.Domain
{
    public class EducationPlace
    {
        public long Id { get; set; }
        public long DrafteeId { get; set; }
        public string Name { get; set; }
        public string Education { get; set; }
        public string InstitutionType { get; set; }
        public DateTime EndDate { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }
    }
}
