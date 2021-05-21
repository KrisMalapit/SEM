﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEMSystem.Models
{
    public class LocationFireExtinguisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Location { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Capacity { get; set; }
        public int AreaId { get; set; }
        public virtual Area Areas { get; set; }
        public string Status { get; set; }
    }
}
