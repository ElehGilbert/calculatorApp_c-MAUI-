using Android.App;
using Android.Content.Res;
using Android.Runtime;

namespace Caleh
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
            {
                if (view is Entry)
                {


                    //Removing Line Under the answer
                    handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent); //Turning Keyboard Transparent

                    handler.PlatformView.ShowSoftInputOnFocus = false; //Turns off the keyboard popup functionality


                }
            });
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
