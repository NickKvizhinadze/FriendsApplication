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
using Friends.Common.Helpers;
using Friends.Domain.Members;
using Friends.Application.Common;
using Friends.Application.Members.Models;
using Friends.Application.Members.Abstractions;
using System.Linq;

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

        public async Task<MemberDto> GetAsync(string id)
        {
            var member = await _uow.Members.GetAsync(id);
            return _mapper.Map<MemberDto>(member);
        }

        public async Task<List<MemberDto>> GetExpertsAsync(string id, string heading)
        {
            var member = await _uow.Members.GetExpertsAsync(id, heading);
            return _mapper.Map<List<MemberDto>>(member);
        }

        public async Task<Result<MemberDto>> CreateAsync(MemberCreateRequest request)
        {
            try
            {
                if (await _uow.Members.ExistsAsync(request.Name))
                    return Result.Error<MemberDto>(ErrorMessages.MemberAlreadyExists);

                var urlResult = await HttpHelper.GetShorenerUrlasync(_settings, request.Website);
                if (!urlResult.Succeeded)
                {
                    var result = new Result<MemberDto>();
                    result.AddErrors(urlResult.Errors);
                    return result;
                }

                var headingsResult = (await HttpHelper.GetHeadings(request.Website))
                    .Select(h => new Heading(Guid.NewGuid().ToString(), h.Key, h.Value))
                    .ToList();


                var member = new Member(Guid.NewGuid().ToString(), request.Name, urlResult.Data, headingsResult);
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

        public async Task<Result<MemberDto>> AddFriendAsync(string memberId, AddFriendRequest request)
        {
            try
            {
                var member = await _uow.Members.GetAsync(memberId);
                if (member is null)
                    return Result.Error<MemberDto>(ErrorMessages.MemberNotFound);
                var friend = await _uow.Members.GetAsync(request.FriendId);
                if (friend is null)
                    return Result.Error<MemberDto>(ErrorMessages.FriendNotFound);

                if (member.Friends.Any(x => x.Friend2 == friend))
                    return Result.Error<MemberDto>(ErrorMessages.AlreadyFriends);

                var memberFriend = new List<MemberFriend> {
                    new MemberFriend(Guid.NewGuid().ToString(), member.Id, friend.Id),
                    new MemberFriend(Guid.NewGuid().ToString(), friend.Id, member.Id)
                };
                _uow.MemberFriends.AddRange(memberFriend);
                await _uow.SaveAsync();
                return Result.Success(_mapper.Map<MemberDto>(member));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(MemberService)} => {nameof(CreateAsync)} => Member has not created => data: {JsonConvert.SerializeObject(request)}");
                return Result.Error<MemberDto>(ErrorMessages.FriendNotAdded);
            }
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
