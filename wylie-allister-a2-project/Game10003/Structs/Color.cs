/*////////////////////////////////////////////////////////////////////////
 * Copyright (c)
 * Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
 * Game Design (374): GAME 10003 Game Development Foundations
 *////////////////////////////////////////////////////////////////////////

namespace Game10003
{
    /// <summary>
    ///     Represents an RGBA color (32-bit).
    /// </summary>
    public struct Color
    {
        #region Fields and Properties

        private byte r;
        private byte g;
        private byte b;
        private byte a;

        /// <summary>
        ///     Red colour channel.
        /// </summary>
        public int R
        {
            readonly get => r;
            set => r = ConstrainAsByte(value);
        }
        /// <summary>
        ///     Green colour channel.
        /// </summary>
        public int G
        {
            readonly get => g;
            set => g = ConstrainAsByte(value);
        }
        /// <summary>
        ///     Blue colour channel.
        /// </summary>
        public int B
        {
            readonly get => b;
            set => b = ConstrainAsByte(value);
        }
        /// <summary>
        ///     Alpha colour channel.
        /// </summary>
        public int A
        {
            readonly get => a;
            set => a = ConstrainAsByte(value);
        }

        #endregion

        #region Operators

        [GeneratorTools.OmitFromDocumentation]
        public static implicit operator Raylib_cs.Color(Color color)
        {
            Raylib_cs.Color raylibColor = new(color.r, color.g, color.b, color.a);
            return raylibColor;
        }

        [GeneratorTools.OmitFromDocumentation]
        public static implicit operator Color(Raylib_cs.Color raylibColor)
        {
            Color color = new(raylibColor.R, raylibColor.G, raylibColor.B, raylibColor.A);
            return color;
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Create a new color. Black.
        /// </summary>
        public Color()
        {
            r = g = b = 0;
            a = 255;
        }

        /// <summary>
        ///     Create a new grayscale color using the <paramref name="intensity"/> value.
        /// </summary>
        /// <param name="intensity">The intesity (brightness).</param>
        public Color(int intensity)
        {
            r = g = b = ConstrainAsByte(intensity);
            a = 255;
        }

        /// <summary>
        ///     Create a new grayscale color using the <paramref name="intensity"/> value
        ///     with <paramref name="opacity"/>.
        /// </summary>
        /// <param name="intensity">The intesity (brightness).</param>
        /// <param name="opacity">0 for fully translucid, 255 for fully opaque.</param>
        public Color(int intensity, int opacity)
        {
            r = g = b = ConstrainAsByte(intensity);
            A = opacity;
        }

        /// <summary>
        ///     Creates a new RGB color.
        /// </summary>
        /// <param name="r">Red color channel.</param>
        /// <param name="g">Green color channel.</param>
        /// <param name="b">Blue color channel.</param>
        public Color(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
            a = 255;
        }

        /// <summary>
        ///     Creates a new RGBA color.
        /// </summary>
        /// <param name="r">Red color channel.</param>
        /// <param name="g">Green color channel.</param>
        /// <param name="b">Blue color channel.</param>
        /// <param name="a">Alpha channel.</param>
        public Color(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        #endregion

        #region Pre-defined Colors and Shades

        /// <summary>
        ///     RGB(0, 0, 0)
        /// </summary>
        public static readonly Color Black = new(0);
        /// <summary>
        ///     RGB(63, 63, 63)
        /// </summary>
        public static readonly Color DarkGray = new(63);
        /// <summary>
        ///     RGB(127, 127, 127)
        /// </summary>
        public static readonly Color Gray = new(127);
        /// <summary>
        ///     RGB(195, 195, 195)
        /// </summary>
        public static readonly Color LightGray = new(195);
        /// <summary>
        ///     RGB(240, 240, 240)
        /// </summary>
        public static readonly Color OffWhite = new(240);
        /// <summary>
        ///     RGB(255, 255, 255)
        /// </summary>
        public static readonly Color White = new(255);

        /// <summary>
        ///     Fully transparent. RGBA(0, 0, 0, 0)
        /// </summary>
        public static readonly Color Clear = new(0, 0);

        /// <summary>
        ///     RGB(255, 0, 0)
        /// </summary>
        public static readonly Color Red = new(255, 0, 0);
        /// <summary>
        ///     RGB(255, 255, 0)
        /// </summary>
        public static readonly Color Yellow = new(255, 255, 0);
        /// <summary>
        ///     RGB(0, 255, 0)
        /// </summary>
        public static readonly Color Green = new(0, 255, 0);
        /// <summary>
        ///     RGB(0, 255, 255)
        /// </summary>
        public static readonly Color Cyan = new(0, 255, 255);
        /// <summary>
        ///     RGB(0, 0, 255)
        /// </summary>
        public static readonly Color Blue = new(0, 0, 255);
        /// <summary>
        ///     RGB(255, 0, 255)
        /// </summary>
        public static readonly Color Magenta = new(255, 0, 255);

        #endregion

        #region Private Methods

        private static byte ConstrainAsByte(int value)
        {
            byte byteValue = (byte)System.Math.Clamp(value, 0, 255);
            return byteValue;
        }

        #endregion

    }
}