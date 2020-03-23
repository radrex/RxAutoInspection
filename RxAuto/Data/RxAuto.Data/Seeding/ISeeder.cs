namespace RxAuto.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Contains an asynchronous method for seeding data into a database.
    /// </summary>
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}
