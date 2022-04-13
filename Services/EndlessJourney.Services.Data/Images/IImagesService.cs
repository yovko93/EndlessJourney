namespace EndlessJourney.Services.Data.Images
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Models;
    using Microsoft.AspNetCore.Http;

    public interface IImagesService
    {
        Task<IEnumerable<Image>> UploadImages(IEnumerable<IFormFile> images, string wwwRootDirectory);
    }
}
