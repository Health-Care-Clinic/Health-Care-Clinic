using System;
using System.IO;
using System.Net.Http.Headers;
using System.Text.Json;
using Integration.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace Integration_API.Controller.ApiKeys
{
    [Route("hospital/[controller]")]
    [ApiController]
    public class PharmacyImageController : ControllerBase
    {
        private readonly IApiKeyService _apiKeyService;
        public PharmacyImageController(IApiKeyService apiKeyService)
        {
            _apiKeyService = apiKeyService;
        }
        
        [HttpPost]
        [Route("upload-image/{id}")]
        public IActionResult UploadPharmacyImage([FromRoute] int id)
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if(file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);

                    using(var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    Console.WriteLine(fileName);

                    _apiKeyService.EditPharmacyPicturePath(id, fileName);
                    
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, $"Internal server error: {e}");
            }
        }

        [HttpGet]
        [Route("{image}")]
        public string GetImage([FromRoute] string image)
        {
            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", image);
                var bytes = System.IO.File.ReadAllBytes(filePath);
                string file = Convert.ToBase64String(bytes);

                return JsonSerializer.Serialize(file);
            }
            catch(Exception e)
            {
                return JsonSerializer.Serialize("");
            }
            
        }
    }
}
