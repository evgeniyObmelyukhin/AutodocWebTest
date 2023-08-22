﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutodocWebTest.Data
{
    public class DataToTest//Данные для тестов
    {
        //Валидные данные
        public static string validLogin { get; } = "SMA-121";
        public static string validPassword { get; } = "A123";

        //Невалидные данные
        public static string invalidLogin { get; } = "BAD-1984";
        public static string invalidPassword { get; } = "badPassword1984";

        //Элементы для проверок
        public static string linkPrivateCabinet { get; } = "//a[contains(text(),'Личный кабинет')]";//Ссылка "Личный кабинет" на ГС
        public static string titleErrorMessage { get; } = "Не удалось авторизоваться.";//Тест ошибки при некорректном логин/пароль
        public static string titleErrorMessageNull { get; } = "Логин и пароль не могут быть пустыми";//Тест ошибки при пустых полях
    }
}