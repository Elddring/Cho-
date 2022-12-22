using System;
using System.IO;
using static Магазин.All_Mobel;
/*Для тройки нужно сделать полностью рабочую авторизацию и роль администратора, учитывая структуру кода
     Администратор:
При открытии меню администратора показываются все пользователи системы
Должна быть возможность выбрать один из выведенных пунктов и посмотреть подробную информацию. Выбор пунктов должен быть выполнен через стрелочное меню
Должны быть реализованы CRUD операции (добавление - create, чтение - read, изменение - update, удаление - delete) пользователей системы. За отсутствие одной из 4 операций пункт засчитан не будет
Должен быть реализован поиск по всем атрибутам пользователя системы. Пункт, по которому нужно искать, необходимо выбирать. За отсутствие поиска по одному из атрибутов пункт засчитан не будет
При создании и изменении должна быть возможность повторного ввода данных 
(если я ввела что-то не так, у меня должна быть возможность поменять это)
Все данные должны быть сохранены в JSON или XML файл, чтобы пользователь смог даже после выхода из системы или выхода из программы вернуться повторно к этим данным     
    

Между этими ролями должна быть авторизация - администратор под администратором, кассир под кассиром и т.п.. 
Приложение должно начинаться с авторизации. Условия авторизации:
Пароль при авторизации должен быть скрыт звездочками
    -- Должна быть возможность повторного ввода логина и пароля (если я ввела что-то не так, у меня должна быть возможность поменять это)
    После авторизации должен быть вывод логина, за которым пользователь авторизовался. Если этот пользователь привязан к сотруднику (см. функционал менеджера персонала), вместо логина должно отображаться имя сотрудника
    Должна быть защита от дураков (неправильный ввод, неверный пароль, несуществующий пользователь и т.п.)
    Выход из каждого меню на уровень выше должен быть реализован по нажатию на клавишу Escape (из меню дополнительной информации в меню пунктов, из меню пунктов в авторизацию и т.п.)
    Роли пользователя должны быть реализованы через enum. Системные клавиши для стрелочного меню (F1, Escape, F2, F10, S и прочее) должны быть реализованы через enum
Для сериализации и десериализации должен быть отдельный статический класс. Внутри него должно быть только два метода - сериализация и десериализация. Не должно быть разных методов для разных типов данных
    Данные должны сохраняться в системной папке (рабочий стол, документы, изображения и прочее) вне зависимости от того, на каком компьютере находится программа
    Должен быть отдельный обычный или статический класс для авторизации пользователя. 
    */

namespace Магазин
{
    internal class Program
    {
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public static string Path = path + "\\10LABA";
        public static string json = Path + "\\usersData.json";
        public static string json1 = Path + "\\ShotUser.json";
        public static string[] roles = new string[] { "Админ", "Манагер", "Склад менеджер", "Кассир", "Бухгалтер" };

        public static void Main(string[] args)
        {
            
            Nachalo();

        }
        public static void Nachalo()
        {
            
            DirectoryInfo cratePapka = new DirectoryInfo(Path);

            if (!cratePapka.Exists)
            {
                cratePapka.Create();
            }
            List<Model_Emploers> deserealize_Employer = Json_Serealize.Des<List<Model_Emploers>>(json);

            List<ShotUser> DeserealiseSimple = Json_Serealize.Des<List<ShotUser>>(json1);

            List<(string, string)> logins = new List<(string, string)>();
            for (int i = 0; i < deserealize_Employer.Count; i++)
            {
                logins.Add((deserealize_Employer[i].name, deserealize_Employer[i].password));
            }
            int proverka = Avtorization.Autorization(logins);
            Model_Emploers Employer = new Model_Emploers();
            if (proverka != -1)
            {
                Employer = deserealize_Employer[proverka];
            }
            else
            {
                foreach (Model_Emploers i in deserealize_Employer)
                {
                    if (i.atribute == -1)
                    {
                        Employer = i;
                    }
                }
            }

            if (Employer.atribute == 1)
            {
                Console.Clear();
                Admin admin = new Admin(Employer, DeserealiseSimple);
                admin.Interface();
            }
        }

        public static void IO(Model_Emploers user)
        {
            Console.WriteLine(user.atribute);
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Добро пожаловать  {user.name}");
            Console.SetCursorPosition(85, 0);
            Console.WriteLine($"Роль: {roles[user.atribute - 1]}");
            Console.WriteLine("___________________________________________" +
                "_________________________________________________________" +
                "__________________________________________");
            if (user.atribute == 1)
            {
                AllUsers_Admin();
            }
            for (int i = 2; i < 12; i++)
            {
                Console.SetCursorPosition(100, i);
                Console.WriteLine("|");
            }
            if (user.atribute != 4)
            {
                Console.SetCursorPosition(105, 2);
                Console.WriteLine("F1 - добавить запись");
                Console.SetCursorPosition(105, 3);
                Console.WriteLine("F2 - найти запись");
                Console.SetCursorPosition(105, 4);
                Console.WriteLine("F3 - удалить запись");
                Console.SetCursorPosition(105, 5);
                Console.WriteLine("F4 - прочитать запись");
            }
        }
        public static void AllUsers_Admin()
        {
            string json = Program.Path + "\\ShotUser.json";
            List<ShotUser> DeserealiseSimple = Json_Serealize.Des<List<ShotUser>>(json);
            for (int i = 2; i < DeserealiseSimple.Count + 2; i++)
            {
                Console.SetCursorPosition(10, i);
                Console.WriteLine($"ID: {DeserealiseSimple[i - 2].id}");
                Console.SetCursorPosition(20, i);
                Console.WriteLine($"Login: {DeserealiseSimple[i - 2].login}");
                Console.SetCursorPosition(50, i);
                Console.WriteLine($"password: {DeserealiseSimple[i - 2].password}");
                Console.SetCursorPosition(90, i);
                Console.WriteLine($"Роль: {DeserealiseSimple[i - 2].role}");
            }

        }
    }

}