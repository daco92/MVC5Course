using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
    public class ClientLoginViewModel
    {
        [Required]
        [DisplayName("名")]
        [StringLength(10, ErrorMessage = "{0}最大不可超過{1}個字元")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(10)]
        [DisplayName("中間名")]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(10)]
        [DisplayName("姓")]
        public string LastName { get; set; }
       
        [DisplayName("生日")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
    }
}