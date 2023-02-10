using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

namespace Code.Extensions
{
    public static class AsyncExtensions
    {
        public static TaskAwaiter GetAwaiter(this AsyncOperation asyncOp)
        {
            var tcs = new TaskCompletionSource<AsyncOperation>();
            asyncOp.completed += operation => { tcs.SetResult(operation); };
            return ((Task)tcs.Task).GetAwaiter();
        }
    }
}