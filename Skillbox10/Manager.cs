using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillbox10
{
    public class Manager : Account, IChange<Manager>
    {
        public Manager() { }
        public Manager(int id, string lastName, string firstName, string patronymic, string phoneNumber, string passport) : base(id, lastName, firstName, patronymic, phoneNumber, passport)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            _passport = passport;
        }
        /// <summary>
        /// считывание аккаунтов из файла "Accounts.txt"
        /// </summary>
        /// <returns>возвращает список аккаунтов</returns>
        public List<Manager> Read()
        {
            StreamReader sr = new StreamReader("Accounts.txt");
            List<Manager> accs = new List<Manager>();
            List<string> acc = new List<string>();
            while (!sr.EndOfStream)
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('#');
                    foreach (string part in parts)
                    {
                        acc.Add(part);
                    }
                    Manager ac = new Manager(Convert.ToInt32(acc[0]), acc[1], acc[2], (acc[3]), acc[4], acc[5]);
                    if (acc.Count > 6)
                    {
                        ac.TimeDataChange = Convert.ToDateTime(acc[6]);
                        ac.Changes = acc[7];
                        ac.TypeChange = acc[8];
                        ac.WhoChange = acc[9];
                    }
                    accs.Add(ac);
                    acc.Clear();
                }

            }
            sr.Close();
            return accs;
        }
        /// <summary>
        /// перезапись списка аккаунтов в файл
        /// </summary>
        /// <param name="list">список аккаунтов для записи</param>
        public void Write(List<Manager> list)
        {
            StreamWriter sw = new StreamWriter("Accounts.txt");
            foreach (Manager el in list)
            {
                sw.WriteLine(el.ToFile("#"));
            }
            sw.Close();
        }
        public Manager Changing(string newValue, Manager selectedAcc, int trigger)
        {
            switch (trigger)
            {
                case 0:
                    selectedAcc.LastName = newValue;
                    selectedAcc.Changes = "LaastName";
                    selectedAcc.TypeChange = "изменение LastName";
                    break;
                case 1:
                    selectedAcc.FirstName = newValue;
                    selectedAcc.Changes = "FirstName";
                    selectedAcc.TypeChange = "изменение FirstName";
                    break;
                case 2:
                    selectedAcc.Patronymic = newValue;
                    selectedAcc.Changes = "Patronymic";
                    selectedAcc.TypeChange = "изменение Patronymic";
                    break;
                case 3:
                    selectedAcc.PhoneNumber = newValue;
                    selectedAcc.Changes = "PhoneNumber";
                    selectedAcc.TypeChange = "изменение Phonenumber";
                    break;
                case 4:
                    selectedAcc._passport = newValue;
                    selectedAcc.Changes = "Passport";
                    selectedAcc.TypeChange = "изменение Passport";
                    break;
            }
            selectedAcc.TimeDataChange = DateTime.Now;
            selectedAcc.WhoChange = "Manager";
            return selectedAcc;
        }
    }
}
