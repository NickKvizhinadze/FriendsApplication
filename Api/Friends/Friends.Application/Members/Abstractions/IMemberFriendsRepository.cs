using Friends.Domain.Members;
using Friends.Application.Common.Abstractions;

namespace Friends.Application.Members.Abstractions
{
    public interface IMemberFriendsRepository : IBaseRepository<MemberFriend, string>
    {        
    }
}
