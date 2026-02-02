using AutoMapper;
using Utilities.File.Generators.PDF.Drawer.Models.TemplateModels;
using Utilities.File.Generators.PDF.Drawer.Models.ToolModels;

namespace Utilities.File.Generators.PDF.Drawer.Mappers
{
    public class LayoutMapper : Profile
    {
        public LayoutMapper()
        {
            CreateMap<LayoutTemplate, Layout>()
                .ForMember(dest => dest.PositionX, opt => opt.MapFrom(src => ToDouble(src.X)))
                .ForMember(dest => dest.PositionY, opt => opt.MapFrom(src => ToDouble(src.Y)))
                .ForMember(dest => dest.Width, opt => opt.MapFrom(src => ToDouble(src.Width)))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => ToDouble(src.Height)));
        }

        private double ToDouble(string value)
        {
            return double.TryParse(value, out var result) ? result : 0;
        }
    }
}
