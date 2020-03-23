namespace RxAuto.Data.Common.Models
{
    using System;

    /// <summary>
    /// Contains <see cref="DateTime"/> properties <c>CreatedOn</c> and <c>ModifiedOn</c>.
    /// </summary>
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
