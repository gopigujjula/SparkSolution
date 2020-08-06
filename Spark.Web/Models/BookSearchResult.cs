using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spark.Web.Models
{
    public class BookSearchResult
    {
        public List<BookItem> BookItems { get; set; }
    }

    public class BookItem
    {
        //public Sitecore.Data.Items.Item Item { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string AuthorName { get; set; }
    }
}