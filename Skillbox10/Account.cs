using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Skillbox10
{
    public class Account : IChange<Account>
    {
        /// <summary>
        /// идентификатор аккаунта
        /// </summary>
        public int Id { get; set;  }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; protected set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; protected set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; protected set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; protected set; }
        /// <summary>
        /// Серия и номер паспорта
        /// </summary>
        protected string _passport { get; set; }
        public DateTime TimeDataChange { get; set; }
        public string Changes {  get; set; }
        public string TypeChange {  get; set; }
        public string WhoChange {  get; set; }
        public DateTime DefaultDate = new DateTime();
        public string Passport { get { return "**** ******"; }}
        public Account() { }
        /// <summary>
        /// ининциализация Аккаунта
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="lastName">фамилия</param>
        /// <param name="firstName">имя</param>
        /// <param name="patronymic">отчество</param>
        /// <param name="phoneNumber">номер телефона</param>
        /// <param name="passport">серия и номер паспорта</param>
        public Account(int id, string lastName, string firstName, string patronymic, string phoneNumber, string passport)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            _passport = passport;
        }
        public string GetPassportInf()
        {
            return this._passport;
        }
        /// <summary>
        /// приведение аккаунта к нужному формату для записи в файл
        /// </summary>
        /// <param name="sep">разделитель для записи в файл</param>
        /// <returns>возвращает форматированную строку</returns>
        public string ToFile(string sep)
        {
            if (this.TimeDataChange == DefaultDate)
            {
                return $"{this.Id}{sep}{this.LastName}{sep}{this.FirstName}{sep}{this.Patronymic}{sep}{this.PhoneNumber}{sep}{this._passport}";
            }
            else
            {
                return $"{this.Id}{sep}{this.LastName}{sep}{this.FirstName}{sep}{this.Patronymic}{sep}{this.PhoneNumber}{sep}{this._passport}{sep}{TimeDataChange}" +
                    $"{sep}{Changes}{sep}{TypeChange}{sep}{WhoChange}";
            }
        }
        public Account Changing(string newValue, Account acc, int trigger)
        {
            acc.PhoneNumber = newValue;
            acc.TimeDataChange = DateTime.Now;
            acc.Changes = "PhoneNumber";
            acc.TypeChange = "изменение Phonenumber";
            acc.WhoChange = "Konsultant";
            return acc;
        }

    }
}

