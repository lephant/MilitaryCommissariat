using MilitaryCommissariat.Domain;

namespace MilitaryCommissariat.Validators
{
    public class AddressValidator
    {
        public bool Validate(Address address)
        {
            if (address.MunicipalDistrict.Length > 512)
            {
                Message = "Муниципальный округ в адресе призывника не может быть больше 512 символов!";
                return false;
            }
            if (address.MailIndex.Length > 64)
            {
                Message = "Почтовый индекс в адресе призывника не может быть больше 64 символов!";
                return false;
            }
            if (address.StreetName.Length > 256)
            {
                Message = "Улица в адресе призывника не может быть больше 256 символов!";
                return false;
            }
            if (address.HouseNumber.Length > 64)
            {
                Message = "Дом в адресе призывника не может быть больше 64 символов!";
                return false;
            }
            if (address.HousingNumber.Length > 64)
            {
                Message = "Корпус в адресе призывника не может быть больше 64 символов!";
                return false;
            }
            if (address.Apartment.Length > 128)
            {
                Message = "Квартира в адресе призывника не может быть больше 128 символов!";
                return false;
            }
            if (address.HomePhone.Length > 64)
            {
                Message = "Домашний телефон в адресе призывника не может быть больше 64 символов!";
                return false;
            }
            Message = "OK";
            return true;
        }

        public string Message { get; private set; }
    }
}