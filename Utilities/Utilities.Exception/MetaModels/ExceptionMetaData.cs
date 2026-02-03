using GoetheApp.Common;
using GoetheApp.Common.Models;

namespace GoetheApp.ExceptionUtilities.MetaModels.Data
{
    public class ExceptionMetaData : MetaDataItem
    {
        public ExceptionCategory Category { get; set; }
        public string? MicroServiceName { get; set; }
        public string? FunctionName { get; set; }
        public string? FaultyObject { get; set; }
        public string? ExceptionType { get; set; }
        public int? ExceptionCode { get; set; }
        public string? ErrorLineNo { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Description { get; set; }
        public DateTime? ErrorOccurredAt { get; set; }

        public StackTraceMetaData? StackTrace { get; set; }
        public RequestMetaData? Request { get; set; }
    }
}
