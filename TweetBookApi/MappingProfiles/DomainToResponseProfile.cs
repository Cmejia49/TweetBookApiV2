using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBookApi.Contracts.V1.Response;
using TweetBookApi.Domain;

namespace TweetBookApi.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Post, PostResponse>();

            CreateMap<Tag, TagResponse>();
        }
    }
}
