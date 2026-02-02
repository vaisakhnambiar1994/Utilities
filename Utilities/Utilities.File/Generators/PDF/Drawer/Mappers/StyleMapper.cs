using AutoMapper;
using Utilities.File.Generators.PDF.Drawer.Mappers.Resolvers;
using Utilities.File.Generators.PDF.Drawer.Models.TemplateModels;
using Utilities.File.Generators.PDF.Drawer.Models.ToolModels;
using PdfSharp.Drawing;
using PdfSharp.Fonts;

namespace Utilities.File.Generators.PDF.Drawer.Mappers
{
    public class StyleMapper : Profile
    {
        public StyleMapper()
        {
            if (GlobalFontSettings.FontResolver == null)
                GlobalFontSettings.FontResolver = new AllFontResolve();

            CreateMap<StyleTemplate, Style>().AfterMap((src, dest) =>
                {
                    XFontStyleEx fontStyle = src.Bold ? XFontStyleEx.Bold : XFontStyleEx.Regular;
                    dest.Font = new XFont(src.FontFamily, src.FontSize, fontStyle);

                    XColor mainColor = ParseHexColor(src.HexColor);
                    dest.Brush = new XSolidBrush(mainColor);

                    if (src.BorderWidth > 0)
                    {
                        dest.Pen = new XPen(mainColor, src.BorderWidth);
                        if (Enum.TryParse<XDashStyle>(src.DashStyle, true, out var dash))
                            dest.Pen.DashStyle = dash;
                    }

                    if (!string.IsNullOrEmpty(src.FillColor) && src.FillColor != "Transparent")
                        dest.Brush = new XSolidBrush(ParseHexColor(src.FillColor));
                });
        }

        #region Private functions

        private XColor ParseHexColor(string hex)
        {
            try
            {
                hex = hex.Replace("#", "");
                if (hex.Length == 6)
                    return XColor.FromArgb(Convert.ToInt32(hex.Substring(0, 2), 16), Convert.ToInt32(hex.Substring(2, 2), 16), Convert.ToInt32(hex.Substring(4, 2), 16));
                else if (hex.Length == 8)
                    return XColor.FromArgb(Convert.ToInt32(hex.Substring(0, 2), 16), Convert.ToInt32(hex.Substring(2, 2), 16), Convert.ToInt32(hex.Substring(4, 2), 16), Convert.ToInt32(hex.Substring(6, 2), 16));
            }
            catch { }
            return XColors.Black;
        }

        #endregion
    }
}
