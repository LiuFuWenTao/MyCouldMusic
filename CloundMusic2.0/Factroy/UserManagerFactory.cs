using CloundMusic2._0.Model;
///用户管理者工厂方法，用于构建用户实体返回
public static class UserManagerFactory
{
    public static IUserManager Build()
    {

        return new UserManager();
    }
}