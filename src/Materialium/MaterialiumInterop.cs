using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Materialium
{
    public class MaterialiumInterop
    {
        private readonly IJSRuntime JSRuntime;

        public MaterialiumInterop(IJSRuntime JSRuntime)
        {
            this.JSRuntime = JSRuntime;
        }

        public async Task<TimeSpan> GetTimeZoneOffsetAsync()
        {
            var mins = await JSRuntime.InvokeAsync<int>("Materialium.dateTime.getTimezoneOffset");
            return TimeSpan.FromMinutes(mins);
        }

        public async Task InitializeAsync(TopAppBar topAppBar, Drawer drawer)
        {
            await JSRuntime.InvokeAsync<object>("Materialium.topAppBar.nav", topAppBar.element, drawer.element);
        }
    }
}