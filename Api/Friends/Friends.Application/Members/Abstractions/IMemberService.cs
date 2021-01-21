using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetHelpers.Models;
using Friends.Application.Common;
using Friends.Application.Members.Models;

namespace Friends.Application.Members.Abstractions
{
    public interface IMemberService
    {
        Task<PagedList<MemberDto>> GetAllAsync(BaseAdditional<BaseFilter> additional);
        Task<Result<MemberDto>> CreateAsync(MemberCreateRequest request);
        Task<Result> AddFriendAsync(string memberId, AddFriendRequest request);
        Task<MemberDto> GetAsync(string id);
        Task<ExpertsDto> GetExpertsAsync(string id, string headingId);
        Task<List<Dropdown<string>>> GetAsDropdownListAsync(string searchValue);
    }
}
