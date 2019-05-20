using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_core.Models
{
    public class CommentDoNet
    {
        [Key]
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string CommentText { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
