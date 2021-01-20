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
        }
        #endregion

        #region Properties
        public string Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        #endregion
    }
}
