namespace RxAuto.Data.Models.DataValidation
{
    /// <summary>
    /// Contains classes with validation constants. 
    /// </summary>
    public static class DataValidation
    {
        /// <summary>
        /// Validation constants for Personal information.
        /// </summary>
        public static class PersonInfo
        {
            public const int PersonNameMaxLength = 20;
        }

        /// <summary>
        /// Validation constants for Media information - image, document, description, etc.
        /// </summary>
        public static class MediaInfo
        {
            public const int DescriptionMaxLength = 4000;
            public const int ImageUrlMaxLength = 2000;
            public const int DocumentNameMaxLength = 300;
        }

        /// <summary>
        /// Validation constants for Vehicle information - make, model, licenseNumber, etc.
        /// </summary>
        public static class VehicleInfo
        {
            public const int VehicleTypeName = 50;
            public const int VehicleMakeMaxLength = 30;
            public const int VehicleModelMaxLength = 30;
            public const int LicenseNumberMaxLength = 10;
        }

        /// <summary>
        /// Validation constants for Contact information - email, address, phone, etc.
        /// </summary>
        public static class ContactInfo
        {
            public const int TownMaxLength = 30;
            public const int EmailMaxLength = 254;
            public const int AddressMaxLength = 50;
            public const int PhoneNumberMaxLength = 15;
        }
    }
}
