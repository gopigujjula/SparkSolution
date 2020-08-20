using Glass.Mapper.Sc.Configuration.Attributes;
using Spark.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Web.Models.TemplateModels
{
    [SitecoreType(TemplateId = FeaturedBooksTemplate.FeaturedBooks.TemplateId)]
    public interface IFeaturedBooks : IGlassBase
    {
        [SitecoreField(FeaturedBooksTemplate.FeaturedBooks.Fields.FeaturedTitleField)]
        string FeaturedTitle { get; set; }

        [SitecoreField(FeaturedBooksTemplate.FeaturedBooks.Fields.FeaturedBooksField)]
        IEnumerable<IBook> FeaturedBooks { get; set; }
    }
}
