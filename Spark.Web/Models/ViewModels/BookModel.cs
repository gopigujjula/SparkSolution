using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Spark.Web.Models
{
    public class BookModel
    {
        public Item BookItem { get; set; }
        public IHtmlString Summary { get; set; }
        public List<Item> Authors { get; set; }
        public Item BookType { get; set; }
        public string BookLanguage { get; set; }
    }
}