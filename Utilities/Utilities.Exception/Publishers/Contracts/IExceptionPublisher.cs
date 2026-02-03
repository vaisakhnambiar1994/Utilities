using GoetheApp.Common.Publishers.Contracts;
using GoetheApp.ExceptionUtilities.MetaModels.Data;

namespace GoetheApp.ExceptionUtilities.Publishers.Contracts
{
    public interface IExceptionPublisher : IDataPublisher<ExceptionMetaData>
    {
    }
}
