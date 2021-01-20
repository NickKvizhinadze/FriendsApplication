using DotNetHelpers.MvcCore;
using Friends.Application.Common;
using Friends.Application.Members.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll(BaseAdditional<BaseFilter> additional)
        {
            var members = await _service.GetAllAsync(additional);
            return Ok(members);
        }
        #endregion
    }
}
