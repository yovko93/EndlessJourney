namespace EndlessJourney.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BenefitsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var benefitsList = new List<Benefit>()
            {
                new Benefit
                {
                    Name = "A bottle of sparkling wine to welcome you to your Inside stateroom.",
                },
                new Benefit
                {
                    Name = "A king-sized bed, satellite TV and tea and coffee making facilities.",
                },
                new Benefit
                {
                    Name = "Sumptuous cotton sheets and soft bathrobes. ",
                },
                new Benefit
                {
                    Name = "Our nightly turndown service, with a 'good night' chocolate on your pillow.",
                },
                new Benefit
                {
                    Name = "Writing desk with stationery and a sofa to lounge on.",
                },
                new Benefit
                {
                    Name = "Bathroom with an invigorating shower, Penhaligon's toiletries and robes and slippers.",
                },
                new Benefit
                {
                    Name = "Mini-bar and complimentary room service 24 hours a day.",
                },
                new Benefit
                {
                    Name = "Living area with desk and stationery. ",
                },
                new Benefit
                {
                    Name = "A personal steward to keep your stateroom in fine order.",
                },
                new Benefit
                {
                    Name = "A window offering outside views.",
                },
                new Benefit
                {
                    Name = "Room size approximately 157-194 sq. ft. (exact size differs dependent on stateroom position and grade).",
                },
                new Benefit
                {
                    Name = "Room size approximately 248-269 sq. ft. (exact size differs dependent on stateroom position and grade).",
                },
            };

            foreach (Benefit benefit in benefitsList)
            {
                var dbBenefit = await dbContext.Benefits
                    .FirstOrDefaultAsync(x => x.Name == benefit.Name);

                if (dbBenefit == null)
                {
                    await dbContext.Benefits.AddAsync(benefit);
                }
            }
        }
    }
}
