using Friends.Domain.Common;

namespace Friends.Domain.Members
{
    public class MemberFriend: Entity<string>
    {
        #region Constructor

        public MemberFriend(Member friend1, Member friend2)
        {
            Friend1 = friend1;
            Friend2 = friend2;
        }

        #endregion

        #region Properties
        public Member Friend1 { get; set; }
        public Member Friend2 { get; set; }
        #endregion
    }
}
