﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEMSystem.Models
{
    public class InergenTankHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string ReferenceNo { get; set; }
        public int AreaId { get; set; }
        //public virtual Area Areas { get; set; }
        //public int LocationInergenTankId { get; set; }
        //public virtual LocationInergenTank Locations { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Status { get; set; } = "Active";
        public string DocumentStatus { get; set; } = "Draft";


        public DateTime ReviewedDate { get; set; }
        public DateTime ApprovedDate { get; set; }


    }

}
