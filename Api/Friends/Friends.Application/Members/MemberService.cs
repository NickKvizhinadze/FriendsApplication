using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using Friends.Common.Models;
using Friends.Application.Common;
using Friends.Application.Members.Abstractions;
using Friends.Application.Members.Models;
using System.Collections.Generic;
using DotNetHelpers.Models;

namespace Friends.Application.Members
{
    public class MemberService: BaseService, IMemberService
    {
        #region Fields
        private readonly IMembersUow _uow;
        #endregion

        #region Constructor
        public MemberService(IMembersUow uow, IOptionsSnapshot<AppSettings> options, IMapper mapper, ILogger<BaseService> logger)
            :base(options, mapper, logger)
        {
            _uow = uow;
        }
        #endregion

        #region Methods
        public async Task<object> GetAllAsync(BaseAdditional<BaseFilter> additional)
        {
            CheckPerPage(additional.Paging);
            var (members, totalCount) = await _uow.Members.GetAllAsync(additional);
            var memberDtos = _mapper.Map<List<MemberDto>>(members);
            return new PagedList<MemberDto>(memberDtos, GetPagingInfo(additional.Paging, totalCount), additional.Sorting);
        }
        #endregion
    }
}
