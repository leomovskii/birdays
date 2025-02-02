using UnityEngine;

namespace Essentials {
	public static class Colors {

		#region Color list

		private static Color? _aliceBlue;
		public static Color AliceBlue => _aliceBlue ??= FromRGB(240, 248, 255);

		private static Color? _antiqueWhite;
		public static Color AntiqueWhite => _antiqueWhite ??= FromRGB(250, 235, 215);

		private static Color? _aquamarine;
		public static Color Aquamarine => _aquamarine ??= FromRGB(127, 255, 212);

		private static Color? _azure;
		public static Color Azure => _azure ??= FromRGB(240, 255, 255);

		private static Color? _beige;
		public static Color Beige => _beige ??= FromRGB(245, 245, 220);

		private static Color? _bisque;
		public static Color Bisque => _bisque ??= FromRGB(255, 228, 196);

		private static Color? _black;
		public static Color Black => _black ??= FromRGB(0, 0, 0);

		private static Color? _blanchedAlmond;
		public static Color BlanchedAlmond => _blanchedAlmond ??= FromRGB(255, 235, 205);

		private static Color? _blue;
		public static Color Blue => _blue ??= FromRGB(0, 0, 255);

		private static Color? _blueViolet;
		public static Color BlueViolet => _blueViolet ??= FromRGB(138, 43, 226);

		private static Color? _brown;
		public static Color Brown => _brown ??= FromRGB(165, 42, 42);

		private static Color? _burlyWood;
		public static Color BurlyWood => _burlyWood ??= FromRGB(222, 184, 135);

		private static Color? _cadetBlue;
		public static Color CadetBlue => _cadetBlue ??= FromRGB(95, 158, 160);

		private static Color? _chartreuse;
		public static Color Chartreuse => _chartreuse ??= FromRGB(127, 255, 0);

		private static Color? _chocolate;
		public static Color Chocolate => _chocolate ??= FromRGB(210, 105, 30);

		private static Color? _clear;
		public static Color Clear => _clear ??= new Color(0f, 0f, 0f, 0f);

		private static Color? _coral;
		public static Color Coral => _coral ??= FromRGB(255, 127, 80);

		private static Color? _cornflowerBlue;
		public static Color CornflowerBlue => _cornflowerBlue ??= FromRGB(100, 149, 237);

		private static Color? _cornsilk;
		public static Color Cornsilk => _cornsilk ??= FromRGB(255, 248, 220);

		private static Color? _crimson;
		public static Color Crimson => _crimson ??= FromRGB(220, 20, 60);

		private static Color? _cyan;
		public static Color Cyan => _cyan ??= FromRGB(0, 255, 255);

		private static Color? _darkBlue;
		public static Color DarkBlue => _darkBlue ??= FromRGB(0, 0, 139);

		private static Color? _darkCyan;
		public static Color DarkCyan => _darkCyan ??= FromRGB(0, 139, 139);

		private static Color? _darkGoldenrod;
		public static Color DarkGoldenrod => _darkGoldenrod ??= FromRGB(184, 134, 11);

		private static Color? _darkGray;
		public static Color DarkGray => _darkGray ??= FromRGB(169, 169, 169);

		private static Color? _darkGreen;
		public static Color DarkGreen => _darkGreen ??= FromRGB(0, 100, 0);

		private static Color? _darkKhaki;
		public static Color DarkKhaki => _darkKhaki ??= FromRGB(189, 183, 107);

		private static Color? _darkMagenta;
		public static Color DarkMagenta => _darkMagenta ??= FromRGB(139, 0, 139);

		private static Color? _darkOliveGreen;
		public static Color DarkOliveGreen => _darkOliveGreen ??= FromRGB(85, 107, 47);

		private static Color? _darkOrange;
		public static Color DarkOrange => _darkOrange ??= FromRGB(255, 140, 0);

		private static Color? _darkOrchid;
		public static Color DarkOrchid => _darkOrchid ??= FromRGB(153, 50, 204);

		private static Color? _darkRed;
		public static Color DarkRed => _darkRed ??= FromRGB(139, 0, 0);

		private static Color? _darkSalmon;
		public static Color DarkSalmon => _darkSalmon ??= FromRGB(233, 150, 122);

		private static Color? _darkSeaGreen;
		public static Color DarkSeaGreen => _darkSeaGreen ??= FromRGB(143, 188, 139);

