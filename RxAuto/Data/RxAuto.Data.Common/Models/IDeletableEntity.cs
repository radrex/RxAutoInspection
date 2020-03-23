namespace RxAuto.Data.Common.Models
{
    using System;

    /// <summary>
    /// Contains <see cref="bool"/> <c>IsDeleted</c> and <see cref="DateTime"/> <c>DeletedOn</c> properties, specifying that the entity is deletable.
    /// </summary>
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedOn { get; set; }
    }
}
