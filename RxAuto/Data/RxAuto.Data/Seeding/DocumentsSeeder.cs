namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Seeds <c>documents</c> to <see cref="Document"/> entity in database using <see cref="ApplicationDbContext"/>.
    /// </summary>
    public class DocumentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Documents.Any())
            {
                return;
            }

            List<string> documents = new List<string>()
            {
                "Свидетелство за регистрация на ППС част I (Може да бъде представено копие)",
                "Свидетелство за регистрация на ППС част II (Оригинал)",
                "Документ от съответния контролен орган за техническа изправност на монтирано съоръжение",
                "Документ за самоличност на лицето представило ППС на преглед",
            };

            foreach (string document in documents)
            {
                await dbContext.Documents.AddAsync(new Document
                {
                    Name = document,
                });
            }
        }
    }
}
