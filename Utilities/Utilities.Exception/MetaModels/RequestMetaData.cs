using GoetheApp.Common.Models;

namespace GoetheApp.ExceptionUtilities.MetaModels
{
    public class RequestMetaData : MetaDataItem
    {
        public string RequestUrl { get; set; }
        public string RequestData { get; set; }
    }
}
