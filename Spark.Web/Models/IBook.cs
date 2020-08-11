using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Spark.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Web.Models
{
    [SitecoreType(TemplateId = BookTemplate.Book.TemplateId)]
    public interface IBook : IGlassBase
    {
        [SitecoreField(BookTemplate.Book.Fields.TitleField)]
        string Title { get; set; }

        [SitecoreField(BookTemplate.Book.Fields.SummaryField)]
        string Summary { get; set; }

        [SitecoreField(BookTemplate.Book.Fields.DescriptionField)]
        string Description { get; set; }

        [SitecoreField(BookTemplate.Book.Fields.CategoryField)]
        Guid BookCategory { get; set; }

        [SitecoreField(BookTemplate.Book.Fields.FrontCoverField)]
        Image BookCover { get; set; }

        [SitecoreField(BookTemplate.Book.Fields.PublishedDateField)]
        DateTime PublishedDate { get; set; }

        [SitecoreField(BookTemplate.Book.Fields.AuthorField)]
        IEnumerable<IAuthor> Authors { get; set; }
    }    
}
