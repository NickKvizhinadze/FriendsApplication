namespace Friends.Application.Members.Models
{

    public class ExpertDto
    {
        #region Constructors
        public ExpertDto()
        {
            FriendId = string.Empty;
            FriendName = string.Empty;
            ExpertId = string.Empty;
            ExpertName = string.Empty;
        }
        #endregion

        #region Properties
        public string FriendId { get; set; }
        public string FriendName { get; set; }
        public string ExpertId { get; set; }
        public string ExpertName { get; set; }
        #endregion
    }
}
