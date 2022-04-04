namespace EndlessJourney.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var citiesList = new List<City>()
            {
                new City
                {
                    Name = "Varna",
                    ImageUrl = "https://c8.alamy.com/comp/2B3NG62/aerial-view-by-drone-of-state-opera-house-varna-bulgaria-europe-2B3NG62.jpg",
                    CountryId = 1,
                },
                new City
                {
                    Name = "Honolulu",
                    State = "Hawaii",
                    ImageUrl = "https://i.pinimg.com/736x/7a/34/ee/7a34eea94050b4c7d4760960be1d8888.jpg",
                    CountryId = 2,
                },
                new City
                {
                    Name = "Los Angeles",
                    State = "California",
                    ImageUrl = "https://media.istockphoto.com/photos/los-angeles-california-usa-downtown-aerial-cityscape-picture-id1256323866?k=20&m=1256323866&s=612x612&w=0&h=gym0JAKhLTGbQTzHO-7-nrG7rYblR2LDDYyZZfrZ7Hs=",
                    CountryId = 2,
                },
                new City
                {
                    Name = "San Francisco",
                    State = "California",
                    ImageUrl = "https://media.istockphoto.com/photos/the-golden-gate-bridge-at-sunset-san-francisco-ca-picture-id1145553643?k=20&m=1145553643&s=612x612&w=0&h=ipz9fs-xV7p-ETUReSAB5MzHyDFpOrMQSaUqbIILL1A=",
                    CountryId = 2,
                },
                new City
                {
                    Name = "Miami",
                    State = "Florida",
                    ImageUrl = "https://media.istockphoto.com/photos/miami-skyline-with-palm-trees-picture-id1147016023?k=20&m=1147016023&s=612x612&w=0&h=Dbxc0zBbQRFkr6ntCo9J963MVqFU5ANe1E7fjgI1q-c=",
                    CountryId = 2,
                },
                new City
                {
                    Name = "Fort Lauderdale",
                    State = "Florida",
                    ImageUrl = "https://media.istockphoto.com/photos/ft-lauderdale-florida-usa-picture-id1137760730?k=20&m=1137760730&s=612x612&w=0&h=INb3eyt7ZDXozC-gYE-g28w45QbDnfTWSSbmZWKXZ28=",
                    CountryId = 2,
                },
                new City
                {
                    Name = "New York",
                    State = "New York",
                    ImageUrl = "https://media.istockphoto.com/photos/the-statue-of-liberty-with-the-one-world-trade-building-center-over-picture-id1169074379?k=20&m=1169074379&s=612x612&w=0&h=weuMjib73CU2dboPcjaiPr1bl5zk0YtviocdSka-ZeA=",
                    CountryId = 2,
                },
                new City
                {
                    Name = "Southampton",
                    ImageUrl = "https://media.istockphoto.com/photos/ocean-village-marina-in-southampton-picture-id639407168?k=20&m=639407168&s=612x612&w=0&h=rdFxHRQW0aF03MORxoEfrYdKqyQKnfqg16vs6eHuNe0=",
                    CountryId = 3,
                },
                new City
                {
                    Name = "Liverpool",
                    ImageUrl = "https://media.istockphoto.com/photos/the-three-graces-on-liverpools-pier-one-picture-id481992744?k=20&m=481992744&s=612x612&w=0&h=bEa7_xPtQRPG22cpWAbhJ_0ljpfh6ayxQ14zWd5dzEU=",
                    CountryId = 3,
                },
                new City
                {
                    Name = "Vancouver",
                    ImageUrl = "https://media.istockphoto.com/photos/downtown-or-island-picture-id962362664?k=20&m=962362664&s=612x612&w=0&h=sXRCNZ9jbctRmKVHyjnRKXS4IsNidU1Ty_1xWNb8y30=",
                    CountryId = 4,
                },
                new City
                {
                    Name = "Ensenada",
                    ImageUrl = "https://media.istockphoto.com/photos/port-of-ensenada-and-mexican-flag-picture-id159021515?k=20&m=159021515&s=612x612&w=0&h=DNEVSpk5LnyPH2g23REtvd_p5Su9HwF0FgOKLCHk_5Y=",
                    CountryId = 5,
                },
                new City
                {
                    Name = "Nassau",
                    ImageUrl = "https://media.istockphoto.com/photos/paradise-island-nassau-bahamas-picture-id1208860196?k=20&m=1208860196&s=612x612&w=0&h=jtB3SAbsLljy4USg-3q-k1Ugey-RLC3nteVmzjiWXqE=",
                    CountryId = 6,
                },
                new City
                {
                    Name = "Barcelona",
                    ImageUrl = "https://media.istockphoto.com/photos/park-guell-in-barcelona-spain-picture-id148543868?k=20&m=148543868&s=612x612&w=0&h=2pCAExLqNq9rKpCiTKb6Z2YKV-SxM35YG7WQVMimhmQ=",
                    CountryId = 7,
                },
                new City
                {
                    Name = "Lisbon",
                    ImageUrl = "https://media.istockphoto.com/photos/lisbon-at-sunset-portugal-picture-id1125704871?k=20&m=1125704871&s=612x612&w=0&h=BiDHuJNizxp9vFztteMOp_2i7SZDUUNw818Cvw1mb4o=",
                    CountryId = 8,
                },
                new City
                {
                    Name = "Le Havre",
                    ImageUrl = "https://media.istockphoto.com/photos/entrance-sign-to-le-havre-normandy-france-picture-id1083434266?k=20&m=1083434266&s=612x612&w=0&h=mq7DKkrwIPiEBysdHbia8-RU1xHkQAmTI3eVsz-kqkY=",
                    CountryId = 9,
                },
                new City
                {
                    Name = "Hamburg",
                    ImageUrl = "https://media.istockphoto.com/photos/hamburg-picture-id532269566?k=20&m=532269566&s=612x612&w=0&h=oTI4shbl9c14zOALyC5zh9ANTepdNOwwysaSArm-7ro=",
                    CountryId = 10,
                },
                new City
                {
                    Name = "Hong Kong",
                    ImageUrl = "https://media.istockphoto.com/photos/hong-kong-island-picture-id516418718?k=20&m=516418718&s=612x612&w=0&h=vau6fLb2vNuG9aeo9s8wASDbT6JV0wssQ_YfwKqDxzI=",
                    CountryId = 11,
                },
                new City
                {
                    Name = "Sydney",
                    ImageUrl = "https://media.istockphoto.com/photos/beautiful-opera-house-view-at-twilight-picture-id540229848?k=20&m=540229848&s=612x612&w=0&h=zhQlzJAq1yqyN6PBLQyfeOCInh0q3h1vVP2Fxywh17U=",
                    CountryId = 12,
                },
                new City
                {
                    Name = "Dubai",
                    ImageUrl = "https://media.istockphoto.com/photos/dubai-marina-picture-id467829216?k=20&m=467829216&s=612x612&w=0&h=W1NGHMkLoYcPxb-RKqbe0jnH8-W35c0hcoxaN29PqMA=",
                    CountryId = 13,
                },
            };

            foreach (City city in citiesList)
            {
                var dbCity = await dbContext.Countries
                    .FirstOrDefaultAsync(x => x.Name == city.Name);

                if (dbCity == null)
                {
                    await dbContext.Cities.AddAsync(city);
                }
            }
        }
    }
}
