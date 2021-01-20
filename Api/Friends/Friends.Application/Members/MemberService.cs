using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using Newtonsoft.Json;
using DotNetHelpers.Models;
using Friends.Localization;
using Friends.Common.Models;
using Friends.Domain.Members;
using Friends.Application.Common;
using Friends.Application.Members.Models;
using Friends.Application.Members.Abstractions;
using Friends.Common.Helpers;

namespace Friends.Application.Members
{
    public class MemberService : BaseService, IMemberService
    {
        #region Fields
        private readonly IMembersUow _uow;
        #endregion

        #region Constructor
        public MemberService(IMembersUow uow, IOptionsSnapshot<AppSettings> options, IMapper mapper, ILogger<BaseService> logger)
            : base(options, mapper, logger)
        {
            _uow = uow;
        }
        #endregion

        #region Methods
        public async Task<PagedList<MemberDto>> GetAllAsync(BaseAdditional<BaseFilter> additional)
        {
            CheckPerPage(additional.Paging);
            var (members, totalCount) = await _uow.Members.GetAllAsync(additional);
            var memberDtos = _mapper.Map<List<MemberDto>>(members);
            return new PagedList<MemberDto>(memberDtos, GetPagingInfo(additional.Paging, totalCount), additional.Sorting);
        }

        public async Task<Result<MemberDto>> CreateAsync(MemberCreateRequest request)
        {
            try
            {
                var urlResult = await CuttlyHelpers.GetShorenerUrlasync(_settings, request.Website);
                if(!urlResult.Succeeded)
                {
                    var result = new Result<MemberDto>();
                    result.AddErrors(urlResult.Errors);
                    return result;
                }

                var member = new Member(Guid.NewGuid().ToString(), request.Name, urlResult.Data);
                _uow.Members.Add(member);
                await _uow.SaveAsync();
                return Result.Success(_mapper.Map<MemberDto>(member));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(MemberService)} => {nameof(CreateAsync)} => Member has not created => data: {JsonConvert.SerializeObject(request)}");
                return Result.Error<MemberDto>(ErrorMessages.MemberNotCreated);
            }
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
