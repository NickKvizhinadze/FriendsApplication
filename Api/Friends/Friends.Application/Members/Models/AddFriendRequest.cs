using System.ComponentModel.DataAnnotations;
using Friends.Localization;

namespace Friends.Application.Members.Models
{
    public class AddFriendRequest
    {
        #region Constructors
        public AddFriendRequest()
        {
            FriendId = string.Empty;
        }
        #endregion

        #region Properties
        [Display(ResourceType = typeof(Localization.Models), Name = nameof(Localization.Models.Friend))]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        public string FriendId { get; set; }
        #endregion
    }
}
