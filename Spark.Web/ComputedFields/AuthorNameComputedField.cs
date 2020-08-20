using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;

namespace Spark.Web.ComputedFields
{
    public class AuthorNameComputedField : IComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Item item = indexable as SitecoreIndexableItem;

            if (item == null)
            {
                return null;
            }

            if (item.TemplateID == BookTemplate.Book.ID)
            {
                MultilistField authorField = item.Fields[BookTemplate.Book.Fields.Author];
                if (authorField?.Count > 0)
                {
                    return authorField.GetItems().ToList()
                        .FirstOrDefault()?.Fields[new Sitecore.Data.ID("{A1534AE8-1754-4C8F-B57B-476254571F5E}")].Value;
                }
            }

            return null;
        }
    }
}