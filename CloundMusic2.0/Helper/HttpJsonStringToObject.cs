using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundMusic2._0.Helper
{
    /// <summary>
    /// 描述：工具类，用于处理把http请求返回的json转换成一个对象的东西，这部分如果失败了，也会在这统一处理
    /// 类的单一职责
    /// 作者：liufuwentao
    /// 时间：2020/8/22 10:18:13
    /// </summary>
    public static class HttpJsonStringToObject
    {
        public static T JsonStringToObjectT<T>(T t,string jsonStr)
        {
            t = (T)JsonConvert.DeserializeObject(jsonStr);
            return t;
        }
    }
}
