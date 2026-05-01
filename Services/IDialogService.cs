using Microsoft.AspNetCore.Components;

namespace Playground.Services
{
    public interface IDialogService
    {
        Task<TResult?> ShowAsync<TDialog, TResult>(DialogParameters? parameters = null)
            where TDialog : ComponentBase;

        Task ShowByTypeAsync(Type dialogType, DialogParameters? parameters = null);

        void Close<TResult>(TResult? result = default);

        event Action<DialogInstance>? OnDialogOpen;
        event Action<DialogInstance>? OnDialogClose;
    }

    public class DialogParameters : Dictionary<string, object?> { }

    public class DialogInstance
    {
        public Type ComponentType { get; set; } = default!;
        public IDictionary<string, object?> Parameters { get; set; } = new Dictionary<string, object?>();
        public TaskCompletionSource<object?> Completion { get; set; } = new();
    }
}
