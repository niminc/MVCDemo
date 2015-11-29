using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDSampleAppEntity
{
    [MetadataType(typeof(tblCatalogMetaData))]
    public partial class tblCatalog
    {

    }

    public class tblCatalogMetaData
    {
        [Required]
        [MaxLength(50, ErrorMessage = "{0} must be 50 characters or less"), MinLength(5)]
        [Display(Name = "Item Name")]
        public string CatalogName { get; set; }
        [Required]
        [Display(Name = "Bar code")]
        [StringLength(30, ErrorMessage = "Please add up to 30 Characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Please remove special character.")]
        [Remote("IsBarCodeUnique", "Catalog", AdditionalFields = "Id", ErrorMessage = "This {0} is already used.")]
        public string Barcode { get; set; }
    }
}