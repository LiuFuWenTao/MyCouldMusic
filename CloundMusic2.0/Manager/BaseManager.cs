using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;

namespace CloundMusic2._0.Manager
{
    /// <summary>
    /// 描述：管理类的基类，用于同步调用接口，后续的日志记录我会考虑是否放这里
    /// 作者：liufuwentao
    /// 时间：2020/8/22 10:10:35
    /// </summary>
    public class BaseManager
    {

        ///// <summary>
        ///// 日志
        ///// </summary>
        //protected ILogger logger = LoggerBuilder.Build();
        /// <summary>
        /// 同步调用接口
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="invoke"></param>
        /// <param name="success"></param>
        /// <param name="error"></param>
        protected TResult InvokeAsyncTask<TResult>(ITask<TResult> invoke, Action<TResult> success = null, Action<Task<TResult>> error = null)
        {
            var invokeTask = Task.Run<TResult>(async () =>
            {
                return await invoke.InvokeAsync();
            });
            invokeTask.Wait(1000 * 30);

            if (invokeTask.IsFaulted)
            {
                foreach (var item in invokeTask.Exception.InnerExceptions)
                {
                    //TODO  日志问题之后我统一考虑
                }
                //抛出内部异常
                throw invokeTask.Exception.InnerException;
            }
            else
            {
                return invokeTask.Result;
            }
        }

        protected async Task<TResult> InvokeMethod<TResult>(ITask<TResult> invoke)
        {
            return await invoke.InvokeAsync();
        }

    }
}
