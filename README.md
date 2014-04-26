PDFSharp_ios  {#welcome}
============

I ported the current version of [PDFSharp](http://pdfsharp.codeplex.com) to Xamarin.iOS to reuse some existing code for extracting text from PDF documents on an iPhone.

Build
-----
To build simply open the solution in Visual Studio (if you have Xamarin.iOS Professional) or Xamarin Studio und build the PDFSharp_ios project.

Use
---
As I needed this library mainly to extract text from pdf files. No warranty is given that it works equally well to create them. You may need to improve the [XFont.cs](PdfSharp/PdfSharp.Drawing/XFont.cs) and [XFontFamily.cs](PdfSharp/PdfSharp.Drawing/XFontFamily.cs) files to make it work.
Working extraction has been verified by using Philip Trelford's F# snippet [here](http://fssnip.net/lT) and comparing the output on Windows and iOS. 