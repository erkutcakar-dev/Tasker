using Microsoft.Extensions.Logging;

#if ANDROID
using Microsoft.Maui.Handlers;
using Android.Content.Res;
using Android.Graphics;
#endif

namespace Tasker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Roboto-Regular.tff", "Roboto");
                });

#if ANDROID
EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
{
    handler.PlatformView.BackgroundTintList =
        ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
});
#endif


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
