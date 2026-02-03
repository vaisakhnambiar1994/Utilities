using GoetheApp.Common.Publisher;
using GoetheApp.ExceptionUtilities.MetaModels.Data;
using GoetheApp.ExceptionUtilities.Publishers.Contracts;

namespace GoetheApp.ExceptionUtilities.Publishers.Implementations
{
    public class ExceptionPublisher : DataPublisher<ExceptionMetaData>, IExceptionPublisher
    {
        protected override bool WaitForConfirm { get { return true; } }

        protected override void ConfigureQueue()
        {
            AddQueue(Constants.Exception_QualityAnalyzer_Queue);
        }
    }
}
