using Spark.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Linq;

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

        public ActionResult BookList()
        {
            //Sitecore Index -> can hardcode index name or use default Index Resolver
            //RootItem
            //Filters - Where Clause
            //Template
            //for SearchBox - search text
            //Language
            //Pagination (server-side pagination)
            SearchResults<SearchResultItem> results;
            using (var context = ContentSearchManager.GetIndex("sitecore_master_index").CreateSearchContext())
            {
                IQueryable<SearchResultItem> query = context.GetQueryable<SearchResultItem>();
                query = query.Where(f => f.Paths.Contains(Sitecore.Context.Item.ID)
                  && f.TemplateId == BookTemplate.Book.ID
                  && f.Language == Sitecore.Context.Language.Name);

                results = query.GetResults();                               
            }
            List<SearchResultItem> resultItems = results?.Hits.Select(f => f.Document).ToList();
            List<Item> bookItems = new List<Item>();
            foreach (var bookItem in resultItems)
            {
                bookItems.Add(bookItem.GetItem());
            }
            return View(bookItems);
        }
    }
}