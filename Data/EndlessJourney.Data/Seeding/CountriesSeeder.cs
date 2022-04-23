namespace EndlessJourney.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CountriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var countriesList = new List<Country>()
            {
                new Country
                {
                    Name = "Bulgaria",
                    Capital = "Sofia",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Varna",
                            Description = "Varna is a port city and seaside resort on Bulgaria's Black Sea, next to the coastal resorts of Golden Sands, St. Konstantin and Albena. It's famous for the \"Gold of Varna\", 6,000-year-old Thracian jewelry discovered in a necropolis, which is displayed inside the Archaeological Museum, along with Greek, Roman and Ottoman antiquities.",
                            ImageUrl = "https://c8.alamy.com/comp/2B3NG62/aerial-view-by-drone-of-state-opera-house-varna-bulgaria-europe-2B3NG62.jpg",
                        },
                    },
                },
                new Country
                {
                    Name = "USA",
                    Capital = "Washington, D.C.",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Honolulu",
                            Description = "Honolulu, on the island of Oahu’s south shore, is capital of Hawaii and gateway to the U.S. island chain. The Waikiki neighborhood is its center for dining, nightlife and shopping, famed for its iconic crescent beach backed by palms and high-rise hotels, with volcanic Diamond Head crater looming in the distance.",
                            State = "Hawaii",
                            ImageUrl = "https://i.pinimg.com/736x/7a/34/ee/7a34eea94050b4c7d4760960be1d8888.jpg",
                        },
                        new City
                        {
                            Name = "Los Angeles",
                            Description = "Los Angeles is a sprawling Southern California city and the center of the nation’s film and television industry. Near its iconic Hollywood sign, studios such as Paramount Pictures, Universal and Warner Brothers offer behind-the-scenes tours. On Hollywood Boulevard, the Walk of Fame honors thousands of luminaries and vendors sell maps to stars’ homes.",
                            State = "California",
                            ImageUrl = "https://media.istockphoto.com/photos/los-angeles-california-usa-downtown-aerial-cityscape-picture-id1256323866?k=20&m=1256323866&s=612x612&w=0&h=gym0JAKhLTGbQTzHO-7-nrG7rYblR2LDDYyZZfrZ7Hs=",
                        },
                        new City
                        {
                            Name = "San Francisco",
                            Description = "San Francisco, officially the City and County of San Francisco, is a cultural, commercial, and financial center in the U.S. state of California.",
                            State = "California",
                            ImageUrl = "https://media.istockphoto.com/photos/the-golden-gate-bridge-at-sunset-san-francisco-ca-picture-id1145553643?k=20&m=1145553643&s=612x612&w=0&h=ipz9fs-xV7p-ETUReSAB5MzHyDFpOrMQSaUqbIILL1A=",
                        },
                        new City
                        {
                            Name = "Miami",
                            Description = "Miami, officially the City of Miami, is a coastal metropolis located in Miami-Dade County in southeastern Florida. With a population of 442,241 as of the 2020 census, it is the second-most populous city in Florida, eleventh-most populous city in the Southeast, and 44th-most populous city in the United States.",
                            State = "Florida",
                            ImageUrl = "https://media.istockphoto.com/photos/miami-skyline-with-palm-trees-picture-id1147016023?k=20&m=1147016023&s=612x612&w=0&h=Dbxc0zBbQRFkr6ntCo9J963MVqFU5ANe1E7fjgI1q-c=",
                        },
                        new City
                        {
                            Name = "Fort Lauderdale",
                            Description = "Fort Lauderdale is a city on Florida's southeastern coast, known for its beaches and boating canals. The Strip is a promenade running along oceanside highway A1A. It's lined with upscale outdoor restaurants, bars, boutiques and luxury hotels.",
                            State = "Florida",
                            ImageUrl = "https://media.istockphoto.com/photos/ft-lauderdale-florida-usa-picture-id1137760730?k=20&m=1137760730&s=612x612&w=0&h=INb3eyt7ZDXozC-gYE-g28w45QbDnfTWSSbmZWKXZ28=",
                        },
                        new City
                        {
                            Name = "New York",
                            Description = "New York City comprises 5 boroughs sitting where the Hudson River meets the Atlantic Ocean. At its core is Manhattan, a densely populated borough that’s among the world’s major commercial, financial and cultural centers. Its iconic sites include skyscrapers such as the Empire State Building and sprawling Central Park.",
                            State = "New York",
                            ImageUrl = "https://media.istockphoto.com/photos/the-statue-of-liberty-with-the-one-world-trade-building-center-over-picture-id1169074379?k=20&m=1169074379&s=612x612&w=0&h=weuMjib73CU2dboPcjaiPr1bl5zk0YtviocdSka-ZeA=",
                        },
                    },
                },
                new Country
                {
                    Name = "England",
                    Capital = "London",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Southampton",
                            Description = "Southampton is a port city on England’s south coast. It’s home to the SeaCity Museum, with an interactive model of the Titanic, which departed from Southampton in 1912. Nearby, Southampton City Art Gallery specialises in modern British art.",
                            ImageUrl = "https://media.istockphoto.com/photos/ocean-village-marina-in-southampton-picture-id639407168?k=20&m=639407168&s=612x612&w=0&h=rdFxHRQW0aF03MORxoEfrYdKqyQKnfqg16vs6eHuNe0=",
                        },
                        new City
                        {
                            Name = "Liverpool",
                            Description = "Liverpool is a maritime city in northwest England, where the River Mersey meets the Irish Sea. A key trade and migration port from the 18th to the early 20th centuries, it's also, famously, the hometown of The Beatles.",
                            ImageUrl = "https://media.istockphoto.com/photos/the-three-graces-on-liverpools-pier-one-picture-id481992744?k=20&m=481992744&s=612x612&w=0&h=bEa7_xPtQRPG22cpWAbhJ_0ljpfh6ayxQ14zWd5dzEU=",
                        },
                    },
                },
                new Country
                {
                    Name = "Canada",
                    Capital = "Ottawa",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Vancouver",
                            Description = "Vancouver, a bustling west coast seaport in British Columbia, is among Canada’s densest, most ethnically diverse cities. A popular filming location, it’s surrounded by mountains, and also has thriving art, theatre and music scenes.",
                            ImageUrl = "https://media.istockphoto.com/photos/downtown-or-island-picture-id962362664?k=20&m=962362664&s=612x612&w=0&h=sXRCNZ9jbctRmKVHyjnRKXS4IsNidU1Ty_1xWNb8y30=",
                        },
                    },
                },
                new Country
                {
                    Name = "Mexico",
                    Capital = "Mexico City",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Ensenada",
                            Description = "Ensenada is a port city on the Pacific coast of Mexico’s Baja California peninsula. At its heart is the harbor and waterfront area with the Malecón promenade. Once a casino, the Riviera de Ensenada is now a cultural center. The nearby Museum of History and the Regional Historical Museum trace the area’s people and past.",
                            ImageUrl = "https://media.istockphoto.com/photos/port-of-ensenada-and-mexican-flag-picture-id159021515?k=20&m=159021515&s=612x612&w=0&h=DNEVSpk5LnyPH2g23REtvd_p5Su9HwF0FgOKLCHk_5Y=",
                        },
                    },
                },
                new Country
                {
                    Name = "Bahamas",
                    Capital = "Nassau",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Nassau",
                            Description = "Nassau is the capital of the Bahamas. It lies on the island of New Providence, with neighboring Paradise Island accessible via Nassau Harbor bridges. A popular cruise-ship stop, the city has a hilly landscape and is known for beaches as well as its offshore coral reefs, popular for diving and snorkeling.",
                            ImageUrl = "https://media.istockphoto.com/photos/paradise-island-nassau-bahamas-picture-id1208860196?k=20&m=1208860196&s=612x612&w=0&h=jtB3SAbsLljy4USg-3q-k1Ugey-RLC3nteVmzjiWXqE=",
                        },
                    },
                },
                new Country
                {
                    Name = "Spain",
                    Capital = "Madrid",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Barcelona",
                            Description = "Barcelona, the cosmopolitan capital of Spain’s Catalonia region, is known for its art and architecture. The fantastical Sagrada Família church and other modernist landmarks designed by Antoni Gaudí dot the city.",
                            ImageUrl = "https://media.istockphoto.com/photos/park-guell-in-barcelona-spain-picture-id148543868?k=20&m=148543868&s=612x612&w=0&h=2pCAExLqNq9rKpCiTKb6Z2YKV-SxM35YG7WQVMimhmQ=",
                        },
                        new City
                        {
                            Name = "Bilbao",
                            Description = "Bilbao, an industrial port city in northern Spain, is surrounded by green mountains. It’s the de facto capital of Basque Country, with a skyscraper-filled downtown. It’s famed for the Frank Gehry–designed Guggenheim Museum Bilbao, which sparked revitalization when it opened in 1997.",
                            ImageUrl = "https://media.istockphoto.com/photos/the-guggenheim-museum-in-bilbao-picture-id1159174157?k=20&m=1159174157&s=612x612&w=0&h=88Vx9tC9X7SFzhCGDkEdvReW7KYxuVTB5kmZiAipk3k=",
                        },
                    },
                },
                new Country
                {
                    Name = "Portugal",
                    Capital = "Lisbon",
                    Cities = new List<City>()
                    {
                       new City
                        {
                            Name = "Lisbon",
                            Description = "Lisbon is Portugal’s hilly, coastal capital city. From imposing São Jorge Castle, the view encompasses the old city’s pastel-colored buildings, Tagus Estuary and Ponte 25 de Abril suspension bridge. Nearby, the National Azulejo Museum displays 5 centuries of decorative ceramic tiles.",
                            ImageUrl = "https://media.istockphoto.com/photos/lisbon-at-sunset-portugal-picture-id1125704871?k=20&m=1125704871&s=612x612&w=0&h=BiDHuJNizxp9vFztteMOp_2i7SZDUUNw818Cvw1mb4o=",
                        },
                    },
                },
                new Country
                {
                    Name = "France",
                    Capital = "Paris",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Le Havre",
                            Description = "Le Havre is a major port in northern France's Normandy region, where the Seine River meets the English Channel. It's joined to the city across the estuary, Honfleur, by the Pont de Normandie cable-stayed bridge.",
                            ImageUrl = "https://media.istockphoto.com/photos/entrance-sign-to-le-havre-normandy-france-picture-id1083434266?k=20&m=1083434266&s=612x612&w=0&h=mq7DKkrwIPiEBysdHbia8-RU1xHkQAmTI3eVsz-kqkY=",
                        },
                        new City
                        {
                            Name = "Marseille",
                            Description = "Marseille, a port city in southern France, has been a crossroads of immigration and trade since its founding by the Greeks circa 600 B.C. At its heart is the Vieux-Port (Old Port), where fishmongers sell their catch along the boat-lined quay.",
                            ImageUrl = "https://media.istockphoto.com/photos/view-of-the-old-port-of-marseille-france-picture-id928497156?k=20&m=928497156&s=612x612&w=0&h=5HnjeEp3E__ENvrnUjtWSPanGJY6SuGcfxzKvGMYRjo=",
                        },
                    },
                },
                new Country
                {
                    Name = "Germany",
                    Capital = "Berlin",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Hamburg",
                            Description = "Hamburg, a major port city in northern Germany, is connected to the North Sea by the Elbe River. It's crossed by hundreds of canals, and also contains large areas of parkland. Near its core, Inner Alster lake is dotted with boats and surrounded by cafes.",
                            ImageUrl = "https://media.istockphoto.com/photos/hamburg-picture-id532269566?k=20&m=532269566&s=612x612&w=0&h=oTI4shbl9c14zOALyC5zh9ANTepdNOwwysaSArm-7ro=",
                        },
                    },
                },
                new Country
                {
                    Name = "China",
                    Capital = "Beijing",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Hong Kong",
                            Description = "Hong Kong, officially the Hong Kong Special Administrative Region of the People's Republic of China, is a city and special administrative region of China on the eastern Pearl River Delta in South China.",
                            ImageUrl = "https://media.istockphoto.com/photos/hong-kong-island-picture-id516418718?k=20&m=516418718&s=612x612&w=0&h=vau6fLb2vNuG9aeo9s8wASDbT6JV0wssQ_YfwKqDxzI=",
                        },
                    },
                },
                new Country
                {
                    Name = "Australia",
                    Capital = "Canberra",
                    Cities = new List<City>()
                    {
                       new City
                        {
                            Name = "Sydney",
                            Description = "Sydney, capital of New South Wales and one of Australia's largest cities, is best known for its harbourfront Sydney Opera House, with a distinctive sail-like design.",
                            ImageUrl = "https://media.istockphoto.com/photos/beautiful-opera-house-view-at-twilight-picture-id540229848?k=20&m=540229848&s=612x612&w=0&h=zhQlzJAq1yqyN6PBLQyfeOCInh0q3h1vVP2Fxywh17U=",
                        },
                    },
                },
                new Country
                {
                    Name = "United Arab Emirates",
                    Capital = "Abu Dhabi",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Dubai",
                            Description = "Dubai is a city and emirate in the United Arab Emirates known for luxury shopping, ultramodern architecture and a lively nightlife scene. Burj Khalifa, an 830m-tall tower, dominates the skyscraper-filled skyline.",
                            ImageUrl = "https://media.istockphoto.com/photos/dubai-marina-picture-id467829216?k=20&m=467829216&s=612x612&w=0&h=W1NGHMkLoYcPxb-RKqbe0jnH8-W35c0hcoxaN29PqMA=",
                        },
                    },
                },
                new Country
                {
                    Name = "Italy",
                    Capital = "Rome",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Civitavecchia (Rome)",
                            Description = "Civitavecchia is a coastal town northwest of Rome, in Italy. Built in the 2nd century, the Port of Civitavecchia still retains some of its original features, like the Roman Dock. The port area also includes the 16th-century Michelangelo Fort.",
                            ImageUrl = "https://media.istockphoto.com/photos/colosseum-in-rome-and-morning-sun-italy-picture-id539115110?k=20&m=539115110&s=612x612&w=0&h=_vaURTolEYbJoQuVziXEmquo_QOW_P5A_I82owLx-D0=",
                        },
                    },
                },
                new Country
                {
                    Name = "Brazil",
                    Capital = "Brazil",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Rio de Janeiro",
                            Description = "Rio de Janeiro is a huge seaside city in Brazil, famed for its Copacabana and Ipanema beaches, 38m Christ the Redeemer statue atop Mount Corcovado and for Sugarloaf Mountain, a granite peak with cable cars to its summit.",
                            ImageUrl = "https://media.istockphoto.com/photos/rio-de-janeiro-aerial-picture-id534215078?k=20&m=534215078&s=612x612&w=0&h=m_f-fdLvL5w4IWPMBckpOD8TQVweNnVXkhlbHTIwYjo=",
                        },
                    },
                },
                new Country
                {
                    Name = "Chile",
                    Capital = "Santiago",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Vina del Mar",
                            Description = "Viña del Mar is a coastal resort city northwest of Santiago, Chile. It’s known for its gardens, beaches and high-rise buildings. Quinta Vergara Park is home to the Quinta Vergara Amphitheater.",
                            ImageUrl = "https://media.istockphoto.com/photos/estero-river-promenade-vina-del-mar-chile-picture-id1068794492?k=20&m=1068794492&s=612x612&w=0&h=R0_HjxBWImLBwI2y-nbXG5RduJDGwnmc7OaIOlghHH0=",
                        },
                    },
                },
                new Country
                {
                    Name = "Argentina",
                    Capital = "Buenos Aires",
                    Cities = new List<City>()
                    {
                        new City
                        {
                            Name = "Buenos Aires",
                            Description = "Buenos Aires is Argentina’s big, cosmopolitan capital city. Its center is the Plaza de Mayo, lined with stately 19th-century buildings including Casa Rosada, the iconic, balconied presidential palace.",
                            ImageUrl = "https://media.istockphoto.com/photos/the-capital-city-of-buenos-aires-in-argentina-picture-id685850438?k=20&m=685850438&s=612x612&w=0&h=kWL59D1zjCRTeYjAHfBRsKmbqCO9Sz068igjOUDkkmk=",
                        },
                    },
                },
            };

            foreach (Country country in countriesList)
            {
                var dbCountry = await dbContext.Countries
                    .FirstOrDefaultAsync(x => x.Name == country.Name);

                if (dbCountry == null)
                {
                    await dbContext.Countries.AddAsync(country);
                }
            }
        }
    }
}
