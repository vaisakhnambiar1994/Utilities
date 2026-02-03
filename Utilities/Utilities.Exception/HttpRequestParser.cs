using GoetheApp.ExceptionUtilities.MetaModels;

namespace GoetheApp.ExceptionUtilities
{
    public class HttpRequestParser
    {
        public RequestMetaData Parse(HttpRequest request = null)
        {
            if (request == null)
                return null;

            string body = request.QueryString.Value;

            return new RequestMetaData
            {
                RequestData = body,
                RequestUrl = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}"
            };
        }
    }
}
