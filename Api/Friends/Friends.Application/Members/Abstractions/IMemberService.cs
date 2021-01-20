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
        Task<Result<MemberDto>> AddFriendAsync(string memberId, AddFriendRequest request);
    }
}
