using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundMusic2._0.Helper
{
    /// <summary>
    /// 描述：用于提供把json字符串解析为对象的方法
    /// 作者：liufuwentao
    /// 时间：2020/8/27 13:19:07
    /// </summary>
    public static class JsonStringToObject
    {
        /// <summary>
        /// 把解析的方法抽取出来，这样这边的异常处理由解析者自己处理，不影响别人的正常业务逻辑
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string s)
        {
            T t = default(T);
            try
            {
                t = JsonConvert.DeserializeObject<T>(s);
                
            }
            catch (Exception e)
            {
                Logger.Debug("解析对象出现错误,错误详情请查看错误日志");
                Logger.LogError(e);
               
            }
            //出现错误只记录，直接返回null，然后判断数据的是否准确由调用方确认
            return t;
        }
    }
}
