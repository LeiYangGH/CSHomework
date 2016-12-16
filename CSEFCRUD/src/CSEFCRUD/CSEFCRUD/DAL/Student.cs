namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(2)]
        public string Sex { get; set; }

        public int? Age { get; set; }

        [StringLength(20)]
        public string Pwd { get; set; }

        [StringLength(50)]
        public string Discipline { get; set; }
    }
}
