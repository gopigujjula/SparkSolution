using System.Collections.Generic;

namespace Spark.Web.Models
{
    public class BookSearchResult
    {
        public List<BookItem> BookItems { get; set; }        
        public List<Facet> Facets { get; set; }
        public int AvailableCount { get; set; }
    }

    public class BookItem
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string AuthorName { get; set; }       
    }
    public class Facet
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}