using CloundMusic2._0.Model;
///音乐实体
public class Song{
    //id用于去获取音乐列表
    public string Id { get; set; }
    //歌曲名称
    public string Name { get; set; }
    //作者
    public Artist[] Artists { get; set; }
    //专辑
    public Album Album { get; set; }
    //不知道干啥的，先记录下来
    public string  Duration { get; set; }

    public string CopyrightId { get; set; }

    public string status { get; set; }
    //别民
    public string[] Alias { get; set; }

    public string Rtype { get; set; }

    public string Ftype { get; set; }
    //MV的id
    public string MvId { get; set; }

    public string Fee { get; set; }

    public string RUrl { get; set; }

    public string Mark { get; set; }
}