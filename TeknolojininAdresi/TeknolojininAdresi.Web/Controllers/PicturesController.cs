using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeknolojininAdresi.Business.Abstract;
using static TeknolojininAdresi.Dto.PicturesDTO;

namespace TeknolojininAdresi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private IPicturesService _servicePictures;
        private IMapper _mapper;

        public PicturesController(IMapper mapper, IPicturesService servicePictures)
        {
            _servicePictures = servicePictures;
            _mapper = mapper;
        }

        [HttpGet("picturesProduct")]
        public async Task<IActionResult> GetPicturesProduct(int productId)
        {
            List<PicturesProductDTO> dto = _mapper.Map<List<PicturesProductDTO>>(await _servicePictures.GetPicturesByProId(productId));

            return Ok(dto);
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine("http://localhost:1228/", folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

            return Ok();
        }

    }
}