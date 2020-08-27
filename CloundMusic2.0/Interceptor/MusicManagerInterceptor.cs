using Castle.DynamicProxy;
using CloundMusic2._0.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundMusic2._0.Interceptor
{
    /// <summary>
    /// 描述：音乐管理类的拦截器
    /// 作者：liufuwentao
    /// 时间：2020/8/27 10:37:21
    /// </summary>
    public class MusicManagerInterceptor : IInterceptor
    {
        /// <summary>
        /// 拦截音乐管理类的操作接口，做日志处理和异常记录
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            string argumentsName = string.Empty;
            foreach (var a in invocation.Arguments)
            {
                argumentsName += a.ToString()+"/";
            }
            Logger.Debug("------开始运行某个方法------");
            Logger.Debug(string.Format("日志记录：运行的方法名是{0}", invocation.Method.Name));
            Logger.Debug(string.Format("日志记录：运行方法参数分别是{0}", argumentsName));
            try
            {
                //执行方法
                invocation.Proceed();
                Logger.Debug(string.Format("运行的方法{0}正常结束未报错", invocation.Method.Name));
            }
            catch (Exception e)
            {
                Logger.Debug(string.Format("日志记录，运行的方法{0}出现异常，详情请查看错误日志", invocation.Method.Name));
                Logger.LogError(e);
            }finally
            {
                Logger.Debug("------下一个方法------");
            }
                
        }
    }
}
