using CloundMusic2._0.Manager;
/// <summary>
/// ���ֹ���
/// </summary>
public static class MusicManagerFactory
{
    public static IMusicManager Bulid()
    {
        return new MusicManager();
    }
}