using System.Collections.Generic;
using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Validators
{
    public class RelativesValidator
    {
        public bool Validate(List<Relative> relatives)
        {
            foreach (Relative relative in relatives)
            {
                if (relative.RelationshipType.Length > 64)
                {
                    Message = "Родство не должно быть больше 64 символов!";
                    return false;
                }
                if (relative.FullName.Length > 512)
                {
                    Message = "ФИО родственника не должно быть больше 512 символов!";
                    return false;
                }
                if (relative.BirthYear > 10000)
                {
                    Message = "Слишком большой год рождения!";
                    return false;
                }
                if (relative.BirthPlace.Length > 512)
                {
                    Message = "Место рождения родственника не может быть больше 512 символов!";
                    return false;
                }
                if (relative.WorkPlace.Length > 512)
                {
                    Message = "Место работы родственника не может быть больше 512 символов!";
                    return false;
                }
            }
            Message = "OK";
            return true;
        }

        public string Message { get; private set; }
    }
}