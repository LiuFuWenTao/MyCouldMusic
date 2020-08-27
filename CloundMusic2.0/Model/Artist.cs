using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CloundMusic2._0.Model
{
    /// <summary>
    /// 描述：作者实体
    /// 作者：liufuwentao
    /// 时间：2020/8/22 11:00:01
    /// </summary>
    public class Artist
    {
        //作者id
        public string Id { get; set; }
        //作者名称
        public string Name { get; set; }
        //作者图片url
        public string PicUrl { get; set; }
        //别民
        public string[] Alias { get; set; }
        //专辑数量
        public int AlbumSize { get; set; }
        //图片id吧
        public string PicId { get; set; }
        //
        public string Img1v1Url { get; set; }
        //
        public string Img1v1 { get; set; }
        //
        public string Trans { get; set; }
    }
}
