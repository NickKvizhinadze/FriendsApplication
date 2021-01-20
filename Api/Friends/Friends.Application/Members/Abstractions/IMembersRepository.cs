using System.Threading.Tasks;
using System.Collections.Generic;
using Friends.Domain.Members;
using Friends.Application.Common;
using Friends.Application.Common.Abstractions;

namespace Friends.Application.Members.Abstractions
{
    public interface IMembersRepository : IBaseRepository<Member, string>
    {
        Task<(List<Member> users, int totalCount)> GetAllAsync(BaseAdditional<BaseFilter> additional);
        Task<Member> GetAsFriendAsync(string id);
        Task<bool> ExistsAsync(string name);
    }
}
