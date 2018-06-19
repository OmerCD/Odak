using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListviewProje.Classes;

namespace ListviewProje.Models.Entity
{
    public class User : DbObject
    {
        [Custom(MinLength = 4, MaxLength = 32, FieldName = "Kullanıcı Adı", Searchable = true)]
        public string UserName { get; set; }
        [Custom(MinLength = 6, MaxLength = 14, IsPassword = true, FieldName = "Şifre")]
        public string Password { get; set; }
        [Custom(MinLength = 2, MaxLength = 40, FieldName = "İsim Soyisim", Searchable = true)]
        public string Name { get; set; }
        [Custom(MinLength = 3, MaxLength = 64, PlaceHolderText = "isim@domain.com", FieldName = "E-Posta", RegexPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", Searchable = true)]
        public string Email { get; set; }
        [Custom(MinLength = 10, MaxLength = 10, PlaceHolderText = "5XXXXXXXXX", FieldName = "Telefon Numarası", RegexPattern = @"^[0-9]{9}", Searchable = true)]
        public string PhoneNumber { get; set; }
        [Custom(FieldName = "Kullanıcı Tipi")]
        public UserTypes UserType { get; set; }
        public int Rank { get; set; } //Admin 0, kendininkilerden büyüklerin işlerini görebilecek
        //[Custom(FieldName = "İzin verilen Modüller")] //todo
        public string[] AllowedModules { get; set; }

        public User()
        {
        }

        public User(string userName, string password, string fullName, string email, UserTypes userType, string[] allowedModules) : base()
        {
            UserName = userName;
            Password = password;
            Name = fullName;
            Email = email;
            UserType = userType;
            AllowedModules = allowedModules;
        }


        public UserTypes GetUserType()
        {
            return UserType;
        }
    }
}
