using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;
using Supabase.Interfaces;
using System.IO;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : BaseController
    {
        private readonly Supabase.Client supabase;
        private readonly ILog log = LogManager.GetLogger(typeof(ImageController));

        public ImageController()
        {
            var builder =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true)
                    .AddEnvironmentVariables();

            IConfiguration config = builder.Build();

            string url = config.GetRequiredSection("SUPABASE_URL").Value;
            string key = config.GetRequiredSection("SUPABASE_KEY").Value;

            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            supabase = new Supabase.Client(url, key);
            supabase.InitializeAsync();
        }

        [HttpPost]
        public IActionResult UploadImage()
        {
            var uploadedImage = Request.Form.Files;

            if(uploadedImage == null)
            {
                return BadRequest();
            }

            try
            {
                foreach (IFormFile file in uploadedImage)
                {
                    string Filename = file.FileName;
                    Stream fileStream = file.OpenReadStream();

                    byte[] imageBytes;

                    using (var binaryReader = new BinaryReader(fileStream))
                    {
                        imageBytes = binaryReader.ReadBytes((int)fileStream.Length);
                    }

                    supabase.Storage
                        .From("product")
                        .Upload(imageBytes, Filename, new Supabase.Storage.FileOptions { CacheControl = "3600", Upsert = true });

                }
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                return StatusCode(500);
            }

        }
        
        [HttpDelete]
        [Route("{link}")]
        public IActionResult RemoveImage(string link)
        {
            if(link == null)
            {
                return BadRequest();
            }

            try
            {
                supabase.Storage
                    .From("product")
                    .Remove(link);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                return StatusCode(500);
            }

        }
    }
}
