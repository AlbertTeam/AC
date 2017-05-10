using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.LanguagesView
{
    public class UserViewModel
    {
        [Display(Name = "UserName", ResourceType = typeof(Resources.WebResources))]
        [Required(ErrorMessageResourceName = "UserNameRequired", ErrorMessageResourceType = typeof(Resources.WebResources))]
        public string UserName { get; set; }

        [Display(Name = "FullName", ResourceType = typeof(Resources.WebResources))]
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Resources.WebResources))]
        public string FullName { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resources.WebResources))]
        [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Resources.WebResources))]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.WebResources))]
        [Required(ErrorMessageResourceName = "ConfirmPasswordRequired", ErrorMessageResourceType = typeof(Resources.WebResources))]
        [Compare("Password", ErrorMessageResourceName = "ConfirmPasswordCompare", ErrorMessageResourceType = typeof(Resources.WebResources))]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Resources.WebResources))]
        [Required(ErrorMessageResourceName = "AddressRequired", ErrorMessageResourceType = typeof(Resources.WebResources))]
        public string Address { get; set; }
    }
}