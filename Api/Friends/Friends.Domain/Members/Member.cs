using Friends.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Friends.Domain.Members
{
    public class Member : AggregateRoot<string>
    {
        #region Fields
        protected readonly List<MemberFriend> _memberFriends = new List<MemberFriend>();
        #endregion

        #region Constructor
        public Member() : base()
        {
            Name = string.Empty;
            Website = string.Empty;
        }

        public Member(string id, string name, string website)
            : base(id)
        {
            Name = name;
            Website = website;
        }
        #endregion

        #region Properties
        public string Name { get; private set; }
        public string Website { get; private set; }
        #endregion

        #region Navigation Properties
        public IReadOnlyCollection<MemberFriend> Friends => _memberFriends;
        #endregion
    }
}
