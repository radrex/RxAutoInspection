namespace RxAuto.Web.ViewModels.VehicleTypes.InputModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Input model for entering VehicleType information from the user. 
    /// It includes <c>VehicleTypeName</c>, <c>VehicleTypeDescription</c>, <c>VehicleCategoryId</c>.
    /// Validation on User-Side is also included via attributes.
    /// </summary>
    public class VehicleTypeInputModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name should be 5 to 50 characters long", MinimumLength = 5)]
        public string VehicleTypeName { get; set; }

        [MaxLength(4000)]
        public string VehicleTypeDescription { get; set; }

        //TODO: Validation
        public VehicleCategory VehicleCategory { get; set; }
        public int VehicleCategoryId { get; set; }
    }

    public enum VehicleCategory
    {
        M1 = 1,
        M2 = 2,
        M3 = 3,

        N1 = 4,
        N2 = 5,
        N3 = 6,

        O1 = 7,
        O2 = 8,
        O3 = 9,
        O4 = 10,

        L1 = 11,
        L1e = 12,
        L2 = 13,
        L2e = 14,
        L3 = 15,
        L3e = 16,
        L4 = 17,
        L4e = 18,
        L5 = 19,
        L5e = 20,
        L6 = 21,
        L6e = 22,
        L7 = 23,
        L7e = 24,
    }
}
