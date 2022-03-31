namespace EndlessJourney.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class RoomBenefitsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roomBenefitsList = new List<RoomBenefit>()
            {
                new RoomBenefit
                {
                    RoomId = 1,
                    BenefitId = 1,
                },
                new RoomBenefit
                {
                    RoomId = 1,
                    BenefitId = 2,
                },
                new RoomBenefit
                {
                    RoomId = 1,
                    BenefitId = 3,
                },
                new RoomBenefit
                {
                    RoomId = 1,
                    BenefitId = 4,
                },
                new RoomBenefit
                {
                    RoomId = 1,
                    BenefitId = 11,
                },
                new RoomBenefit
                {
                    RoomId = 2,
                    BenefitId = 1,
                },
                new RoomBenefit
                {
                    RoomId = 2,
                    BenefitId = 2,
                },
                new RoomBenefit
                {
                    RoomId = 2,
                    BenefitId = 6,
                },
                new RoomBenefit
                {
                    RoomId = 2,
                    BenefitId = 7,
                },
                new RoomBenefit
                {
                    RoomId = 2,
                    BenefitId = 11,
                },
                new RoomBenefit
                {
                    RoomId = 3,
                    BenefitId = 1,
                },
                new RoomBenefit
                {
                    RoomId = 3,
                    BenefitId = 2,
                },
                new RoomBenefit
                {
                    RoomId = 3,
                    BenefitId = 9,
                },
                new RoomBenefit
                {
                    RoomId = 3,
                    BenefitId = 10,
                },
                new RoomBenefit
                {
                    RoomId = 3,
                    BenefitId = 12,
                },
                new RoomBenefit
                {
                    RoomId = 4,
                    BenefitId = 1,
                },
                new RoomBenefit
                {
                    RoomId = 4,
                    BenefitId = 7,
                },
                new RoomBenefit
                {
                    RoomId = 4,
                    BenefitId = 8,
                },
                new RoomBenefit
                {
                    RoomId = 4,
                    BenefitId = 10,
                },
                new RoomBenefit
                {
                    RoomId = 4,
                    BenefitId = 12,
                },
            };

            foreach (RoomBenefit roomBenefit in roomBenefitsList)
            {
                var dbRoomBenefit = await dbContext.RoomBenefits
                    .FirstOrDefaultAsync(x =>
                        x.RoomId == roomBenefit.RoomId
                        && x.BenefitId == roomBenefit.BenefitId);

                if (dbRoomBenefit == null)
                {
                    await dbContext.RoomBenefits.AddAsync(roomBenefit);
                }
            }
        }
    }
}
