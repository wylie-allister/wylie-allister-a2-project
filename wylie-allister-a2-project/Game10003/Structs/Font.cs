/*////////////////////////////////////////////////////////////////////////
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 *////////////////////////////////////////////////////////////////////////

namespace Game10003
{
    /// <summary>
    ///     Represents a font.
    /// </summary>
    /// <remarks>
    ///     Wrapper around Raylib.Font
    /// </remarks>
    public readonly record struct Font
    {
        /// <summary>
        ///     File path of this font.
        /// </summary>
        public string FilePath { get; init; }

        /// <summary>
        ///     Name of this font file.
        /// </summary>
        public string FileName { get; init; }


        [GeneratorTools.OmitFromDocumentation]
        public Raylib_cs.Font RaylibFont { get; init; }

        [GeneratorTools.OmitFromDocumentation]
        public static implicit operator Font(Raylib_cs.Font raylibFont)
        {
            var font = new Font()
            {
                RaylibFont = raylibFont,
            };
            return font;
        }

        [GeneratorTools.OmitFromDocumentation]
        public static implicit operator Raylib_cs.Font(Font font)
        {
            var raylibFont = font.RaylibFont;
            return raylibFont;
        }
    }
}
