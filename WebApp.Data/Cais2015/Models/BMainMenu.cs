using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApp.Data.Cais2015.Models
{
    public class BMainMenu
    {
        [Key]
        public int SEQ { get; set; }
        [Required]
        public int Rank { get; set; }
        [Required]
        [StringLength(50)]
        public string MenuId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
