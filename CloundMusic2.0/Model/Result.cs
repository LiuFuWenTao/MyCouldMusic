using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundMusic2._0.Model
{
    /// <summary>
    /// 描述：查询歌曲信息返回的结果集
    /// 作者：liufuwentao
    /// 时间：2020/8/22 11:15:28
    /// </summary>
    public class Result
    {
        //歌曲列表
        public Song[] Songs { get; set; }

        //是否有更多
        public bool HasMore { get; set; }
        //歌曲的数量
        public int SongCount { get; set; }
    }
}
