# Bad Font File Checker

The bad font file is [不给糖就捣蛋的万圣节.TTF](不给糖就捣蛋的万圣节.TTF).

## How to reporduce?

1. Install the bad font file.
2. Build and run the demo project.
3. View the exception of the running.

## The exception

```csharp
System.IO.FileFormatException: Invalid file format.
   at MS.Internal.Text.TextInterface.Native.Util.ConvertHresultToException(Int32 hr)
   at MS.Internal.Text.TextInterface.Font.CreateFontFace()
   at MS.Internal.Text.TextInterface.Font.AddFontFaceToCache()
   at MS.Internal.Text.TextInterface.Font.GetFontFace()
   at System.Windows.Media.GlyphTypeface..ctor(Font font)
   at MS.Internal.FontFace.PhysicalFontFamily.GetGlyphTypeface(FontStyle style, FontWeight weight, FontStretch stretch)
   at MS.Internal.FontFace.PhysicalFontFamily.MS.Internal.FontFace.IFontFamily.GetTypefaceMetrics(FontStyle style, FontWeight weight, FontStretch stretch)
   at System.Windows.Media.Typeface.ConstructCachedTypeface()
   at System.Windows.Media.Typeface.get_CachedTypeface()
   at System.Windows.Media.Typeface.CheckFastPathNominalGlyphs(CharacterBufferRange charBufferRange, Double emSize, Single pixelsPerDip, Double scalingFactor, Double widthMax, Boolean keepAWord, Boolean numberSubstitution, CultureInfo cultureInfo, TextFormattingMode textFormattingMode, Boolean isSideways, Boolean breakOnTabs, Int32& stringLengthFit)
   at MS.Internal.TextFormatting.SimpleRun.CreateSimpleTextRun(CharacterBufferRange charBufferRange, TextRun textRun, TextFormatterImp formatter, Int32 widthLeft, Boolean emergencyWrap, Boolean breakOnTabs, Double pixelsPerDip)
   at MS.Internal.TextFormatting.SimpleRun.Create(FormatSettings settings, CharacterBufferRange charString, TextRun textRun, Int32 cp, Int32 cpFirst, Int32 runLength, Int32 widthLeft, Int32 idealRunOffsetUnRounded, Double pixelsPerDip)
   at MS.Internal.TextFormatting.SimpleTextLine.Create(FormatSettings settings, Int32 cpFirst, Int32 paragraphWidth, Double pixelsPerDip)
   at MS.Internal.TextFormatting.TextFormatterImp.FormatLineInternal(TextSource textSource, Int32 firstCharIndex, Int32 lineLength, Double paragraphWidth, TextParagraphProperties paragraphProperties, TextLineBreak previousLineBreak, TextRunCache textRunCache)
   at MS.Internal.TextFormatting.TextFormatterImp.FormatLine(TextSource textSource, Int32 firstCharIndex, Double paragraphWidth, TextParagraphProperties paragraphProperties, TextLineBreak previousLineBreak, TextRunCache textRunCache)
   at System.Windows.Controls.TextBlock.MeasureOverride(Size constraint)
   at System.Windows.FrameworkElement.MeasureCore(Size availableSize)
   at System.Windows.UIElement.Measure(Size availableSize)
   at System.Windows.Controls.Grid.MeasureOverride(Size constraint)
   at System.Windows.FrameworkElement.MeasureCore(Size availableSize)
   at System.Windows.UIElement.Measure(Size availableSize)
   at MS.Internal.Helper.MeasureElementWithSingleChild(UIElement element, Size constraint)
   at System.Windows.Controls.ContentPresenter.MeasureOverride(Size constraint)
   at System.Windows.FrameworkElement.MeasureCore(Size availableSize)
   at System.Windows.UIElement.Measure(Size availableSize)
   at System.Windows.Controls.Decorator.MeasureOverride(Size constraint)
   at System.Windows.Documents.AdornerDecorator.MeasureOverride(Size constraint)
   at System.Windows.FrameworkElement.MeasureCore(Size availableSize)
   at System.Windows.UIElement.Measure(Size availableSize)
   at System.Windows.Controls.Border.MeasureOverride(Size constraint)
   at System.Windows.FrameworkElement.MeasureCore(Size availableSize)
   at System.Windows.UIElement.Measure(Size availableSize)
   at System.Windows.Window.MeasureOverrideHelper(Size constraint)
   at System.Windows.Window.MeasureOverride(Size availableSize)
   at System.Windows.FrameworkElement.MeasureCore(Size availableSize)
   at System.Windows.UIElement.Measure(Size availableSize)
   at System.Windows.Interop.HwndSource.SetLayoutSize()
   at System.Windows.Interop.HwndSource.set_RootVisualInternal(Visual value)
   at System.Windows.Interop.HwndSource.set_RootVisual(Visual value)
   at System.Windows.Window.SetRootVisual()
   at System.Windows.Window.SetRootVisualAndUpdateSTC()
   at System.Windows.Window.SetupInitialState(Double requestedTop, Double requestedLeft, Double requestedWidth, Double requestedHeight)
   at System.Windows.Window.CreateSourceWindow(Boolean duringShow)
   at System.Windows.Window.CreateSourceWindowDuringShow()
   at System.Windows.Window.SafeCreateWindowDuringShow()
   at System.Windows.Window.ShowHelper(Object booleanBox)
   at System.Windows.Threading.ExceptionWrapper.InternalRealCall(Delegate callback, Object args, Int32 numArgs)
   at System.Windows.Threading.ExceptionWrapper.TryCatchWhen(Object source, Delegate callback, Object args, Int32 numArgs, Delegate catchHandler)
```

## How to uninstall the font?

NOTE: UWP apps also crashes so that the font management page of the UWP settings page crashes. Instead, you should uninstall it from the `C:\Windows\Fonts` folder.

## Issue

This project is been reported to the https://github.com/dotnet/wpf repository with issue https://github.com/dotnet/wpf/issues/3987.
