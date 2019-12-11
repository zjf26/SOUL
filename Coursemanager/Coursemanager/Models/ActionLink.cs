﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coursemanager.Models
{
    public partial class ActionLink
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

    }

}