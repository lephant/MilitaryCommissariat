using System.Collections.Generic;
using System.Data;
using MilitaryCommissariat.Domain;
using MilitaryCommissariat.Utils;

namespace MilitaryCommissariat.Converters
{
    public class EducationPlaceListConverter : IConverter<List<EducationPlace>, DataTable>
    {
        public List<EducationPlace> Convert(DataTable source)
        {
            List<EducationPlace> result = new List<EducationPlace>(source.Rows.Count);
            foreach (DataRow dataRow in source.Rows)
            {
                EducationPlace educationPlace = new EducationPlace();
                educationPlace.Id = (long) dataRow["id"];
                educationPlace.DrafteeId = (long) dataRow["draftee_id"];
                educationPlace.Name = DbConverterUtils.ConvertString(dataRow["name"]);
                educationPlace.Education = DbConverterUtils.ConvertString(dataRow["education"]);
                educationPlace.InstitutionType = DbConverterUtils.ConvertString(dataRow["institution_type"]);
                educationPlace.EndDate = DbConverterUtils.ConvertDateTime(dataRow["end_date"]);
                educationPlace.Faculty = DbConverterUtils.ConvertString(dataRow["faculty"]);
                educationPlace.Specialty = DbConverterUtils.ConvertString(dataRow["specialty"]);
                result.Add(educationPlace);
            }
            return result;
        }
    }
}