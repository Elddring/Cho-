using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Магазин
{
    internal class Avtorization
    { 
        public static int Autorization(List<(string, string)> workers)
        {
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Введите логин: ");
                Console.Write("Введите пароль: ");
                Console.SetCursorPosition(20, 2);
                string name = Console.ReadLine();

                var password = PasswordInput(name, workers);
                if (password.Item3 == false)
                {
                    return -1;
                }
                else if (password.Item3 == true)
                {
                    foreach (var worker in workers)
                    {
                        Console.WriteLine(worker);
                    }
                    return workers.IndexOf((password.Item1, password.Item2));
                }
            }
        }


        public static (string, string, bool) PasswordInput(string name, List<(string, string)> workers)
        {
            string inpt = string.Empty;
            while (!workers.Contains((name, inpt)))
            {
                Console.SetCursorPosition(0, 3);
                Console.Write("Введите пароль: ");
                inpt = string.Empty;
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        Console.Write("");
                        inpt += key.KeyChar;
                    }
                    else
                    {
                        Console.Write("*");
                        inpt += key.KeyChar;
                    }
                }

                if (!workers.Contains((name, inpt)))
                {
                    Console.WriteLine("Нет такого пользователя или пароля");
                    Console.Clear();
                    Program.Nachalo();
                }
            }
            if (!workers.Contains((name, inpt)))
            {
                return (name, inpt, false);
            }
            else if (workers.Contains((name, inpt)))
            {
                return (name, inpt, true);
            }

            else
            {
                Console.WriteLine("Bred kakoito");
                return (name, inpt, false);
            }
        }

        
    }

}









































/*if (status == "buyer")
{
    Console.WriteLine("\r\nСписок команд для покупателя\r\n" + new string('_', 50));

    var table = new ConsoleTable("Команда", "Параметры", "Описание"); // Заголовок таблицы

    // строки таблицы
    table.AddRow(new string[] { "get_products", "", "Вывести список товаров" });
    table.AddRow(new string[] { "check_chart", "", "Просмотр корзины" });
    table.AddRow(new string[] { "add_chart", "product count", "Добавление товара в корзину" });
    table.AddRow(new string[] { "change_chart", "product count", "Изменение кол-ва товара в корзине" });
    table.AddRow(new string[] { "delete_chart", "product", "Удаление товара из корзины" });

    // вывод таблицы
    table.Write();

    // далее коментировать таблицы не буду
}
else if (status == "admin")
{
    Console.WriteLine("\r\nСписок команд для администратора\r\n" + new string('_', 50));

    var table = new ConsoleTable("Команда", "Параметры", "Описание");

    table.AddRow(new string[] { "delete_user", "login", "Удалить пользовтеля" });
    table.AddRow(new string[] { "change_user", "login", "Изменить пользователя" });
    table.AddRow(new string[] { "add_user", "", "Добавить пользователя" });
    table.AddRow(new string[] { "add_product", "", "Добавить товар" });
    table.AddRow(new string[] { "change_product", "product", "Изменить товар" });
    table.AddRow(new string[] { "delete_product", "product", "Удалить товар" });
    table.AddRow(new string[] { "add_chart", "product count login", "Добавление товара в корзину пользователя" });
    table.AddRow(new string[] { "change_chart", "product count login", "Изменение кол-ва товара в корзине пользователя" });
    table.AddRow(new string[] { "delete_chart", "product login", "Удаление товара из корзины пользователя" });

    table.Write();
}
else if (status == "hr")
{
    Console.WriteLine("\r\nСписок команд для HR\r\n" + new string('_', 50));

    var table = new ConsoleTable("Команда", "Параметры", "Описание");

    table.AddRow(new string[] { "get_users", "", "Вывести список пользователей" });
    table.AddRow(new string[] { "add_worker", "login", "Нанять пользователя" });
    table.AddRow(new string[] { "delete_worker", "login", "Уволить пользователя" });
    table.AddRow(new string[] { "change_worker", "login", "Изменить пользователя" });

    table.Write();
}
else if (status == "warehouse")
{
    Console.WriteLine("\r\nСписок команд для кладовщика\r\n" + new string('_', 50));

    var table = new ConsoleTable("Команда", "Параметры", "Описание");

    table.AddRow(new string[] { "get_products", "", "Вывести список товаров" });
    table.AddRow(new string[] { "update_product_count", "product", "Изменить количество товара" });
    table.AddRow(new string[] { "unready_product", "product", "Изменить срок годности товара" });
    table.AddRow(new string[] { "transfer_product", "product", "Изменить склад товара" });

    table.Write();
}
else if (status == "cassa")
{
    Console.WriteLine("\r\nСписок команд для кассира\r\n" + new string('_', 50));

    var table = new ConsoleTable("Команда", "Параметры", "Описание");

    table.AddRow(new string[] { "get_chart_list", "", "Просмотр списка корзин" });
    table.AddRow(new string[] { "check_chart", "login", "Просмотр корзины" });
    table.AddRow(new string[] { "complete_order", "login", "Оформление заказа" });

    table.Write();
}
else if (status == "finance")
{
    Console.WriteLine("\r\nСписок команд для бухгалтера\r\n" + new string('_', 50));

    var table = new ConsoleTable("Команда", "Параметры", "Описание");

    table.AddRow(new string[] { "get_order_list", "", "Просмотр списка заказов" });
    table.AddRow(new string[] { "get_order", "period", "Просмотр информации по заказам за период (period - day, month, quoter, year, all)" });
    table.AddRow(new string[] { "check_order", "order", "Просмотр информации по заказу" });
    table.AddRow(new string[] { "send_payment", "", "Выдача зарплат за месяц" });
    table.AddRow(new string[] { "get_payment", "period", "Просмотр информации по зарплатам за период (period - month, quoter, year, all)" });
    table.AddRow(new string[] { "get_budget", "period", "Просмотр информации по бюджету за период (period - month, quoter, year, all)" });

    table.Write();
}*/
