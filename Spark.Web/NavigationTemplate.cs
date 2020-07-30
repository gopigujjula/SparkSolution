using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spark.Web
{
    public static class NavigationTemplate
    {
        public struct Navigation
        {
            public static ID ID = ID.Parse("{07BFBD40-462F-4D7E-93D7-E58F5715F2CF}");
            public struct Fields
            {
                public static ID NavigationTitle { get; } = new ID("{A382A1B0-880D-447A-AF79-F35FDACEBCEF}");
                public static ID NavigationLink { get; } = new ID("{1C613ACA-54C7-4387-A9B4-957D5C722277}");
            }
        }
    }
}