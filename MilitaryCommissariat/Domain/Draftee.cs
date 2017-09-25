using System;

namespace MilitaryCommissariat.Domain
{
    public class Draftee
    {
        public long Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string BirthPlace { get; set; }
        public DateTime BirthDate { get; set; }
        public string Category { get; set; }
        public string TroopType { get; set; }
        public string ForeignLanguages { get; set; }
    }
}