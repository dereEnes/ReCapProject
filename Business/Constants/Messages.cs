﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MantenanceTime = "Sistem Bakımda";
        //Brand Messages
        public static string BrandAdded = "Marka başarılı bir şekilde eklendi.";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandsListed = "Markalar listelendi";
        public static string BrandListed = "Marka listelendi";
        public static string BrandNameAlreadyExist = "Bu isimde bir marka zaten var!";
        //Car Messages
        public static string CarAdded = "Araba başarılı bir şekilde eklendi.";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarListed = "Araba listelendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarNameInvalid = "Araba ismi uzunluğu en az 2 karakter olmalı";
        public static string CarDailyPriceInvalid = "Günlük fiyatı 0 dan büyük olmalı";
        //Color Messages
        public static string ColorAdded = "Renk başarılı bir şekilde eklendi.";
        public static string ColorListed = "Renk listelendi";
        public static string ColorsListed = "Renkler listelendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        //Rental Messages
        public static string RentAdded = "Kiralama başarılı bir şekilde eklendi.";
        public static string RentListed = "Kiralama listelendi";
        public static string RentsListed = "Kiralamalar listelendi";
        public static string RentDeleted = "Kiralama silindi";
        public static string RentUpdated = "Kiralama güncellendi";
        public static string RentFailed = "Kiralama hatası";
        //User Messages
        public static string UserAdded = "Kullanıcı başarılı bir şekilde eklendi.";
        public static string UserListed = "Kullanıcı listelendi";
        public static string UsersListed = "Kullanıcı listelendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        //Customer Messages
        public static string CustomerAdded = "Müşteri başarılı bir şekilde eklendi.";
        public static string CustomerListed = "Müşteri listelendi";
        public static string CustomersListed = "Müşteriler listelendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";

        public static string ImagesAdded = "Resim Eklendi";

        public static string FailAddedImageLimit = "Resim ekleme limitine ulaşıldı.";

        public static string AuthorizationDenied = "Yetkilendirme reddedildi";

        public static string UserRegistered = "Kullanıcı kaydedildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Böyle bir kullanıcı zaten var";
        public static string AccessTokenCreated = "AccessToken Oluşturuldu";

        public static string CustomerDidntFound = "Böyle bir müşteri yok";
        public static string carIsNotAvailable = "Bu araç bu tarihler arası kiralanamaz";
        public static string returnDateMustBiggerThenRentDate = "Araç teslim tarihi araç kiralama tarihinden daha büyük olmalı";

        public static string SuccessfulPayment = "Başarılı Ödeme";
        public static string FailedError = "Ödeme Başarısız";

        public static string CreditCardAdded = "Kredi kartı eklendi";
    }
}
