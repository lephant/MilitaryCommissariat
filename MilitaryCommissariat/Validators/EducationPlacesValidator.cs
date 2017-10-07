using System.Collections.Generic;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Validators
{
    public class EducationPlacesValidator
    {
        public bool Validate(List<EducationPlace> places, string foreignLanguages)
        {
            foreach (EducationPlace place in places)
            {
                if (place.Education.Length > 128)
                {
                    Message = "Содержимое поля 'Образование' не должно быть больше 128 символов!";
                    return false;
                }
                if (place.Name.Length > 512)
                {
                    Message = "Название образовательного учреждения не должно быть больше 512 символов!";
                    return false;
                }
                if (place.InstitutionType.Length > 512)
                {
                    Message = "Тип учебного заведения не должен быть больше 512 символов!";
                    return false;
                }
                if (place.Faculty.Length > 256)
                {
                    Message = "Название факультета не должно быть больше 256 символов!";
                    return false;
                }
                if (place.Specialty.Length > 256)
                {
                    Message = "Название специальности не должно быть больше 256 символов!";
                    return false;
                }
            }
            if (foreignLanguages.Length > 255)
            {
                Message = "Список с иностранными языками не должен быть больше 255 символов";
                return false;
            }
            Message = "OK";
            return true;
        }

        public string Message { get; private set; }
    }
}