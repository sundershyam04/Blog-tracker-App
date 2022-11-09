﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace DAL
{
    public class BlogInfo
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Subject { get; set; }

        public DateTime DateOfCreation { get; set; }

        [Required]
        public string BlogUrl { get; set; }

        [EmailAddress]
        [Required]
        [ForeignKey("EmpInfo")]     //fk
        public string Email { get; set; }

        public virtual EmpInfo EmpInfo { get; set; }
    }
}