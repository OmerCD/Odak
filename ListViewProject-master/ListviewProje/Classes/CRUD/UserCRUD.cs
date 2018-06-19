using System;
using System.Linq;
using ListviewProje.Models.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace ListviewProje.Classes.CRUD
{
    public class UserCRUD : CRUD<User>
    {
        public UserCRUD()
        {
            Table = DbFactory.User;
        }
        /// <summary>
        /// Checks if the given parameters are correct for the login. If it is correct returns User entity, if it is not correct it returns null object
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User CheckAuthentication(string userName, string password)
        {
            try
            {
                var filter = new BsonDocument { { "UserName", userName }, { "Password", password },{"IsDeleted",0} };
                var cursor = Table.FindSync(filter);
                cursor.MoveNext();
                var batch = cursor.Current;
                return batch==null ? null : BsonSerializer.Deserialize<User>(batch.FirstOrDefault());
            }
            catch (Exception)
            {

                return null;
            }

        }
        public static bool CheckIfUserLastAdmin(Type type,string userId)
        {
            if (type == typeof(User))
            {
                var userCRUD = DbFactory.UserCRUD;
                var selectedUser = userCRUD.GetOne(userId);
                if (selectedUser.UserType == UserTypes.Yönetici)
                {
                    var adminList = userCRUD.GetAll(new BsonDocument { { "UserType", UserTypes.Yönetici }, { "IsDeleted", 0 } });
                    if (adminList.Count < 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
