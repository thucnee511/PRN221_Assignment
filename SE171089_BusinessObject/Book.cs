using System;
using System.Collections.Generic;

namespace SE171089_BusinessObject
{
    public partial class Book
    {
        public int Id { get; set; }
        public int CateId { get; set; }
        public string Name { get; set; } = null!;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }

        public virtual Category Cate { get; set; } = null!;
    }
}
