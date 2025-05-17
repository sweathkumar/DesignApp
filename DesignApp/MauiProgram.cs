using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace DesignApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Inter_18pt-Thin.ttf", "InterThin");
                    fonts.AddFont("Inter_18pt-ThinItalic.ttf", "InterThinItalic");
                    fonts.AddFont("Inter_18pt-ExtraLight.ttf", "InterExtraLight");
                    fonts.AddFont("Inter_18pt-ExtraLightItalic.ttf", "InterExtraLightItalic");
                    fonts.AddFont("Inter_18pt-Light.ttf", "InterLight");
                    fonts.AddFont("Inter_18pt-LightItalic.ttf", "InterLightItalic");
                    fonts.AddFont("Inter_18pt-Regular.ttf", "InterRegular");
                    fonts.AddFont("Inter_18pt-Italic.ttf", "InterItalic");
                    fonts.AddFont("Inter_18pt-Medium.ttf", "InterMedium");
                    fonts.AddFont("Inter_18pt-MediumItalic.ttf", "InterMediumItalic");
                    fonts.AddFont("Inter_18pt-SemiBold.ttf", "InterSemiBold");
                    fonts.AddFont("Inter_18pt-SemiBoldItalic.ttf", "InterSemiBoldItalic");
                    fonts.AddFont("Inter_18pt-Bold.ttf", "InterBold");
                    fonts.AddFont("Inter_18pt-BoldItalic.ttf", "InterBoldItalic");
                    fonts.AddFont("Inter_18pt-ExtraBold.ttf", "InterExtraBold");
                    fonts.AddFont("Inter_18pt-ExtraBoldItalic.ttf", "InterExtraBoldItalic");
                    fonts.AddFont("Inter_18pt-Black.ttf", "InterBlack");
                    fonts.AddFont("Inter_18pt-BlackItalic.ttf", "InterBlackItalic");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

#if ANDROID
    Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
    {
        if (view is DesignApp.Controls.RoundedEntry)
        {
            handler.PlatformView.Background = null; // Removes underline
            handler.PlatformView.SetPadding(0, 0, 0, 0); // Removes default padding
        }
    });
#endif

            return builder.Build();
        }
    }
}
