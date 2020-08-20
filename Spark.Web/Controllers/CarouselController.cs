using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Spark.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spark.Web.Controllers
{
    public class CarouselController : Controller
    {
        IMvcContext _mvcContext;
        public CarouselController()
        {
            _mvcContext = new MvcContext();
        }
        // GET: Carousel
        public ActionResult Slider()
        {
            SliderModel model = new SliderModel();

            if (_mvcContext.HasDataSource)
            {
                _mvcContext.GetDataSourceItem<SliderModel>();
                var dataSourceID = RenderingContext.Current.Rendering.DataSource;
                var datasourceItem = Sitecore.Context.Database.GetItem(new Sitecore.Data.ID(dataSourceID));

                MultilistField slidesField = datasourceItem.Fields["{3AC463B0-DE1F-4D98-842A-C750897C24D6}"];
                if (slidesField?.Count > 0)
                {
                    model.Slides = slidesField.GetItems().ToList();
                }
            }
            return View(model);
        }
    }
}