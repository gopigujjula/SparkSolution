using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spark.Web.Models
{
    public class CustomSearchResultItem:SearchResultItem
    {
        [IndexField("title")]
        public virtual string Title { get; set; }

        [IndexField("published_date")]
        public virtual DateTime PublishedDate { get; set; }

        [IndexField("computed_authorname")]
        public virtual string AuthorName { get; set; }

        [IndexField("publisher")]
        public virtual string Publisher { get; set; }        
    }
}