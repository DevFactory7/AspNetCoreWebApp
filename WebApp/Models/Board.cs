using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.IdentityModels;

namespace WebApp.Models
{
    public class Board
    {
        [Key]
        [StringLength(128)]
        public string Id { get; set; }

        [Display(Name = "공지")]
        public bool IsNotice { get; set; }

        [Required(ErrorMessage = "{0}을 입력하세요.")]
        [Display(Name = "제목")]
        [StringLength(500)]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0}을 입력하세요.")]
        [Display(Name = "내용")]
        public string Contents { get; set; }

        [Required]
        [Display(Name = "작성일")]
        public DateTime RegDate { get; set; }

        [StringLength(450)]
        [Required]
        public string WriterCode { get; set; }

        [Display(Name = "조회수")]
        public int ReadCount { get; set; }

        [Display(Name = "작성자")]
        [ForeignKey("WriterCode")]
        public virtual ApplicationUser Writer { get; set; }

        public Board()
        {
            Id = string.Join("-", Guid.NewGuid().ToString().ToUpper(), Guid.NewGuid().ToString().ToUpper());
        }

    }
}
