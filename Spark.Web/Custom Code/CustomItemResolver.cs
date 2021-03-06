﻿using Sitecore;
using Sitecore.Buckets.Managers;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Pipelines.HttpRequest;
using System.Linq;

namespace Spark.Web.Custom_Code
{
    public class CustomItemResolver : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            if (Context.Item == null)
            {
                //http://addemo/Books{/2018/09/07/11/18/}bookname
                var requestUrl = args.Url.ItemPath;

                // remove last element from path and see if resulting path is a bucket
                var index = requestUrl.LastIndexOf('/');
                if (index > 0)
                {
                    var bucketPath = requestUrl.Substring(0, index);
                    var bucketItem = args.GetItem(bucketPath);

                    if (bucketItem != null && BucketManager.IsBucket(bucketItem))
                    {
                        var itemName = requestUrl.Substring(index + 1).Replace("-", " ");

                        // locate item in bucket by name
                        using (var searchContext = ContentSearchManager.GetIndex("sitecore_web_index").CreateSearchContext())
                        {
                            var result = searchContext.GetQueryable<SearchResultItem>().
                                Where(x => x.Name == itemName && x.TemplateId == BookTemplate.Book.ID)
                                .FirstOrDefault();
                            if (result != null)
                                Context.Item = result.GetItem();
                        }
                    }
                }
            }
        }
    }
}