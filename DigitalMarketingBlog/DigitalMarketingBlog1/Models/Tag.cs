﻿namespace DigitalMarketingBlog1.Models;

    public enum TagColors
{
    primary, danger, warning, success, secondary, info
}

    public class Tag
    {
        public int TagId { get; set; }
        public string? Text { get; set; }
        public string? Url { get; set; }
        public TagColors? Colors { get; set; }
        List<Post> Posts { get; set; } = new List<Post>();

    }


