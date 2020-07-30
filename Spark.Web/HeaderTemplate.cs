using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spark.Web
{
    public static class HeaderTemplate
    {
        public struct Header
        {
            public static ID ID = ID.Parse("{F9688627-7958-4F52-B155-C987457DEBEC}");
            public struct Fields
            {
                public static ID StoreHeaderText { get; } = new ID("{93003E48-6330-42BC-926B-243ACCE172C5}");
                public static ID StorePhoneNumber { get; } = new ID("{8305E257-1052-4337-A32D-E64EDFFDCE14}");
                public static ID StoreLink { get; } = new ID("{0B355E1C-8318-4B88-BB29-1B7C8F9C8B71}");
                public static ID Logo { get; } = new ID("{98C7415A-F715-4AE9-B3EE-AF3DFDDE57BF}");
                public static ID Menu { get; } = new ID("{74405754-74F8-4C05-B873-A0F12A3B1C3D}");
            }
        }
    }
}