using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jimstagram.PostsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Jimstagram.PostsApi.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly JimstagramContext _context;

        public PostsRepository(JimstagramContext context) => _context = context;

        public async Task<long> Create(Post post)
        {
            var postId = -1L;

            try
            {
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
                postId = post.Id;
            }
            catch (Exception)
            {
                // Log or something.
            }

            return postId;
        }

        public async Task<bool> Delete(long postId)
        {
            try 
            {                
                var postToDelete = await (from p in _context.Posts
                                          where p.Id == postId
                                          select p).FirstOrDefaultAsync();

                _context.Posts.Remove(postToDelete);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                // Log or something.
            }
            return false;
        }

        public async Task<Post> Get(long postId)
        {
            return await (from p in _context.Posts
                          where p.Id == postId
                          select p).FirstOrDefaultAsync();
        }

        public async Task<List<Post>> List()
        {
            return await _context.Posts.OrderByDescending(o => o.Id).ToListAsync();
        }
    }
}