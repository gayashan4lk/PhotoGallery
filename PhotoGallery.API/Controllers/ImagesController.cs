using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.API.Entities;
using PhotoGallery.API.Repositories;

namespace PhotoGallery.API.Controllers;

[Route("api/images")]
[ApiController]
public class ImagesController(IGalleryRepository repository, IWebHostEnvironment webHost, IMapper mapper) : ControllerBase
{
    private readonly IGalleryRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    private readonly IWebHostEnvironment _webHost = webHost ?? throw new ArgumentNullException(nameof(webHost));

    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Image>>> GetImages()
    {
        var imagesFromRepo = await _repository.GetImagesAsync();

        var imagesToReturn  = _mapper.Map<IEnumerable<Image>>(imagesFromRepo);

        return Ok(imagesToReturn);
    }

}
