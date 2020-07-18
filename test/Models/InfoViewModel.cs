using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class InfoViewModel
    {

        public int id { get; set; }

        [Display(Name = "Tel No")]
        public string TelNo { get; set; }

        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Display(Name = "Address Line 3")]
        public string AddressLine3 { get; set; }

        [Display(Name = "Address Code")]
        public string AddressCode { get; set; }

        [Display(Name = "Postal Address 1")]
        public string PostalAddress1 { get; set; }

        [Display(Name = "Postal Address 2")]
        public string PostalAddress2 { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password (Greater than 4 digits)")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}