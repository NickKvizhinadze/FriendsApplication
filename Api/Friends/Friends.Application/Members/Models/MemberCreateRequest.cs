using System.ComponentModel.DataAnnotations;
using Friends.Localization;

namespace Friends.Application.Members.Models
{
    public class MemberCreateRequest
    {
        #region Constructors
        public MemberCreateRequest()
        {
            Name = string.Empty;
            Website = string.Empty;
        }
        #endregion
        #region Properties
        [Display(ResourceType = typeof(Localization.Models), Name = nameof(Localization.Models.Name))]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Localization.Models), Name = nameof(Localization.Models.Website))]
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        public string Website { get; set; }
        #endregion
    }
}
