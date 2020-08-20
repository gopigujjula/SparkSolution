using Glass.Mapper.Sc.Web.Mvc;
using Spark.Web.Models.TemplateModels;
using System.Web.Mvc;

namespace Spark.Web.Controllers
{
    public class FeaturedController : Controller
    {
        IMvcContext _mvcContext;
        public FeaturedController()
        {
            _mvcContext = new MvcContext();
        }
        
        public ActionResult FeaturedBooks()
        {
            IFeaturedBooks model = null;
            if (_mvcContext.HasDataSource)
            {
                model = _mvcContext.GetDataSourceItem<IFeaturedBooks>();
            }
            return View(model);
        }
    }
}