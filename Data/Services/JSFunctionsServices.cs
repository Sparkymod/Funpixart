using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Funpixart.Data.Services
{
    public interface IJSServices
    {
        public ValueTask<string> ReadTextAsync();
        public ValueTask WriteTextAsync(string text);
    }

    public class JSFunctionsServices : IJSServices
    {
        private readonly IJSRuntime _jsRuntime;

        public JSFunctionsServices(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ValueTask<string> ReadTextAsync()
        {
            return _jsRuntime.InvokeAsync<string>("navigator.clipboard.readText");
        }

        public ValueTask WriteTextAsync(string text)
        {
            return _jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
        }
    }
}