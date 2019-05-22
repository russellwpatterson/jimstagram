using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Jimstagram.PostsApi.Repositories
{
    public interface IUploadsRepository
    {
        Task<string> Create(IFormFile image);
        Task<bool> Delete(string imageId);
    }
}