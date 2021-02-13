namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;
    using RxAuto.Data.Seeding.JSONSeed;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class DocumentsSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly List<JDocument> documents;

        //------------- CONSTRUCTORS --------------
        public DocumentsSeeder(List<JDocument> documents)
        {
            this.documents = documents;
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Documents.Any())
            {
                return;
            }

            foreach (JDocument document in this.documents)
            {
                await dbContext.Documents.AddAsync(new Document
                {
                    Name = document.Name,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(
            }
        }
    }
}
