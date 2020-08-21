/// <summary>
/// 音乐接口
/// 
/// </summary>
public interface IMusicManager
{
    ///找寻某一首歌曲，输入关键字，返回一个音乐实体列表，
    ///不过转换音乐的工作要放到工具类去做，单一职责原则

    Music[] SearchMusic(string keyword);

    ///输入评论
    ///用评论实体更好，因为这样后续如果实体发生变化，
    ///不需要修改接口，不过实体变化还是非常麻烦，修改起来容易出错
    ///最好还是一开始就写好对应的实体

    void WriteComment(Comment comment);

    ///查看这首歌的所有评论，分页查询
    
    Comment[] OpenComment(string musicId,int size);
}