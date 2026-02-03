using GoetheApp.Common.Models;

namespace GoetheApp.ExceptionUtilities.MetaModels
{
    public class StackTraceMetaData : MetaDataItem
    {
        public string? Identifier { get; set; }
        public virtual ICollection<StackFrameMetaData>? StackFrames { get; set; }
    }
}
