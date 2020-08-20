using Spark.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Glass.Mapper.Sc.Web.Mvc;
using Glass.Mapper.Sc.Web;
using Glass.Mapper.Sc;

namespace Spark.Web.Controllers
{
    public class BookController : Controller
    {
        IMvcContext _mvcContext;        
        
        public BookController()
        {
            _mvcContext = new MvcContext();
        }
        // GET: Book
        public ActionResult Index()
        {
            #region
            ////Summary Field
            /////Book Item
            ///BookModel model = new BookModel();
            //model.BookItem = Sitecore.Context.Item;
            //Field summaryField = Sitecore.Context.Item.Fields[BookTemplate.Book.Fields.Summary];
            //model.Summary =
            //    new MvcHtmlString(Sitecore.Web.UI.WebControls.FieldRenderer.Render(Sitecore.Context.Item, "Summary"));

            ////Author Field
            //MultilistField authorField = Sitecore.Context.Item.Fields[BookTemplate.Book.Fields.Author];
            //if (authorField?.Count > 0)
            //{
            //    model.Authors = authorField.GetItems().ToList();
            //}

            ////Book Type Field
            //ReferenceField bookTypeField = Sitecore.Context.Item.Fields[BookTemplate.Book.Fields.BookType];
            //if (bookTypeField != null && !string.IsNullOrWhiteSpace(bookTypeField.Value))
            //{
            //    model.BookType = bookTypeField.TargetItem;
            //}


            ////Language Field
            //Field laguageField = Sitecore.Context.Item.Fields[BookTemplate.Book.Fields.BookLanguage];
            //model.BookLanguage = laguageField.Value;
            #endregion
            return View(_mvcContext.GetContextItem<IBook>());
        }

        public ActionResult BookList()
        {
            BookSearchResult model = new BookSearchResult();
            ISitecoreService service = new SitecoreService(Sitecore.Context.Database);
            SitecoreIndexableItem contextItem = Sitecore.Context.Item;
            SearchResults<CustomSearchResultItem> results;

            using (var context = ContentSearchManager.GetIndex(contextItem).CreateSearchContext())
            {
                IQueryable<CustomSearchResultItem> query = context.GetQueryable<CustomSearchResultItem>();
                query = query.Where(f => f.Paths.Contains(Sitecore.Context.Item.ID)
                  && f.TemplateId == BookTemplate.Book.ID
                  && f.Language == Sitecore.Context.Language.Name).Page(0, 30);

                results = query.GetResults();
            }
            List<CustomSearchResultItem> resultItems = results?.Hits.Select(f => f.Document).ToList();
            
            List<IBook> books = new List<IBook>();
            //List<BookItem> bookItems = new List<BookItem>();

            foreach (var bookItem in resultItems)
            {
                books.Add(service.GetItem<IBook>(bookItem.ItemId.ToGuid()));
                //bookItems.Add(new BookItem
                //            {
                //                Title = bookItem.Title,
                //                Publisher = bookItem.Publisher,
                //                AuthorName = bookItem.AuthorName
                //            });
                //model.BookItems = bookItems;
                model.Books = books;
            }

            #region Facets
            //List<Facet> facets = new List<Facet>();
            //foreach(var category in results.Facets?.Categories)
            //{
            //    foreach(var facet in category.Values)
            //    {
            //        facets.Add(new Facet { Name = facet.Name, Count = facet.AggregateCount });
            //    }
            //}
            //model.Facets = facets;
            #endregion
            return View(model);
        }
    }
}