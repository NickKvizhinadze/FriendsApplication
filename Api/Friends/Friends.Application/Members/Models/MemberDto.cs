using System.Collections.Generic;

namespace Friends.Application.Members.Models
{
    public class MemberDto
    {
        #region Constructors
        public MemberDto()
        {
            Id = string.Empty;
            Name = string.Empty;
            Website = string.Empty;
            Friends = new List<string>();
        }
        #endregion

        #region Properties
        public string Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public List<string> Friends { get; set; }
        #endregion
    }
}
