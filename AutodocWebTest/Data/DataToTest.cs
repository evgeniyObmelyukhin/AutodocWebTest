using System;
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
        public static string validContactName { get; } = "Новак Прохор Макарович";
        public static string validContactPhone { get; } = "9689499555";
        public static string validEMail { get; } = "ProhorNovak153@test.ru";

        //Невалидные данные
        public static string invalidLogin { get; } = "BAD-1984";
        public static string invalidPassword { get; } = "badPassword1984";

    }
}