		private static Color? _darkSlateBlue;
		public static Color DarkSlateBlue => _darkSlateBlue ??= FromRGB(72, 61, 139);

		private static Color? _darkSlateGray;
		public static Color DarkSlateGray => _darkSlateGray ??= FromRGB(47, 79, 79);

		private static Color? _darkTurquoise;
		public static Color DarkTurquoise => _darkTurquoise ??= FromRGB(0, 206, 209);

		private static Color? _darkViolet;
		public static Color DarkViolet => _darkViolet ??= FromRGB(148, 0, 211);

		private static Color? _deepPink;
		public static Color DeepPink => _deepPink ??= FromRGB(255, 20, 147);

		private static Color? _deepSkyBlue;
		public static Color DeepSkyBlue => _deepSkyBlue ??= FromRGB(0, 191, 255);

		private static Color? _dimGray;
		public static Color DimGray => _dimGray ??= FromRGB(105, 105, 105);

		private static Color? _dodgerBlue;
		public static Color DodgerBlue => _dodgerBlue ??= FromRGB(30, 144, 255);

		private static Color? _fireBrick;
		public static Color FireBrick => _fireBrick ??= FromRGB(178, 34, 34);

		private static Color? _floralWhite;
		public static Color FloralWhite => _floralWhite ??= FromRGB(255, 250, 240);

		private static Color? _forestGreen;
		public static Color ForestGreen => _forestGreen ??= FromRGB(34, 139, 34);

		private static Color? _fuchsia;
		public static Color Fuchsia => _fuchsia ??= FromRGB(255, 0, 255);

		private static Color? _gainsboro;
		public static Color Gainsboro => _gainsboro ??= FromRGB(220, 220, 220);

		private static Color? _ghostWhite;
		public static Color GhostWhite => _ghostWhite ??= FromRGB(248, 248, 255);

		private static Color? _gold;
		public static Color Gold => _gold ??= FromRGB(255, 215, 0);

		private static Color? _goldenrod;
		public static Color Goldenrod => _goldenrod ??= FromRGB(218, 165, 32);

		private static Color? _gray;
		public static Color Gray => _gray ??= FromRGB(128, 128, 128);

		private static Color? _green;
		public static Color Green => _green ??= FromRGB(0, 128, 0);

		private static Color? _greenYellow;
		public static Color GreenYellow => _greenYellow ??= FromRGB(173, 255, 47);

		private static Color? _honeyDew;
		public static Color HoneyDew => _honeyDew ??= FromRGB(240, 255, 240);

		private static Color? _hotPink;
		public static Color HotPink => _hotPink ??= FromRGB(255, 105, 180);

		private static Color? _indianRed;
		public static Color IndianRed => _indianRed ??= FromRGB(205, 92, 92);

		private static Color? _indigo;
		public static Color Indigo => _indigo ??= FromRGB(75, 0, 130);

		private static Color? _ivory;
		public static Color Ivory => _ivory ??= FromRGB(255, 255, 240);

		private static Color? _khaki;
		public static Color Khaki => _khaki ??= FromRGB(240, 230, 140);

		private static Color? _lavender;
		public static Color Lavender => _lavender ??= FromRGB(230, 230, 250);

		private static Color? _lavenderBlush;
		public static Color LavenderBlush => _lavenderBlush ??= FromRGB(255, 240, 245);

		private static Color? _lawnGreen;
		public static Color LawnGreen => _lawnGreen ??= FromRGB(124, 252, 0);

		private static Color? _lemonChiffon;
		public static Color LemonChiffon => _lemonChiffon ??= FromRGB(255, 250, 205);

		private static Color? _lightBlue;
		public static Color LightBlue => _lightBlue ??= FromRGB(173, 216, 230);

		private static Color? _lightCoral;
		public static Color LightCoral => _lightCoral ??= FromRGB(240, 128, 128);

		private static Color? _lightCyan;
		public static Color LightCyan => _lightCyan ??= FromRGB(224, 255, 255);

		private static Color? _lightGoldenrodYellow;
		public static Color LightGoldenrodYellow => _lightGoldenrodYellow ??= FromRGB(250, 250, 210);

		private static Color? _lightGray;
		public static Color LightGray => _lightGray ??= FromRGB(211, 211, 211);

		private static Color? _lightGreen;
		public static Color LightGreen => _lightGreen ??= FromRGB(144, 238, 144);

		private static Color? _lightPink;
		public static Color LightPink => _lightPink ??= FromRGB(255, 182, 193);

