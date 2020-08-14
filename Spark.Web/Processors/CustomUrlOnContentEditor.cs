using Sitecore.Pipelines.GetContentEditorWarnings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spark.Web.Processors
{
    public class CustomUrlOnContentEditor
    {
        public void Process(GetContentEditorWarningsArgs args)
        {
            if (args == null || args.Item == null)
                return;

            var warning = args.Add();
            warning.Title = "Item Child Count";
            warning.Text = args.Item.Children.Count.ToString();
        }
    }
}