using PdfSharp.Fonts;
using PdfSharp.Drawing;
using System.IO;

public class CustomFontResolver : IFontResolver
{
    private static byte[] _sarabunFont;

    public CustomFontResolver()
    {
        // โหลดไฟล์ฟอนต์ Sarabun
        if (_sarabunFont == null)
            _sarabunFont = File.ReadAllBytes("fonts\\THSarabunNew.ttf");
    }

    public string DefaultFontName => "THSarabunNew";

    public byte[] GetFont(string faceName)
    {
        if (faceName.Equals("THSarabunNew", System.StringComparison.OrdinalIgnoreCase))
            return _sarabunFont;

        return _sarabunFont;
    }

    public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
    {
        return new FontResolverInfo("THSarabunNew");
    }
}
