using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDSampleAppEntity
{
    [MetadataType(typeof(tblContactDetailMetaData))]
    public partial class tblContactDetail
    {

    }

    public class tblContactDetailMetaData
    {
        [Required(ErrorMessage = "Please enter contact detail.")]
        public string ContactDetail { get; set; }
    }
}