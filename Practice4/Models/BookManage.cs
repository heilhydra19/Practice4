using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practice4.Models
{
    public class BookManage
    {
        [Required(ErrorMessage = "ID không được để trống")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(100, ErrorMessage = "Tiêu đề không quá 100 kí tự")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(30, ErrorMessage = "Tên tác giả không quá 30 kí tự")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Nội dung không được để trống")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Hình ảnh không được để trống")]
        public string ImageCover { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(1000, 1000000, ErrorMessage = "Giá sách từ 1000 đến 1000000")]
        public double Price { get; set; }
    }
}