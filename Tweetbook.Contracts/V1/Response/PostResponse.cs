using System;
using System.Collections.Generic;

namespace TweetBookApi.Contracts.V1.Response
{
    public class PostResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TagResponse> Tags { get; set; }
    }
}
