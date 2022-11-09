using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTAWebAPIClient.Models
{
    public class MBlog
    {
        //[Key]
        public int BlogId { get; set; }

      [Required]
        public string Title { get; set; }

        [Required]
        public string Subject { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfCreation { get; set; }

        [Required]
        public string BlogUrl { get; set; }

        [EmailAddress]
        [Required]
        //[ForeignKey("EmpInfo")]     //fk
        public string Email { get; set; }

        public virtual MEmp EmpInfo { get; set; }
    }
}