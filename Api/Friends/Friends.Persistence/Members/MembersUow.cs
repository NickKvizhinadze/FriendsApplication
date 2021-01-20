using Friends.Persistence.Common;
using Friends.Application.Members.Abstractions;

namespace Friends.Persistence.Members
{
    public class MembersUow : BaseUow, IMembersUow
    {
        #region Constructors
        public MembersUow(ApplicationDbContext context, IMembersRepository members, IMemberFriendsRepository memberFriends) : base(context)
        {
            Members = members;
            MemberFriends = memberFriends;
        }
        #endregion

        #region Properties
        public IMembersRepository Members { get; }
        public IMemberFriendsRepository MemberFriends { get; }
        #endregion      
    }
}
