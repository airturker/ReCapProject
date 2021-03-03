using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class UserMessages
    {
        public static string AddedUser = "Kullanıcı başarıyla eklendi.";
        public static string DeletedUser = "Kullanıcı başarıyla silindi.";
        public static string UpdatedUser = "Kullanıcı başarıyla güncellendi.";
        public static string AuthorizationDenied = "yetkiniz yok.";
        public static string UserRegistered = "kayıt oldu";
        public static string UserNotFound ="kullanıcı bulunamadı";
        public static string PasswordError ="parola hata";
        public static string SuccessfulLogin= "başarılı giriş";
        public static string UserAlreadyExists= "kullanıcı mevcut";
        internal static string AccessTokenCreated="token oluşturuldu";
    }
}
