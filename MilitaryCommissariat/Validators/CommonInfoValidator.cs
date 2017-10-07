using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Validators
{
    public class CommonInfoValidator
    {
        public bool Validate(Draftee draftee)
        {
            if (draftee.FirstName.Length > 128)
            {
                Message = "Имя призывника не должно быть больше 128 символов!";
                return false;
            }
            if (draftee.LastName.Length > 128)
            {
                Message = "Фамилия призывника не должна быть больше 128 символов!";
                return false;
            }
            if (draftee.Patronymic.Length > 128)
            {
                Message = "Отчество призывника не должно быть больше 128 символов!";
                return false;
            }
            if (draftee.BirthPlace.Length > 512)
            {
                Message = "Место рождения призывника не должно быть больше 512 символов!";
                return false;
            }
            if (draftee.Category.Length > 64)
            {
                Message = "Категория призывника не должна быть больше 64 символов!";
                return false;
            }
            if (draftee.TroopType.Length > 512)
            {
                Message = "Роды войск призывника не должны быть больше 512 символов!";
                return false;
            }
            Message = "OK";
            return true;
        }

        public string Message { get; private set; }
    }
}