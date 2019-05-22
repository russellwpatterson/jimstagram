using System.Collections.Generic;
using System.Threading.Tasks;
using Jimstagram.PostsApi.Models;

namespace Jimstagram.PostsApi.Repositories
{
    public interface IPostsRepository
    {
        Task<List<Post>> List();
        Task<Post> Get(long postId);
        Task<long> Create(Post post);
        Task<bool> Delete(long postId);
    }
}