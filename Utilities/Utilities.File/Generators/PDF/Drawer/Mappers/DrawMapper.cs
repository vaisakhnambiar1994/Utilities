using AutoMapper;
using Utilities.File.Generators.PDF.Drawer.Models.TemplateModels;
using Utilities.File.Generators.PDF.Drawer.Models.ToolModels;

namespace Utilities.File.Generators.PDF.Drawer.Mappers
{
    public class DrawMapper : Profile
    {
        public DrawMapper()
        {
            CreateMap<DrawTemplate, DrawModel>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Field, opt => opt.MapFrom(src => src.Field))
                .ForMember(dest => dest.Layout, opt => opt.MapFrom(src => src.Layout))
                .ForMember(dest => dest.Style, opt => opt.MapFrom(src => src.Style));
        }
    }
}
