namespace EndlessJourney.Services.Data.Images
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Common.Repositories;
    using EndlessJourney.Data.Models;
    using Microsoft.AspNetCore.Http;

    public class ImagesService : IImagesService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Image> imagesRepository;

        public ImagesService(
            IDeletableEntityRepository<Image> imagesRepository)
        {
            this.imagesRepository = imagesRepository;
        }

        public async Task<IEnumerable<Image>> UploadImages(IEnumerable<IFormFile> images, string wwwRootDirectory)
        {
            var imageList = new List<Image>();

            foreach (var image in images)
            {
                var name = image.FileName;
                var extension = Path.GetExtension(image.FileName).TrimStart('.');

                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var path = Path.Combine(wwwRootDirectory, "images/trips/", image.FileName); // Combine so you can save in wwwroot/images
                var pathToSaveInDb = Path.Combine("/images/trips/", image.FileName); // Combine the path with /images/ and then append the image.FileName

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                var newImage = new Image
                {
                    CreatedOn = DateTime.Now,
                    Name = name,
                    PathName = pathToSaveInDb,
                    Extension = extension,
                    // TripId = tripId,
                    // ShipId = shipId,
                };

                imageList.Add(newImage);

                await this.imagesRepository.AddAsync(newImage);
            }

            await this.imagesRepository.SaveChangesAsync();

            return imageList;
        }
    }
}
