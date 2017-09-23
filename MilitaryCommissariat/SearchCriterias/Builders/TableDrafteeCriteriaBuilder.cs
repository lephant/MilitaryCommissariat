namespace MilitaryCommissariat.SearchCriterias.Builders
{
    public class TableDrafteeCriteriaBuilder
    {
        public TableDrafteeCriteria Build(string fullName, string year)
        {
            TableDrafteeCriteria criteria = new TableDrafteeCriteria();
            criteria.FullName = fullName;
            //criteria.BirthYear = year;
            return criteria;
        }
    }
}