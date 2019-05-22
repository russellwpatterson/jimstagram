using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Jimstagram.PostsApi.Helpers;
using Jimstagram.PostsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Jimstagram.PostsApi.Repositories
{
    public class UploadsRepository : IUploadsRepository
    {
        private readonly IImageWriter _imageWriter;

        public UploadsRepository(IImageWriter imageWriter) => _imageWriter = imageWriter;

        public async Task<string> Create(IFormFile file)
        {
            var filename = string.Empty;

            try
            {
                filename = await _imageWriter.WriteUploadedImage(file);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return filename;
        }

        public async Task<bool> Delete(string filename)
        {
            try 
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/uploads", filename);

                await Task.Run(() => File.Delete(path));
                return true;
            }
            catch (Exception)
            {
                // Log or something.
            }
            return false;
        }
    }
}