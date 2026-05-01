using Microsoft.JSInterop;

namespace Playground.FrontEnd.Base.Functions
{
    public sealed class DeviceDetected(IJSRuntime js)
    {
        private readonly IJSRuntime _js = js;

        public bool ShowDesktop { get; private set; }
        public bool IsDetected { get; private set; }

        public async Task DetectAsync()
        {
            if (IsDetected)
                return;

            try
            {
                ShowDesktop = await _js.InvokeAsync<bool>("isDesktop");
            }
            catch
            {
                ShowDesktop = true; // fail-safe
            }

            IsDetected = true;
        }
    }
}