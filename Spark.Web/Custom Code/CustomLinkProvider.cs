using Sitecore.Buckets.Extensions;
using Sitecore.Buckets.Managers;
using Sitecore.IO;
using Sitecore.Links.UrlBuilders;

namespace Spark.Web.Custom_Code
{
    public class CustomLinkProvider : ItemUrlBuilder
    {
        public CustomLinkProvider(DefaultItemUrlBuilderOptions option) : base(option)
        {
        }
        public override string Build(Sitecore.Data.Items.Item item, 
            ItemUrlBuilderOptions options)
        {
            if (BucketManager.IsItemContainedWithinBucket(item))
            {
                var bucketItem = item.GetParentBucketItemOrParent();
                if (bucketItem != null && bucketItem.IsABucket())
                {
                    var bucketUrl = base.Build(bucketItem, options);

                    return FileUtil.MakePath(bucketUrl, item.Name.Replace(" ", "-"));
                }
            }

            return base.Build(item, options);
        }
    }
}