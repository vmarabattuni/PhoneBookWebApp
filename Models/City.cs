using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBookWebApp.Models
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Display(Name = "City Name")]
        [Required]
        public String CityName { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey("State")]
        [Display(Name = "State")]
        public int StateID { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }


    }
}