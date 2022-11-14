using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Blazor_Client.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }

        public static async ValueTask ShowConfirmationModal(this IJSRuntime jsRuntime)
        {
            await jsRuntime.InvokeVoidAsync("ShowDeleteModal");
        }

        public static async ValueTask HideConfirmationModal(this IJSRuntime jSRuntime)
        {
            await jSRuntime.InvokeVoidAsync("HideDeleteModal");
        }
    }
}
