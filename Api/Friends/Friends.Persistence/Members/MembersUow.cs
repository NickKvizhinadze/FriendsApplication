using Friends.Persistence.Common;
using Friends.Application.Members.Abstractions;

namespace Friends.Persistence.Members
{
    public class MembersUow : BaseUow, IMembersUow
    {
        #region Constructors
        public MembersUow(ApplicationDbContext context, IMembersRepository members) : base(context)
        {
            Members = members;
        }
        #endregion

        #region Properties
        public IMembersRepository Members { get; }
        #endregion      
    }
}
