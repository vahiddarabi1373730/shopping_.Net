using Shopping_Data_Layer.Common;
using Shopping_Data_Layer.Entities.Account;

namespace Shopping_Data_Layer.Entities.Access;

public class UserRole:BaseEntity
{
    #region Properties

    public long UserId { get; set; }
    public long RoleId { get; set; }
    
    #endregion
    
    #region Relations

    public User User { get; set; }
    public Role Role { get; set; }
    
    #endregion
}