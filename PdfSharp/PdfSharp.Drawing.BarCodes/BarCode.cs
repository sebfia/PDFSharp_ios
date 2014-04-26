

using System;
using System.Diagnostics;
using System.ComponentModel;
using PdfSharp.Drawing;

namespace PdfSharp.Drawing.BarCodes
{
  /// <summary>
  /// Represents the base class of all bar codes.
  /// </summary>
  public abstract class BarCode : CodeBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="BarCode"/> class.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="size"></param>
    /// <param name="direction"></param>
    public BarCode(string text, XSize size, CodeDirection direction)
      : base(text, size, direction)
    {
      this.text = text;
      this.size = size;
      this.direction = direction;
    }

    /// <summary>
    /// Creates a bar code from the specified code type.
    /// </summary>
    public static BarCode FromType(CodeType type, string text, XSize size, CodeDirection direction)
    {
      switch (type)
      {
        case CodeType.Code2of5Interleaved:
          return new Code2of5Interleaved(text, size, direction);

        case CodeType.Code3of9Standard:
          return new Code3of9Standard(text, size, direction);

        default:
#if !SILVERLIGHT
          throw new InvalidEnumArgumentException("type", (int)type, typeof(CodeType));
#else
          throw new ArgumentException("type", type.ToString());
#endif
      }
    }

    /// <summary>
    /// Creates a bar code from the specified code type.
    /// </summary>
    public static BarCode FromType(CodeType type, string text, XSize size)
    {
      return FromType(type, text, size, CodeDirection.LeftToRight);
    }

    /// <summary>
    /// Creates a bar code from the specified code type.
    /// </summary>
    public static BarCode FromType(CodeType type, string text)
    {
      return FromType(type, text, XSize.Empty, CodeDirection.LeftToRight);
    }

    /// <summary>
    /// Creates a bar code from the specified code type.
    /// </summary>
    public static BarCode FromType(CodeType type)
    {
      return FromType(type, String.Empty, XSize.Empty, CodeDirection.LeftToRight);
    }

    /// <summary>
    /// When overridden in a derived class gets or sets the wide narrow ratio.
    /// </summary>
    public virtual double WideNarrowRatio
    {
      get { return 0; }
      set { }
    }

    /// <summary>
    /// Gets or sets the location of the text next to the bar code.
    /// </summary>
    public TextLocation TextLocation
    {
      get { return this.textLocation; }
      set { this.textLocation = value; }
    }
    internal TextLocation textLocation;

    /// <summary>
    /// Gets or sets the length of the data that defines the bar code.
    /// </summary>
    public int DataLength
    {
      get { return this.dataLength; }
      set { this.dataLength = value; }
    }
    internal int dataLength;

    /// <summary>
    /// Gets or sets the optional start character.
    /// </summary>
    public char StartChar
    {
      get { return this.startChar; }
      set { this.startChar = value; }
    }
    internal char startChar;

    /// <summary>
    /// Gets or sets the optional end character.
    /// </summary>
    public char EndChar
    {
      get { return this.endChar; }
      set { this.endChar = value; }
    }
    internal char endChar;

    /// <summary>
    /// Gets or sets a value indicating whether the turbo bit is to be drawn.
    /// (A turbo bit is something special to Kern (computer output processing) company (as far as I know))
    /// </summary>
    public virtual bool TurboBit
    {
      get { return this.turboBit; }
      set { this.turboBit = value; }
    }
    internal bool turboBit;

    internal virtual void InitRendering(BarCodeRenderInfo info)
    {
      if (this.text == null)
        throw new InvalidOperationException(BcgSR.BarCodeNotSet);

      if (this.Size.IsEmpty)
        throw new InvalidOperationException(BcgSR.EmptyBarCodeSize);
    }

    /// <summary>
    /// When defined in a derived class renders the code.
    /// </summary>
    protected internal abstract void Render(XGraphics gfx, XBrush brush, XFont font, XPoint position);
  }
}
