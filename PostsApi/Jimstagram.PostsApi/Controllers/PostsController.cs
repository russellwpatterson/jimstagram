using Jimstagram.PostsApi.Helpers;
using Jimstagram.PostsApi.Models;
using Jimstagram.PostsApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jimstagram.PostsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostsRepository _repository;

        public PostsController(IPostsRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var posts = await _repository.List();

            return Ok(posts);
        }

        [HttpGet("{postId}"), Authorize]
        public async Task<IActionResult> Get(int postId)
        {
            var post = await _repository.Get(postId);

            if (post == null)
            {
                return NotFound($"Post with id {postId} was not found.");
            }

            return Ok(post);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] Post post)
        {
            
            // Get user out of validated JWT.
            post.Username = JwtHelper.GetUsername(User.Claims);

            var postId = await _repository.Create(post);

            if (postId <= 0)
            {
                return BadRequest("Unable to create post.");
            }

            return Ok(postId);
        }

        [HttpDelete("{postId}"), Authorize]
        public async Task<IActionResult> Delete(int postId)
        {
            var wasDeleted = await _repository.Delete(postId);

            if (!wasDeleted)
            {
                return NotFound($"Post with id {postId} was not found.");
            }

            return Ok();
        }
    }
}