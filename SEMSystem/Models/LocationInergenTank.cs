﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SEMSystem.Models
{
    public class LocationInergenTank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Location { get; set; }
        public string Capacity { get; set; }
        public string Serial { get; set; }
        public string Area { get; set; }


        public int AreaId { get; set; }
        public virtual Area Areas { get; set; }
        public string Status { get; set; }
    }
}
