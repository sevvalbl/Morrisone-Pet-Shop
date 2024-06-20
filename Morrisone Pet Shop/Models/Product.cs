using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Web;

namespace Morrisone_Pet_Shop.Areas
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage ="İsim alanı zorunludur.")]
        public string Name { get; set; }    
        public string? Description { get; set; }
       
        public decimal Price { get; set; }  
        public int CategoryID {  get; set; }
       
        public Category? Category { get; set; }
       
        public string? Image { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now; 
    }
}
