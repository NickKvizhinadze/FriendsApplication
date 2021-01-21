using System.Collections.Generic;

namespace Friends.Application.Members.Models
{
    public class HeadingDto
    {
        #region Constructors
        public HeadingDto()
        {
            Id = string.Empty;
            Key = string.Empty;
            Value = string.Empty;
        }
        #endregion

        #region Properties
        public string Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        #endregion
    }
}
