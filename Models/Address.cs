using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls.WebParts;

namespace PhoneBookWebApp.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Display(Name = "Address Line One")]
        [Required]
        public String AddressOne { get; set; }

        [Display(Name = "Address Line Two")]
        public String AddressTwo { get; set; }

        [Display(Name = "Pin Code")]
        [Required]
        public int PinCode { get; set; }

        [Display(Name = "Country")]
       [ForeignKey("Country")]
        public int CountryID { get; set; }

        [Display(Name = "State")]
       [ForeignKey("State")]
        public int StateID { get; set; }

        [Display(Name = "City")]
        [ForeignKey("City")]
        public int CityID { get; set; }

        [Display(Name = "Person")]
        [ForeignKey("People")]
        public int PeopleID { get; set; }


        public virtual People People { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }



    }
}