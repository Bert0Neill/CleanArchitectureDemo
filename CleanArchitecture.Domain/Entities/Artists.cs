﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public partial class Artists
    {
        public Artists()
        {
            Albums = new HashSet<Albums>();
        }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public DateTime? ActiveFrom { get; set; }

        public virtual ICollection<Albums> Albums { get; set; }
    }
}