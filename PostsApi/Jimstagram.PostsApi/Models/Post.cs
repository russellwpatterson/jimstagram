using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jimstagram.PostsApi.Models
{
    public partial class Post
    {
        [Key]
        public long Id { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public string ImageFilename { get; set; }
        public int SoGoods { get; set; }
        public int ThatsDecents { get; set; }
        public int NotSoGoods { get; set; }
    }
}
