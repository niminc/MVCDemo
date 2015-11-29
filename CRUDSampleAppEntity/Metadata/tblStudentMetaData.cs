using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDSampleAppEntity
{
    [MetadataType(typeof(tblStudentMetaData))]
    public partial class tblStudent
    {

    }

    public class tblStudentMetaData
    {
        [Required(ErrorMessage = "Please enter first name.")]
        [Remote("IsFirstUnique", "Student", AdditionalFields = "StudentId", ErrorMessage = "This {0} is already exist.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        public string LastName { get; set; }
    }
}