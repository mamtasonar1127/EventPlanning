namespace PlanYourEvent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EventDesp")]
    public partial class EventDesp
    {
        [Key]
        public int EDId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Event Name")]
        public string ED_Name { get; set; }

        [StringLength(8000)]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Range(0.01,100000)]
        public decimal Price { get; set; }

        [StringLength(255)]
        [Display(Name = "Image")]
        public string Photo { get; set; }

        public int Event_Id { get; set; }

        public virtual Eventtype Eventtype { get; set; }
    }
}