		private static Color? _lightSalmon;
		public static Color LightSalmon => _lightSalmon ??= FromRGB(255, 160, 122);

		private static Color? _lightSeaGreen;
		public static Color LightSeaGreen => _lightSeaGreen ??= FromRGB(32, 178, 170);

		private static Color? _lightSkyBlue;
		public static Color LightSkyBlue => _lightSkyBlue ??= FromRGB(135, 206, 250);

		private static Color? _lightSlateGray;
		public static Color LightSlateGray => _lightSlateGray ??= FromRGB(119, 136, 153);

		private static Color? _lightSteelBlue;
		public static Color LightSteelBlue => _lightSteelBlue ??= FromRGB(176, 196, 222);

		private static Color? _lightYellow;
		public static Color LightYellow => _lightYellow ??= FromRGB(255, 255, 224);

		private static Color? _lime;
		public static Color Lime => _lime ??= FromRGB(0, 255, 0);

		private static Color? _limeGreen;
		public static Color LimeGreen => _limeGreen ??= FromRGB(50, 205, 50);

		private static Color? _linen;
		public static Color Linen => _linen ??= FromRGB(250, 240, 230);

		private static Color? _maroon;
		public static Color Maroon => _maroon ??= FromRGB(128, 0, 0);

		private static Color? _mediumAquamarine;
		public static Color MediumAquamarine => _mediumAquamarine ??= FromRGB(102, 205, 170);

		private static Color? _mediumBlue;
		public static Color MediumBlue => _mediumBlue ??= FromRGB(0, 0, 205);

		private static Color? _mediumOrchid;
		public static Color MediumOrchid => _mediumOrchid ??= FromRGB(186, 85, 211);

		private static Color? _mediumPurple;
		public static Color MediumPurple => _mediumPurple ??= FromRGB(147, 112, 219);

		private static Color? _mediumSeaGreen;
		public static Color MediumSeaGreen => _mediumSeaGreen ??= FromRGB(60, 179, 113);

		private static Color? _mediumSlateBlue;
		public static Color MediumSlateBlue => _mediumSlateBlue ??= FromRGB(123, 104, 238);

		private static Color? _mediumSpringGreen;
		public static Color MediumSpringGreen => _mediumSpringGreen ??= FromRGB(0, 250, 154);

		private static Color? _mediumTurquoise;
		public static Color MediumTurquoise => _mediumTurquoise ??= FromRGB(72, 209, 204);

		private static Color? _mediumVioletRed;
		public static Color MediumVioletRed => _mediumVioletRed ??= FromRGB(199, 21, 133);

		private static Color? _midnightBlue;
		public static Color MidnightBlue => _midnightBlue ??= FromRGB(25, 25, 112);

		private static Color? _mintCream;
		public static Color MintCream => _mintCream ??= FromRGB(245, 255, 250);

		private static Color? _mistyRose;
		public static Color MistyRose => _mistyRose ??= FromRGB(255, 228, 225);

		private static Color? _moccasin;
		public static Color Moccasin => _moccasin ??= FromRGB(255, 228, 181);

		private static Color? _navajoWhite;
		public static Color NavajoWhite => _navajoWhite ??= FromRGB(255, 222, 173);

		private static Color? _navy;
		public static Color Navy => _navy ??= FromRGB(0, 0, 128);

		private static Color? _oldLace;
		public static Color OldLace => _oldLace ??= FromRGB(253, 245, 230);

		private static Color? _olive;
		public static Color Olive => _olive ??= FromRGB(128, 128, 0);

		private static Color? _oliveDrab;
		public static Color OliveDrab => _oliveDrab ??= FromRGB(107, 142, 35);

		private static Color? _orange;
		public static Color Orange => _orange ??= FromRGB(255, 165, 0);

		private static Color? _orangeRed;
		public static Color OrangeRed => _orangeRed ??= FromRGB(255, 69, 0);

		private static Color? _orchid;
		public static Color Orchid => _orchid ??= FromRGB(218, 112, 214);

		private static Color? _paleGoldenrod;
		public static Color PaleGoldenrod => _paleGoldenrod ??= FromRGB(238, 232, 170);

		private static Color? _paleGreen;
		public static Color PaleGreen => _paleGreen ??= FromRGB(152, 251, 152);

		private static Color? _paleTurquoise;
		public static Color PaleTurquoise => _paleTurquoise ??= FromRGB(175, 238, 238);

