using Jimstagram.PostsApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jimstagram.PostsApi.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IUploadsRepository _repository;

        public ImagesController(IUploadsRepository repository) => _repository = repository;

        [HttpPost, Authorize]
        public async Task<string> Create(IFormFile file)
        {
            return await _repository.Create(file);
        }

        [HttpDelete("{filename}"), Authorize]
        public async Task<bool> Delete(string filename)
        {
            return await _repository.Delete(filename);
        }
    }
}