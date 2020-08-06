using Spark.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.ContentSearch;
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
            //Language
            //Sort
            //Pagination (server-side pagination)
            //for SearchBox - search text
            //individual field search
            //computed fields
            //facets
            //Index rebuild vs Index update
            //Custom Index - Indexing Strategy, Crawling
            SearchResults<CustomSearchResultItem> results;
            using (var context = ContentSearchManager.GetIndex("sitecore_web_index").CreateSearchContext())
            {
                DateTime fromDate = new DateTime(2018, 10, 1);
                DateTime toDate = new DateTime(2018, 12, 31);
                IQueryable<CustomSearchResultItem> query = context.GetQueryable<CustomSearchResultItem>();
                query = query.Where(f => f.Paths.Contains(Sitecore.Context.Item.ID)
                  && f.TemplateId == BookTemplate.Book.ID
                  && f.Language == Sitecore.Context.Language.Name).OrderBy(f => f.Name).Page(0, 10);               

                results = query.GetResults();                               
            }
            List<CustomSearchResultItem> resultItems = results?.Hits.Select(f => f.Document).ToList();
            List<Item> bookItems = new List<Item>();
            BookSearchResult model = new BookSearchResult();
            List<BookItem> books = new List<BookItem>();

            foreach (var bookItem in resultItems)
            {
                //var item = bookItem.GetItem();
                //string authorName = string.Empty;
                //MultilistField authorField = item.Fields[BookTemplate.Book.Fields.Author];
                //if (authorField?.Count > 0)
                //{
                //    authorName = authorField.GetItems().ToList()
                //        .FirstOrDefault()?.Fields[new Sitecore.Data.ID("{A1534AE8-1754-4C8F-B57B-476254571F5E}")].Value;
                //}
                books.Add(new BookItem { Title = bookItem.Title, Publisher = bookItem.Publisher, AuthorName = bookItem.AuthorName });
                model.BookItems = books;
            }
            return View(model);
        }
    }
}