﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital.WebAPI.Models
{
    public class ClinicViewModel
    {
        //min(1), name:alpha

        [Required]
        public int Id { get; set; }
        [MinLength(2)]
        public string Name { get; set; }

    }
}