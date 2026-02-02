using AutoMapper;
using Utilities.File.Generators.PDF.Drawer.Models.TemplateModels;
using Utilities.File.Generators.PDF.Drawer.Models.ToolModels;

namespace Utilities.File.Generators.PDF.Drawer.Mappers
{
    public class FieldMapper : Profile
    {
        public FieldMapper()
        {
            CreateMap<FieldTemplate, Field>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));
        }
    }
}
