using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DotNetHelpers.Models;
using DotNetHelpers.MvcCore;
using Friends.Application.Common;
using Friends.Application.Members.Models;
using Friends.Application.Members.Abstractions;
using System.Collections.Generic;

namespace Friends.Api.Members
{
    [Authorize]
    public class MembersController: ApiBaseController
    {
        #region Fields
        private readonly IMemberService _service;
        #endregion

        #region Constructors
        public MembersController(IMemberService service)
        {
            _service = service;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<ActionResult<PagedList<MemberDto>>> GetAllAsync(BaseAdditional<BaseFilter> additional)
        {
            var members = await _service.GetAllAsync(additional);
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetAsync(string id)
        {
            var result = await _service.GetAsync(id);
            return Ok(result);
        }

        [HttpGet("{id}/GetExperts")]
        public async Task<ActionResult<MemberDto>> GetExpertsAsync(string id, string heading)
        {
            var result = await _service.GetExpertsAsync(id, heading);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<MemberDto>> CreateAsync([FromBody] MemberCreateRequest request)
        {
            var result = await _service.CreateAsync(request);
            return CustomResult(result);
        }

        [HttpPost("{id}/AddFriend")]
        public async Task<ActionResult<MemberDto>> AddFriendAsync(string id, [FromBody] AddFriendRequest request)
        {
            var members = await _service.AddFriendAsync(id, request);
            return CustomResult(members);
        }

        [HttpGet("GetDropdownList")]
        public async Task<ActionResult<List<Dropdown<string>>>> GetDropdownListAsync(string searchValue)
        {
            var members = await _service.GetAsDropdownListAsync(searchValue);
            return Ok(members);
        }
        #endregion
    }
}
