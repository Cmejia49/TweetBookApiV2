using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBookApi.Contracts.V1;
using TweetBookApi.Contracts.V1.Request;
using TweetBookApi.Contracts.V1.Response;
using TweetBookApi.Domain;
using TweetBookApi.Services;

namespace TweetBookApi.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TagController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public TagController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Tags.GetAll)]
        [Authorize(Policy = "TagViewer")]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _postService.GetAllTagAsync();
            
            return Ok(_mapper.Map<List<TagResponse>>(tags));
        }

        [HttpPost(ApiRoutes.Tags.Create)]
        public async Task<IActionResult> Create(CreateTagRequest request)
        {
            if(!ModelState.IsValid)
            {

            }

            var tag = new Tag
            {
               Text = request.Text,
               PostId = request.PostId
            };

            await _postService.CreateTagAsync(tag);
            return Ok();
        }
    }
}
