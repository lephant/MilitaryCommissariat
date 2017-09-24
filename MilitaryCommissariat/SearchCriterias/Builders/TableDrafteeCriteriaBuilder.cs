using System;

namespace MilitaryCommissariat.SearchCriterias.Builders
{
    public class TableDrafteeCriteriaBuilder
    {
        public TableDrafteeCriteria Build(string fullName, string year)
        {
            TableDrafteeCriteria criteria = new TableDrafteeCriteria();
            if (!string.IsNullOrEmpty(fullName.Trim()))
            {
                criteria.FullName = fullName.Trim();
            }
            int birthYear;
            Int32.TryParse(year, out birthYear);
            if (birthYear > 0)
            {
                criteria.BirthYear = birthYear;
            }
            return criteria;
        }
    }
}