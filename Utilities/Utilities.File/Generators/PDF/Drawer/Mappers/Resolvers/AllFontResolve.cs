using PdfSharp.Fonts;

namespace Utilities.File.Generators.PDF.Drawer.Mappers.Resolvers
{
    public class AllFontResolve : IFontResolver
    {
        private readonly Dictionary<string, byte[]> _fontData;

        public AllFontResolve()
        {
            var fontPath = Path.Combine(AppContext.BaseDirectory, Constants.FontPath);
            _fontData = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase)
            {
            { "Open Sans#Regular", File.ReadAllBytes(Path.Combine(fontPath,"OpenSans-Regular.ttf")) },
            { "Open Sans#Bold", File.ReadAllBytes(Path.Combine(fontPath, "OpenSans-Bold.ttf")) },
            { "Open Sans#Italic", File.ReadAllBytes(Path.Combine(fontPath, "OpenSans-Italic.ttf")) },
            { "Open Sans#BoldItalic", File.ReadAllBytes(Path.Combine(fontPath, "OpenSans-BoldItalic.ttf")) },

            { "Arial#Regular", File.ReadAllBytes(Path.Combine(fontPath, "Arial-Regular.ttf")) },
            { "Arial#Bold", File.ReadAllBytes(Path.Combine(fontPath, "Arial-Bold.ttf")) },
            { "Arial#Italic", File.ReadAllBytes(Path.Combine(fontPath, "Arial-Italic.ttf")) },
            { "Arial#BoldItalic", File.ReadAllBytes(Path.Combine(fontPath, "Arial-BoldItalic.ttf")) },
            };
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            string style = (isBold, isItalic) switch
            {
                (true, true) => "BoldItalic",
                (true, false) => "Bold",
                (false, true) => "Italic",
                _ => "Regular"
            };

            string key = $"{familyName}#{style}";
            if (_fontData.ContainsKey(key))
                return new FontResolverInfo(key);

            return new FontResolverInfo("Arial#Regular");
        }

        public byte[] GetFont(string faceName)
        {
            if (_fontData.TryGetValue(faceName, out byte[] data))
                return data;
            throw new Exception($"Font data not found for '{faceName}'");
        }
    }
}
