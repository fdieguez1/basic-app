﻿using System;

namespace BasicApp.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
