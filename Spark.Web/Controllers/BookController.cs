using Spark.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;

namespace Spark.Web.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            BookModel model = new BookModel();
            //Book Item
            model.BookItem = Sitecore.Context.Item;

            //Summary Field
            Field summaryField = Sitecore.Context.Item.Fields[BookTemplate.Book.Fields.Summary];
            model.Summary =
                new MvcHtmlString(Sitecore.Web.UI.WebControls.FieldRenderer.Render(Sitecore.Context.Item, "Summary"));

            //Author Field
            MultilistField authorField = Sitecore.Context.Item.Fields[BookTemplate.Book.Fields.Author];
            if (authorField?.Count > 0)
            {
                model.Authors = authorField.GetItems().ToList();
            }

            //Book Type Field
            ReferenceField bookTypeField = Sitecore.Context.Item.Fields[BookTemplate.Book.Fields.BookType];
            if (bookTypeField != null && !string.IsNullOrWhiteSpace(bookTypeField.Value))
            {
                model.BookType = bookTypeField.TargetItem;
            }
            

            //Language Field
            Field laguageField = Sitecore.Context.Item.Fields[BookTemplate.Book.Fields.BookLanguage];
            model.BookLanguage = laguageField.Value;
            return View(model);
        }
    }
}