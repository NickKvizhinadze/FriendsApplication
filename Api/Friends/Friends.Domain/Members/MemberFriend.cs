using Friends.Domain.Common;

namespace Friends.Domain.Members
{
    public class MemberFriend: Entity<string>
    {
        #region Constructor
        public MemberFriend(): base()
        {
            FriendId = string.Empty;
            Friend2Id = string.Empty;
        }

        public MemberFriend(string id, string friendId, string friend2Id): base(id)
        {
            FriendId = friendId;
            Friend2Id = friend2Id;
        }

        #endregion

        public string FriendId { get; set; }
        public string Friend2Id { get; set; }

        #region Properties
        public Member? Friend { get; set; }
        public Member? Friend2 { get; set; }
        #endregion
    }
}
