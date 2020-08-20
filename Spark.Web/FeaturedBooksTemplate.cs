using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spark.Web
{
    public static class FeaturedBooksTemplate
    {
        public struct FeaturedBooks
        {
            public static ID ID = ID.Parse("{E6E0C1A2-0BDC-4100-B4CD-6827E446FDB6}");
            public const string TemplateId = "{E6E0C1A2-0BDC-4100-B4CD-6827E446FDB6}";
            public struct Fields
            {
                public const string FeaturedTitleField = "{C58A56AC-7A77-4D07-8C1B-CC47ABD3E02F}";
                public const string FeaturedBooksField = "{E72EC97B-841E-4F11-BA88-0C21E5C975C4}";
            }
        }
    }
}