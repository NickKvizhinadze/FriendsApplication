using Friends.Application.Common.Abstractions;

namespace Friends.Application.Members.Abstractions
{
    public interface IMembersUow: IBaseUow
    {
        IMembersRepository Members { get; }
        IMemberFriendsRepository MemberFriends { get; }

    }
}
