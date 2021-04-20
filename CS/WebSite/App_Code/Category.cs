using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryID { get; set; }
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
