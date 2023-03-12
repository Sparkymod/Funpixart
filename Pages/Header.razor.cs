using Funpixart.Components.Notification;
using Funpixart.Data.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MineStatLib;
using Serilog;

namespace Funpixart.Pages
{
    public partial class Header
    {
        [CascadingParameter] public IJSServices JSServices { get; set; }
        [CascadingParameter] public INotificationService Notification { get; set; }

        public MineStat? Stats { get; protected set; }

        protected override void OnInitialized()
        {
            Task.Delay(1500);
            //Stats = new("mc.funpixart.net", 25565);
            base.OnInitialized();
        }

        async Task CopyToClipboard()
        {
            // Writing to the clipboard may be denied, so you must handle the exception
            try
            {
                await JSServices.WriteTextAsync("https://rafamod.com");
                Notification.Notify(NotificationType.Success, "Copied!","System");
            }
            catch
            {
                Console.WriteLine("Cannot write text to clipboard");
                Log.Logger.Warning("Cannot write text to clipboard");
            }
        }
    }
}