using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi!";
        public static string CarDeleted = "Araç silindi!";
        public static string CarUpdated = "Araç güncellendi!";
        public static string CarNameInValid = "Araç ismi geçersiz!";
        public static string MaintananceTime = "Sitem bakımda";
        public static string CarsListed = "Araçlar listelendi";
        public static string BrandAdded = "Marka eklendi!";
        public static string BrandDeleted = "Marka silindi!";
        public static string BrandUpdated = "Marka güncellendi!";
        public static string BrandNameInValid = "Marka ismi geçersiz!";
        public static string BrandsListed = "Markalar listelendi";
        public static string ColorAdded = "Renk eklendi!";
        public static string ColorDeleted = "Renk silindi!";
        public static string ColorUpdated = "Renk güncellendi!";
        public static string ColorNameInValid = "Renk ismi geçersiz!";
        public static string ColorsListed = "Renkler listelendi";
        public static string RentsAdded = "Satış eklendi!";
        public static string RentsDeleted = "Satış silindi!";
        public static string RentsUpdated = "Satış güncellendi!";
        public static string RentsUnAveliable = "Uygun olmayan araç!";
        public static string RentsListed = "Satışlar listelendi";
        public static string CarImageCountExceded = "Bir araç en fazla 5 adet resim alablir";
        public static string CheckImageRestriction = "Fotoğraf kısıltlaması";
        public static string FileDeletionException="Fotoğraf silme hatası";
        public static string CarImageListed = "Fotoğraflar listelendi";
        public static string CarImageNotFound = "Fotoğraf bulunamadı";
        public static string CarImageUpdated="Fotoğraf Güncellendi";
        public static string CarImageLimitExceeded="Bir araç en fazla 5 adet resim alabilir.";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered="Kayıt oldu.";
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string PasswordError="Hatalı şifre";
        public static string SuccessfulLogin="Giriş başarılı.";
        public static string UserAlreadyExists="Kayıtlı kullanıcı";
        public static string AccessTokenCreated="";
    }
}

