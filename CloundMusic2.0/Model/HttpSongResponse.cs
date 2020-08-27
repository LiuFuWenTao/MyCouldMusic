using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundMusic2._0.Model
{
    /// <summary>
    /// 描述：获取音乐地址返回的实体
    /// 作者：liufuwentao
    /// 时间：2020/8/24 12:24:50
    /// </summary>
    public class HttpSongResponse
    {
        /// <summary>
        /// 音乐或者MV的数据
        /// </summary>
        public SongData[] Data { get; set; }
        /// <summary>
        /// 返回码
        /// </summary>
        public int Code { get; set; }
    }
}
