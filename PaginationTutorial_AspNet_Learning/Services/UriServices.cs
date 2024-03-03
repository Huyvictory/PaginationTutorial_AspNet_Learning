using Microsoft.AspNetCore.WebUtilities;
using PaginationTutorial_AspNet_Learning.Controllers;
using PaginationTutorial_AspNet_Learning.Filter;

namespace PaginationTutorial_AspNet_Learning.Services
{
    public class UriServices : IUriService
    {
        private readonly string _baseUri;
        public UriServices(string baseUri)
        {
            _baseUri = baseUri;
        }
        public Uri GetPageUri(PaginationFilter filter, string route)
        {
            var _enpointUri = new Uri(string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "pageNumber", filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}
