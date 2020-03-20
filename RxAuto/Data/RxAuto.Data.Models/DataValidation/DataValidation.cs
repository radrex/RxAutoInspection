namespace RxAuto.Data.Models.DataValidation
{
    public static class DataValidation
    {
        public static class PersonInfo
        {
            public const int PersonNameMaxLength = 20;
        }

        public static class MediaInfo
        {
            public const int DescriptionMaxLength = 4000;
            public const int ImageUrlMaxLength = 2000;
            public const int DocumentNameMaxLength = 300;
        }

        public static class VehicleInfo
        {
            public const int VehicleTypeName = 50;
            public const int VehicleMakeMaxLength = 30;
            public const int VehicleModelMaxLength = 30;
            public const int LicenseNumberMaxLength = 10;
        }

        public static class ContactInfo
        {
            public const int TownMaxLength = 30;
            public const int EmailMaxLength = 254;
            public const int AddressMaxLength = 50;
            public const int PhoneNumberMaxLength = 15;
        }
    }
}
