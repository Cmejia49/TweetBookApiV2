using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetBookApi.Contracts.V1.Request
{
    public class CreateTagRequest
    {
        public string Text { get; set; }
        public Guid? PostId { get; set; }
    }
}
