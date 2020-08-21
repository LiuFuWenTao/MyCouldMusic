///用户管理者工厂方法，用于构建用户实体返回
public class UserManagerFactory{
   

    public IUserManager Build(){
        
        return new UserManager();
    }
}