using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundMusic2._0.Model
{
    /// <summary>
    /// 描述：音乐的实体，主要是用于获取音乐或者mv的播放地址
    /// 作者：liufuwentao
    /// 时间：2020/8/24 12:18:04
    /// </summary>
    public class SongData
    {
        /// <summary>
        /// 音乐或者mvid
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 播放地址
        /// </summary>
        public string Url { get; set; }

        public string Br { get; set; }

        public string Size { get; set; }

        public string Md5 { get; set; }

        public int Code { get; set; }

        public string Expi { get; set; }

        public string Type { get; set; }

        public string Gain { get; set; }

        public string Fee { get; set; }

        public string Uf { get; set; }

        public string Payed { get; set; }

        public string Flag { get; set; }

        public string CanExtend { get; set; }

        public string FreeTrialInfo { get; set; }

        public string Level { get; set; }

        public string EncodeType { get; set; }

    }
}
