using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillbox10
{
    internal interface IChange<T> where T : Account
    {
        /// <summary>
        /// изменение данных аккаунта
        /// </summary>
        /// <param name="newValue">новое значение</param>
        /// <param name="selectedAcc">выбранный для изменения аккаунт</param>
        /// <param name="trigger">тип изменяемых данных 0-фамилия 1-имя 2-отчество 3-номер телефона 4-паспортные данные</param>
        /// <returns>возвращает измененный аккаунт</returns>
        T Changing(string newValue, T selectedAcc, int trigger);

    }
}
