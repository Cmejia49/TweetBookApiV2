using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetBookApi.Contracts.V1.Request
{
    public class TagRequest
    {
        public Guid PostId { get; set; }
        public string Text { get; set; }
    }
}
