﻿using System.ComponentModel.DataAnnotations;

namespace UdemyJwtApp.Front.Models
{
    public class CreateCategoryModel
    {
        [Required(ErrorMessage = "Kategori Boş bırakılamaz.")]
        public string Definition { get; set; } = null!;
    }
}
