using MyApp;
using System;
using System.Text;
namespace MyApp // Note: actual namespace depends on the project name.
{
    struct Users
    {
        public string day;
        public string month;
        public string year;
        public string signZodiac;
        public string signEast;
        public void show()
        {
            Console.WriteLine("{0,-15} {1,-15} {2,-15} {3, -15} {4, -15}", day, month, year, signZodiac, signEast);
        }
        public string concat()
        {
            return $"{day};{month};{year};{signZodiac};{signEast}";
        }

    }
    internal class Program
    {
        static void getData(string path, List<Users> L)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(";");
                    L.Add(new Users()
                    {
                        day = array[0],
                        month = array[1],
                        year = array[2]
                    });
                }
            }
        }

        static void printData(List<Users> L)
        {
            foreach (Users u in L)
            {
                u.show();
            }
        }

        static void createNewFile(string path, List<Users> L)
        {
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                foreach (Users u in L)
                {
                    sw.WriteLine(u.concat());
                }
            }
        }

        static void checkSigns(List<Users> L)
        {
            for (int i = 0; i < L.Count; i++)
            {
                Users u = L[i];
                int forParse = 0;

                if (u.day == "" || u.month == "" || !int.TryParse(u.day, out forParse) || !int.TryParse(u.month, out forParse))
                {
                    u.signZodiac = "Невозможно определить знак зодиака!";
                }

                else if (Convert.ToInt32(u.day) <= 0 || Convert.ToInt32(u.day) > 31 || (Convert.ToInt32(u.day) > 28 && Convert.ToInt32(u.month) == 2) || Convert.ToInt32(u.month) <= 0 || Convert.ToInt32(u.month) > 12)
                {
                    u.signZodiac = "Невозможно определить знак зодиака!";
                }

                else
                {
                    if ((Convert.ToInt32(u.month) == 3 && Convert.ToInt32(u.day) >= 21) || (Convert.ToInt32(u.month) == 4 && Convert.ToInt32(u.day) <= 20))
                    {
                        u.signZodiac = "Овен";
                    }
                    else if ((Convert.ToInt32(u.month) == 4 && Convert.ToInt32(u.day) >= 21) || (Convert.ToInt32(u.month) == 5 && Convert.ToInt32(u.day) <= 21))
                    {
                        u.signZodiac = "Телец";
                    }
                    else if ((Convert.ToInt32(u.month) == 5 && Convert.ToInt32(u.day) >= 22) || (Convert.ToInt32(u.month) == 6 && Convert.ToInt32(u.day) <= 21))
                    {
                        u.signZodiac = "Близнецы";
                    }
                    else if ((Convert.ToInt32(u.month) == 6 && Convert.ToInt32(u.day) >= 22) || (Convert.ToInt32(u.month) == 7 && Convert.ToInt32(u.day) <= 22))
                    {
                        u.signZodiac = "Рак";
                    }
                    else if ((Convert.ToInt32(u.month) == 7 && Convert.ToInt32(u.day) >= 23) || (Convert.ToInt32(u.month) == 8 && Convert.ToInt32(u.day) <= 23))
                    {
                        u.signZodiac = "Лев";
                    }
                    else if ((Convert.ToInt32(u.month) == 8 && Convert.ToInt32(u.day) >= 24) || (Convert.ToInt32(u.month) == 9 && Convert.ToInt32(u.day) <= 22))
                    {
                        u.signZodiac = "Дева";
                    }
                    else if ((Convert.ToInt32(u.month) == 9 && Convert.ToInt32(u.day) >= 23) || (Convert.ToInt32(u.month) == 10 && Convert.ToInt32(u.day) <= 22))
                    {
                        u.signZodiac = "Весы";
                    }
                    else if ((Convert.ToInt32(u.month) == 10 && Convert.ToInt32(u.day) >= 23) || (Convert.ToInt32(u.month) == 11 && Convert.ToInt32(u.day) <= 22))
                    {
                        u.signZodiac = "Скорпион";
                    }
                    else if ((Convert.ToInt32(u.month) == 11 && Convert.ToInt32(u.day) >= 23) || (Convert.ToInt32(u.month) == 12 && Convert.ToInt32(u.day) <= 21))
                    {
                        u.signZodiac = "Стрелец";
                    }
                    else if ((Convert.ToInt32(u.month) == 12 && Convert.ToInt32(u.day) >= 22) || (Convert.ToInt32(u.month) == 1 && Convert.ToInt32(u.day) <= 20))
                    {
                        u.signZodiac = "Козерог";
                    }
                    else if ((Convert.ToInt32(u.month) == 1 && Convert.ToInt32(u.day) >= 21) || (Convert.ToInt32(u.month) == 2 && Convert.ToInt32(u.day) <= 19))
                    {
                        u.signZodiac = "Водолей";

                    }
                    else if ((Convert.ToInt32(u.month) == 2 && Convert.ToInt32(u.day) >= 20) || (Convert.ToInt32(u.month) == 3 && Convert.ToInt32(u.day) <= 20))
                    {
                        u.signZodiac = "Рыбы";
                    }
                }
                if (u.year == "" || !int.TryParse(u.year, out forParse))
                {
                    u.signEast = "Невозможно определить знак по восточному календарю!";
                }
                else
                {
                    string[] signs = { "Крыса", "Бык", "Тигр", "Кот", "Дракон", "Змея", "Лошадь", "Коза", "Обезьяна", "Петух", "Собака", "Кабан" };

                    int a;
                    int sign = 0;
                    if (Convert.ToInt32(u.year) >= 1900)
                    {
                        a = 1899;
                        while (a < Convert.ToInt32(u.year))
                        {
                            for (int j = 0; j < 12 && a < Convert.ToInt32(u.year); j++)
                            {
                                a++;
                                sign = j;
                            }
                        }
                    }
                    else if (Convert.ToInt32(u.year) < 1900)
                    {
                        a = 1900;
                        while (a > Convert.ToInt32(u.year))
                        {
                            for (int j = 11; j >= 0 && a > Convert.ToInt32(u.year); j--)
                            {
                                a--;
                                sign = j;
                            }
                        }
                    }
                    switch(sign)
                    {
                        case 0:
                            u.signEast = "Крыса";
                            break;
                        case 1:
                            u.signEast = "Бык";
                            break;
                        case 2:
                            u.signEast = "Тигр";
                            break;
                        case 3:
                            u.signEast = "Кролик";
                            break;
                        case 4:
                            u.signEast = "Дракон";
                            break;
                        case 5:
                            u.signEast = "Змея";
                            break;
                        case 6:
                            u.signEast = "Лошадь";
                            break;
                        case 7:
                            u.signEast = "Коза";
                            break;
                        case 8:
                            u.signEast = "Обезьяна";
                            break;
                        case 9:
                            u.signEast = "Петух";
                            break;
                        case 10:
                            u.signEast = "Собака";
                            break;
                        case 11:
                            u.signEast = "Кабан";
                            break;
                    }
                }
                L[i] = u;
            }
        }

        static void Main(string[] args)
        {
            List<Users> users = new List<Users>();
            string currentPathForRead = Environment.CurrentDirectory;
            currentPathForRead = currentPathForRead.Replace("bin\\Debug\\net6.0", "horoscopeEastern.csv");
            getData(currentPathForRead, users);
            checkSigns(users);
            printData(users);
            Console.WriteLine();
            currentPathForRead = currentPathForRead.Replace("horoscopeEastern.csv", "usersSigns.csv");
            createNewFile(currentPathForRead, users);
        }



    }

}



