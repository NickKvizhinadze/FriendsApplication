using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DotNetHelpers.Enums;
using DotNetHelpers.Models;
using DotNetHelpers.Extentions;
using Friends.Domain.Members;
using Friends.Application.Common;
using Friends.Persistence.Common;
using Friends.Application.Members.Abstractions;

namespace Friends.Persistence.Members
{
    public class MemberFriendsRepository : BaseRepository<MemberFriend, string>, IMemberFriendsRepository
    {
        #region Ctor

        public MemberFriendsRepository(ApplicationDbContext context) : base(context)
        {
        }

        #endregion
    }
}