		private static Color? _paleVioletRed;
		public static Color PaleVioletRed => _paleVioletRed ??= FromRGB(219, 112, 147);

		private static Color? _papayaWhip;
		public static Color PapayaWhip => _papayaWhip ??= FromRGB(255, 239, 213);

		private static Color? _peachPuff;
		public static Color PeachPuff => _peachPuff ??= FromRGB(255, 218, 185);

		private static Color? _peru;
		public static Color Peru => _peru ??= FromRGB(205, 133, 63);

		private static Color? _pink;
		public static Color Pink => _pink ??= FromRGB(255, 192, 203);

		private static Color? _plum;
		public static Color Plum => _plum ??= FromRGB(221, 160, 221);

		private static Color? _powderBlue;
		public static Color PowderBlue => _powderBlue ??= FromRGB(176, 224, 230);

		private static Color? _purple;
		public static Color Purple => _purple ??= FromRGB(128, 0, 128);

		private static Color? _red;
		public static Color Red => _red ??= FromRGB(255, 0, 0);

		private static Color? _rosyBrown;
		public static Color RosyBrown => _rosyBrown ??= FromRGB(188, 143, 143);

		private static Color? _royalBlue;
		public static Color RoyalBlue => _royalBlue ??= FromRGB(65, 105, 225);

		private static Color? _saddleBrown;
		public static Color SaddleBrown => _saddleBrown ??= FromRGB(139, 69, 19);

		private static Color? _salmon;
		public static Color Salmon => _salmon ??= FromRGB(250, 128, 114);

		private static Color? _sandyBrown;
		public static Color SandyBrown => _sandyBrown ??= FromRGB(244, 164, 96);

		private static Color? _seaGreen;
		public static Color SeaGreen => _seaGreen ??= FromRGB(46, 139, 87);

		private static Color? _seaShell;
		public static Color SeaShell => _seaShell ??= FromRGB(255, 245, 238);

		private static Color? _sienna;
		public static Color Sienna => _sienna ??= FromRGB(160, 82, 45);

		private static Color? _silver;
		public static Color Silver => _silver ??= FromRGB(192, 192, 192);

		private static Color? _skyBlue;
		public static Color SkyBlue => _skyBlue ??= FromRGB(135, 206, 235);

		private static Color? _slateBlue;
		public static Color SlateBlue => _slateBlue ??= FromRGB(106, 90, 205);

		private static Color? _slateGray;
		public static Color SlateGray => _slateGray ??= FromRGB(112, 128, 144);

		private static Color? _springGreen;
		public static Color SpringGreen => _springGreen ??= FromRGB(0, 255, 127);

		private static Color? _steelBlue;
		public static Color SteelBlue => _steelBlue ??= FromRGB(70, 130, 180);

		private static Color? _tan;
		public static Color Tan => _tan ??= FromRGB(210, 180, 140);

		private static Color? _teal;
		public static Color Teal => _teal ??= FromRGB(0, 128, 128);

		private static Color? _thistle;
		public static Color Thistle => _thistle ??= FromRGB(216, 191, 216);

		private static Color? _tomato;
		public static Color Tomato => _tomato ??= FromRGB(255, 99, 71);

		private static Color? _turquoise;
		public static Color Turquoise => _turquoise ??= FromRGB(64, 224, 208);

		private static Color? _violet;
		public static Color Violet => _violet ??= FromRGB(238, 130, 238);

		private static Color? _wheat;
		public static Color Wheat => _wheat ??= FromRGB(245, 222, 179);

		private static Color? _white;
		public static Color White => _white ??= FromRGB(255, 255, 255);

		private static Color? _whiteSmoke;
		public static Color WhiteSmoke => _whiteSmoke ??= FromRGB(245, 245, 245);

		private static Color? _yellow;
		public static Color Yellow => _yellow ??= FromRGB(255, 255, 0);

		private static Color? _yellowGreen;
		public static Color YellowGreen => _yellowGreen ??= FromRGB(154, 205, 50);

		#endregion

		#region Alternate colors

		public static Color Aqua => Cyan;
		public static Color Magenta => Fuchsia;
		public static Color Snow => White;

		#endregion

		public static Color FromHex(string origin) {
			return ColorUtility.TryParseHtmlString(origin, out var color) ? color : Clear;
		}

		public static Color FromRGB(byte r, byte g, byte b) {
			return new Color32(r, g, b, 255);
		}
	}
}