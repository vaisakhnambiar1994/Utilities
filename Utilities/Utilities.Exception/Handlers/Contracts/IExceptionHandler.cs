using GoetheApp.Core.Models.Exceptions;
using GoetheApp.ExceptionUtilities.Models;

namespace GoetheApp.ExceptionUtilities.Contracts
{
    public interface IExceptionHandler
    {
        ExceptionModel GetException(CoreException exception, HttpContext context);
    }
}
