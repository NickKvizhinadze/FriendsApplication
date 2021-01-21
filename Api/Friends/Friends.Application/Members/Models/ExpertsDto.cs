using System.Collections.Generic;

namespace Friends.Application.Members.Models
{
    public class ExpertsDto
    {
        #region Constructors
        public ExpertsDto(string memberId, string memberName, string headingId, string headingValue, List<ExpertDto> experts)
        {
            MemberId = memberId;
            MemberName = memberName;
            HeadingId = headingId;
            HeadingValue = headingValue;
            Experts = experts;
        }
        #endregion

        #region Properties
        public string MemberId { get; }
        public string MemberName { get; }
        public string HeadingId { get; }
        public string HeadingValue { get; }
        public List<ExpertDto> Experts { get; }
        #endregion
    }
}
