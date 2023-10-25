﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.Profile;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Domain.News
{
    public class News : Entity<int>
    {
        public News(string title, string headLine, string description, string photo)
        {
            Title = title;
            HeadLine = headLine;
            Description = description;
            Photo = photo;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string HeadLine { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public int SmeProfileId { get; set; }
        public SmeProfile SmeProfile { get; set; }
    }
}
