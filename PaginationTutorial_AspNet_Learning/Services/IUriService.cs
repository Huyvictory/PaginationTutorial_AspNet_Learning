using PaginationTutorial_AspNet_Learning.Filter;

namespace PaginationTutorial_AspNet_Learning.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string apiRoute);
    }
}
