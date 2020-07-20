﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBookWebApp.Models
{
    public class State
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int SateId { get; set; }

        [Display(Name = "State Name")]
        [Required]
        public String StateName { get; set; }

       

        public bool IsActive { get; set; } = true;

        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }


    }
}