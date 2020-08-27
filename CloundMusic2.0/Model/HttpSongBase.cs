using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundMusic2._0.Model
{
    /// <summary>
    /// 描述：HTTP接口返回的查询结果
    /// 作者：liufuwentao
    /// 时间：2020/8/22 11:14:07
    /// </summary>
    public class HttpSongBase
    {
        //结果集
        public Result Result { get; set; }
        //返回码
        public int Code { get; set; }
    }
}
