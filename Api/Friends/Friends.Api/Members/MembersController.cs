using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetHelpers.Models;
using DotNetHelpers.MvcCore;
using Friends.Application.Common;
using Friends.Application.Members.Abstractions;
using Friends.Application.Members.Models;
using System;
using System.Net.Http;

namespace Friends.Api.Members
{
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

        [HttpPost]
        //TODO: add authorize attribute
        public async Task<ActionResult<PagedList<MemberDto>>> CreateAsync([FromBody] MemberCreateRequest request)
        {
            var members = await _service.CreateAsync(request);
            return Ok(members);
        }
        #endregion
    }
}
