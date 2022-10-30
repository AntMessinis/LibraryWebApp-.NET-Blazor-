using Microsoft.JSInterop;

namespace AdminPanel.Helper
{
    public static class IJSRuntimeExtention
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }

        public static async ValueTask ShowConfirmModal(this IJSRuntime jsRuntime)
        {
            await jsRuntime.InvokeVoidAsync("showDeleteModal");
        }

        public static async ValueTask HideConfirmModal(this IJSRuntime jsRuntime)
        {
            await jsRuntime.InvokeVoidAsync("hideDeleteModal");
        }
    }
}
