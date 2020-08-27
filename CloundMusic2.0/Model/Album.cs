using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundMusic2._0.Model
{
    /// <summary>
    /// 描述：专辑实体
    /// 作者：liufuwentao
    /// 时间：2020/8/22 11:05:32
    /// </summary>
    public class Album
    {
        //专辑id
        public string Id { get; set; }
        //专辑名称
        public string Name { get; set; }
        //作者
        public Artist Artist { get; set; }
        //发表时间
        public string PublishTime { get; set; }
        //大小
        public int Size { get; set; }
        //
        public string CopyRightId { get; set; }
        //
        public string Status { get; set; }
        //
        public string PicId { get; set; }
        //
        public string Mark { get; set; }
    }
}
