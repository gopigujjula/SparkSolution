using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spark.Web
{
    public static class BookTemplate
    {
        public struct Book
        {
            public static ID ID = ID.Parse("{C77CBF36-E660-4C1A-AB94-85F172CA180A}");
            public const string TemplateId = "{C77CBF36-E660-4C1A-AB94-85F172CA180A}";
            public struct Fields
            {
                public static ID Title { get; } = new ID("{24D7A5D2-D2B3-4D52-927E-C6722F6587F4}");
                public const string TitleField = "{24D7A5D2-D2B3-4D52-927E-C6722F6587F4}";

                public static ID Summary { get; } = new ID("{26FBF511-A5EC-4F33-8A49-21DFC6F78079}");
                public const string SummaryField = "{24D7A5D2-D2B3-4D52-927E-C6722F6587F4}";

                public static ID Description { get; } = new ID("{434A9027-02C8-4852-8D34-6ED59C9309F8}");
                public const string DescriptionField = "{434A9027-02C8-4852-8D34-6ED59C9309F8}";

                public static ID Author { get; } = new ID("{F5076ECF-6BA8-44E3-AF0F-BDCC71331337}");
                public const string AuthorField  = "{F5076ECF-6BA8-44E3-AF0F-BDCC71331337}";

                public static ID ISBN10 { get; } = new ID("{89957319-C5FA-4C80-9BC1-63F896E8EC60}");
                public static ID ISBN13 { get; } = new ID("{18EBDE06-3A15-4786-97A6-A88B23CEDA0E}");
                public static ID Publisher { get; } = new ID("{5F843ADB-E7EE-472B-ADB1-7385DC7636F1}");
                public static ID BookLanguage { get; } = new ID("{36461B6B-EF53-47C0-97F7-5373DE7F2BF3}");
                public static ID BookType { get; } = new ID("{D33AD0DE-05C6-419E-A8A5-0B823DEFAEA8}");

                public static ID PublishedDate { get; } = new ID("{9862ECB6-3E36-452D-8A0F-19272462E727}");
                public const string PublishedDateField = "{9862ECB6-3E36-452D-8A0F-19272462E727}";

                public static ID NumberofPages { get; } = new ID("{2231B463-FB6C-4412-8F05-C7715CA9AF3A}");
                public static ID BookLanguageLink { get; } = new ID("{CB346EF8-367C-410E-BCF9-420DEAAA6811}");
                public static ID BookLanguageTreelistEx { get; } = new ID("{022C2C51-B009-4DE6-A10C-1FCADA6D681F}");
                public static ID Price { get; } = new ID("{EC1D2EB7-F58E-458E-9BDD-2B579DDE2953}");

                public static ID Category { get; } = new ID("{EFD4D78B-1F8E-496A-A522-B4211903CC35}");
                public const string CategoryField = "{EFD4D78B-1F8E-496A-A522-B4211903CC35}";

                public static ID FrontCover { get; } = new ID("{7329B758-505A-49B2-9890-7A12CD751431}");
                public const string FrontCoverField = "{7329B758-505A-49B2-9890-7A12CD751431}";

                public static ID BackCover { get; } = new ID("{451F3F04-5146-463D-821F-9D563A7D5640}");
            }
        }
    }
}