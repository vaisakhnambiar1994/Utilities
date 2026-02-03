using GoetheApp.Common.Models;

namespace GoetheApp.ExceptionUtilities.MetaModels
{
    public class StackFrameMetaData : MetaDataItem
    {
        public int Index { get; set; }
        public string? MethodName { get; set; }
        public string? FileName { get; set; }
        public int LineNumber { get; set; }
        public int ColumnNumber { get; set; }
    }
}
