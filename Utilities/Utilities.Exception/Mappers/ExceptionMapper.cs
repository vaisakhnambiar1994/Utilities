using AutoMapper;
using GoetheApp.ExceptionUtilities.MetaModels.Data;
using GoetheApp.ExceptionUtilities.Models;

namespace GoetheApp.ExceptionUtilities.Mappers
{
    public class ExceptionMapper : Profile
    {
        public ExceptionMapper()
        {
            CreateMap<ExceptionModel, ExceptionMetaData>();
        }
    }
}
