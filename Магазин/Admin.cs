using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Магазин.All_Mobel;

namespace Магазин
{
    internal class Admin : User
    {
        Model_Emploers admin = new Model_Emploers();
        List<ShotUser> allUsers = new List<ShotUser>();
        internal enum Post
        {
            F1 = ConsoleKey.F1,
            F2 = ConsoleKey.F2,
            F3 = ConsoleKey.F3,
            F4 = ConsoleKey.F4,
            UpArrow = ConsoleKey.UpArrow,
            DownArrow = ConsoleKey.DownArrow,
            Enter = ConsoleKey.Enter,
            Esc = ConsoleKey.Escape

        }
        public Admin(Model_Emploers worker, List<ShotUser> allUsers)
        {
            admin = worker;
            this.allUsers = allUsers;
        }
        public void Interface()
        {
            int position = 2;
            int max = allUsers.Count() + 1;
            while (true)
            {
                string json = Program.Path + "\\ShotUser.json";
                List<ShotUser> DeserealiseSimple = Json_Serealize.Des<List<ShotUser>>(json);
                max = DeserealiseSimple.Count() + 1;
                Console.Clear();
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                Program.IO(admin);
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == (ConsoleKey)Post.F1)
                {
                    Console.Clear();
                    Create();
                }
                if (key.Key == (ConsoleKey)Post.F2)
                {
                    Console.Clear();
                    Search();
                }

                if (key.Key == (ConsoleKey)Post.F3)
                {
                    Console.Clear();
                    Delete();
                }
                if (key.Key == (ConsoleKey)Post.F4)
                {
                    Console.Clear();
                    Read(position);
                }
                if (key.Key == (ConsoleKey)Post.UpArrow)
                {
                    if (position <= 2)
                    {
                        position += max - 2;
                    }
                    else
                    {
                        position--;
                    }
                }
                if (key.Key == (ConsoleKey)Post.DownArrow)
                {
                    if (position >= max)
                    {
                        position -= max - 2;
                    }
                    else
                    {
                        position++;
                    }
                }
                if (key.Key == (ConsoleKey)Post.Enter)
                {
                    Console.Clear();
                    ShotUser user = allUsers[position - 2];
                    Update(user.id);
                }
                if (key.Key == (ConsoleKey)Post.Esc)
                {
                    Console.Clear();
                    break;
                }
            }
        }
        public void Create()
        {
            string json = Program.Path + "\\ShotUser.json";
            List<ShotUser> DeserealiseSimple = Json_Serealize.Des<List<ShotUser>>(json);

            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль польвателя");
            string password = Console.ReadLine();
            Console.WriteLine("Введите роль польвателя");
            int role = Convert.ToInt32(Console.ReadLine());
            int id = DeserealiseSimple[DeserealiseSimple.Count - 1].id + 1;
            ShotUser newUser = new ShotUser();
            newUser.id = id;
            newUser.login = login;
            newUser.password = password;
            newUser.role = role;
            DeserealiseSimple.Add(newUser);
            Json_Serealize.Serialize<List<ShotUser>>(DeserealiseSimple, json);
        }

        public void Delete()
        {
            string json = Program.Path + "\\ShotUser.json";
            List<ShotUser> DeserealiseSimple = Json_Serealize.Des<List<ShotUser>>(json);
            List<int> ids = new List<int>();
            foreach (ShotUser user in DeserealiseSimple)
            {
                ids.Add(user.id);
            }
            Console.WriteLine("Укажите id пользователя которого хотите удалить");
            int id = Convert.ToInt32(Console.ReadLine());
            if (ids.Contains(id))
            {
                ShotUser user = DeserealiseSimple[ids.IndexOf(id)];
                DeserealiseSimple.Remove(user);
                Json_Serealize.Serialize<List<ShotUser>>(DeserealiseSimple, json);
            }
            else
            {
                Console.WriteLine("Такого пользователя нет");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Read(int id)
        {
            List<int> ID_all = new List<int>();
            foreach (ShotUser i in allUsers)
            {
                ID_all.Add(i.id);
            }
            ShotUser user = allUsers[ID_all.IndexOf((id))];
            Console.WriteLine($"ID пользователя{user.id}");
            Console.WriteLine($"Логин пользователя{user.login}");
            Console.WriteLine($"Роль пользователя{user.role}");
            Console.WriteLine($"Пароль пользователя{user.password}");
            Console.ReadKey();
        }
        public void Update(int userUpdate)
        {
            int position = 0;
            position = 0;
            string json = Program.Path + "\\ShotUser.json";
            List<ShotUser> DeserealiseSimple = Json_Serealize.Des<List<ShotUser>>(json);

            List<int> ID_all = new List<int>();
            foreach (ShotUser item in allUsers)
            {
                ID_all.Add(item.id);
            }
            bool login1 = false;
            bool password1 = false;
            bool role1 = false;
            string login;
            string password;
            int role;
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(3, 0);
                Console.Write("Введите новый логин");
                Console.SetCursorPosition(3, 1);
                Console.Write("Введите новый пароль польвателя");
                Console.SetCursorPosition(3, 2);
                Console.Write("Введите новую роль польвателя");
                Console.SetCursorPosition(0, position);
                Console.Write("->");
                ConsoleKeyInfo key = Console.ReadKey();
                if (position == 2 && key.Key == ConsoleKey.UpArrow)
                {
                    position++;
                }
                if (position==2)
                {
                    position--;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    position++;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    position--;
                }
                if (position ==3 && key.Key == ConsoleKey.Enter)
                {
                    login = Console.ReadLine();
                    login1 = true;
                }
                if (position == 4 && key.Key == ConsoleKey.Enter)
                {
                    password = Console.ReadLine();
                    password1 = true;
                }
                if (position == 5 && key.Key == ConsoleKey.Enter)
                {
                    role = Convert.ToInt32(Console.ReadLine());
                    role1 = true;
                }
            }
            ShotUser user = DeserealiseSimple[ID_all.IndexOf((userUpdate))];
            allUsers.Remove(user);
            user.login = login;
            user.password = password;
            user.role = role;

            allUsers.Insert(userUpdate, user);
            string filename = Program.Path + "\\ShotUser.json";
            Json_Serealize.Serialize<List<ShotUser>>(DeserealiseSimple, json);
        }
        public void Search()
        {
            Console.WriteLine("Введите ID");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль польвателя");
            string password = Console.ReadLine();
            Console.WriteLine("Введите роль польвателя");
            int role = Convert.ToInt32(Console.ReadLine());

            ShotUser user = new ShotUser();
            user.id = id;
            user.login = login;
            user.password = password;
            user.role = role;
            List<int> ID_all = new List<int>();
            foreach (ShotUser item in allUsers)
            {
                ID_all.Add(item.id);
            }
            if (ID_all.Contains(id))
            {
                Console.Clear();
                Console.WriteLine(user.id);
                Console.WriteLine(user.login);
                Console.WriteLine(user.role);
                Console.WriteLine(user.password);
                Console.WriteLine();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Такого пользователя нет");
                Console.ReadKey();
                Console.Clear();
            }
        }

        
    }
}
