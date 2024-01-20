using Karkathamizha.API.Controllers.BaseController;
using Karkathamizha.API.IService;
using Karkathamizha.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Serilog;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Karkathamizha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : BaseAPIController
    {
        private readonly IPublisherService _publisherService;
        public static IWebHostEnvironment _environment;
        public readonly IMemoryCache _cache;
        private const string pubCacheKey = "AllPublisher";
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public PublisherController(IPublisherService publisherService, IWebHostEnvironment environment, IMemoryCache cache)
        {
            _publisherService = publisherService;
            _environment = environment;
            _cache = cache;
        }

        [HttpGet()]
        [Route("GetAllPublisher")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Publisher))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Publisher>> GetAllPublisher()
        {
            await semaphore.WaitAsync();
            try
            {
                if (_cache.TryGetValue(pubCacheKey, out IEnumerable<Publisher>? publishers))
                {
                    return (IEnumerable<Publisher>)Ok(publishers);
                }
                else
                {
                    publishers = (IEnumerable<Publisher>?)await _publisherService?.GetAll();

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(60)) //If no requests are made for 60 sec, the data will be cleared in the In-Memory Cache
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600)) // is the value defining for how long the cached data should live, no matter how many times the data is requested
                        .SetPriority(CacheItemPriority.Normal)
                        .SetSize(1024);
                    _cache.Set(pubCacheKey, publishers, cacheEntryOptions);
                }
                return (IEnumerable<Publisher>)Ok(publishers);
            }
            finally
            {
                semaphore.Release();
            }
        }

        [HttpPost()]
        [Route("AddUpdatePublisher")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Publisher>> AddUpdatePublisher([FromForm] Publisher model, int id)
        {
            if (model is null)
            {
                Log.Error("Publisher model sent from client is null.");
                return BadRequest("Publisher object is null");
            }
            if (!ModelState.IsValid)
            {
                Log.Error("Invalid Publisher object sent from client.");
                return BadRequest("Invalid model object");
            }
            string path1 = _environment.WebRootPath + "\\PubLogo\\";

            if (Request.Form.Files.Count() > 0)
            {

            }

            foreach (IFormFile item in Request.Form.Files)
            {
                //path = Directory.GetCurrentDirectory() + "\\PubLogo\\";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }

                if (item.FileName.Length > 0)
                {
                    using (FileStream fileStream = System.IO.File.Create(path1 + item.FileName))
                    {
                        item.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                }
            }
            int publisherId = await _publisherService.AddUpdatePublisher(model);
            if (publisherId == -2)
                return Ok($"{model.PublisherName} already exists.");
            if (publisherId >= 0)
                return Ok($"Publisher Id = {publisherId} updated successfullly.");
            else
                return Ok($"New Publisher Id = {publisherId} Created successfullly.");
        }
    }
}
