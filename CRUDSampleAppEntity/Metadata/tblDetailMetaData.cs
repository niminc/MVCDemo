using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using System.Web.Mvc;

namespace CRUDSampleAppEntity
{
    [MetadataType(typeof(tblDetailMetaData))]
    public partial class tblDetail
    {

    }

    public class tblDetailMetaData
    {
        [Required]
        //[EmailAddress(ErrorMessage = "The email address is not valid")]
        //[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Confirm Email")]
        //[EmailAddress(ErrorMessage = "The email address is not valid")]
        //[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please Enter Correct Email Address")]
        [Compare("Email")]
        public string ConfirmEmail { get; set; }

        [Required]
        [RegularExpression(@"(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?", ErrorMessage = "Please Enter Correct Url")]
        public string Website { get; set; }

        [Required]
        [RegularExpression(@"^(\d{12})$", ErrorMessage = "Wrong mobile no! please add 12 digit with country code.")]
        public string MobileNo { get; set; }
    }
}