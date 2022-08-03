﻿using System.ComponentModel.DataAnnotations;

namespace YoutubeDotNet.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
