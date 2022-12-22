using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Магазин
{
    internal class All_Mobel
    {
        public interface User
        {
            public void Create();
            public void Read(int id);
            public void Update(int id);
            public void Delete();
            public void Search();

        }
        public class Model_Emploers
        {
            public int atribute;
            public string password;
            public int id;
            public string name;
            public string secondName;
            public string patronymic;
            public DateOfStart start = new DateOfStart();
            public Passport passport = new Passport();
            public string post;
            public int salary;
            public int privID;
        }
        public class ShotUser
        {
            public int id;
            public string login;
            public string password;
            public int role;
        }
        public class Accounting
        {
            public int id;
            public string name;
            public int money;
            public int Dopmoney;

        }
        public class Passport
        {
            public int serial;
            public int number;
        }
        public class DateOfStart
        {
            public int day;
            public int year;
            public int month;
        }
    }
}
