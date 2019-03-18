namespace PlanYourEvent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Eventtype")]
    public partial class Eventtype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Eventtype()
        {
            EventDesps = new HashSet<EventDesp>();
        }

        [Key]
        public int Event_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Event_Name { get; set; }

        [StringLength(8000)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventDesp> EventDesps { get; set; }
    }
}
