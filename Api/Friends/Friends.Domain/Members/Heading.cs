using Friends.Domain.Common;

namespace Friends.Domain.Members
{
    public class Heading: Entity<string>
    {
        #region Constructor
        public Heading() : base()
        {
            Key = string.Empty;
            Value = string.Empty;
        }

        public Heading(string id, string key, string value)
            : base(id)
        {
            Key = key;
            Value = value;
        }
        #endregion

        #region Properties
        public string Key { get; set; }
        public string Value { get; set; }
        #endregion
    }
}
