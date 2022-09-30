using System;

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
            Console.WriteLine("{0,-15} {1,-15} {2,-15} {3, -15} {4, -15}", day, month, year, signZodiac, signZodiac);
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
            using (StreamReader sr = new StreamReader(path))
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
            using (StreamWriter sw = new StreamWriter(path))
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

                if (u.day == "" || u.month == "" || Convert.ToInt32(u.day) <= 0 || Convert.ToInt32(u.day) > 31 || (Convert.ToInt32(u.day) > 28 && Convert.ToInt32(u.month) == 2) || Convert.ToInt32(u.month) <= 0 || Convert.ToInt32(u.month) > 12)
                {
                    u.signZodiac = "Невозможно определить!";
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
                if (u.year == "" || Convert.ToInt32(u.year) < 0 || Convert.ToInt32(u.year) > 9999)
                {
                    u.signEast = "Невозможно определить!";
                }
                else
                {
                    int year = Convert.ToInt32(birthYear.Text);
                    string[] signs = { "Крыса", "Бык", "Тигр", "Кот", "Дракон", "Змея", "Лошадь", "Коза", "Обезьяна", "Петух", "Собака", "Кабан" };
                    int a;
                    int sign = 0;
                    if (year >= 1900)
                    {
                        a = 1899;
                        while (a < year)
                        {
                            for (int i = 0; i < 12 && a < year; i++)
                            {
                                a++;
                                sign = i;
                            }
                        }
                    }
                    if (year < 1900)
                    {
                        a = 1900;
                        while (a > year)
                        {
                            for (int i = 11; i > 0 && a > year; i--)
                            {
                                a--;
                                sign = i;
                            }
                        }
                    }

                    if (sign == 0)
                    {
                        signsVost.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/rat.png"));
                        textVost.Text = "КРЫСА";
                        textVost.Foreground = Brushes.Red;

                    }
                    if (sign == 1)
                    {
                        signsVost.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/bull.png"));
                        textVost.Text = "БЫК";
                        textVost.Foreground = Brushes.Red;

                    }
                    if (sign == 2)
                    {
                        signsVost.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/tiger.png"));
                        textVost.Text = "ТИГР";
                        textVost.Foreground = Brushes.Red;

                    }
                    if (sign == 3)
                    {
                        signsVost.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/rabbit.png"));
                        textVost.Text = "КРОЛИК";
                        textVost.Foreground = Brushes.Red;

                    }
                    if (sign == 4)
                    {
                        signsVost.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/dragon.png"));
                        textVost.Text = "ДРАКОН";
                        textVost.Foreground = Brushes.Red;

                    }
                    if (sign == 5)
                    {
                        signsVost.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/snake.png"));
                        textVost.Text = "ЗМЕЯ";
                        textVost.Foreground = Brushes.Red;

                    }
                    if (sign == 6)
                    {
                        signsVost.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/horse.png"));
                        textVost.Text = "ЛОШАДЬ";
                        textVost.Foreground = Brushes.Red;

                    }
                    if (sign == 7)
                    {
                        signsVost.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/goat.png"));
                        textVost.Text = "КОЗА";
                        textVost.Foreground = Brushes.Red;

                    }
                    if (sign == 8)
                    {
                        signsVost.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/monkey.png"));
                        textVost.Text = "ОБЕЗЬЯНА";
                        textVost.Foreground = Brushes.Red;

                    }
                    if (sign == 9)
                    {
                        signsVost.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/cock.png"));
                        textVost.Text = "ПЕТУХ";
                        textVost.Foreground = Brushes.Red;

                    }
                    if (sign == 10)
                    {
                        signsVost.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/dog.png"));
                        textVost.Text = "СОБАКА";
                        textVost.Foreground = Brushes.Red;

                    }
                    if (sign == 11)
                    {
                        signsVost.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/hog.png"));
                        textVost.Text = "КАБАН";
                        textVost.Foreground = Brushes.Red;

                    }
                }
            }
                string surnameArr = u.surname;
                string nameArr = u.name;
                string midnameArr = u.midname;
                string telephoneNumberArr = u.telephoneNumber;
                u.password = $"{surnameArr[0]}{nameArr[(nameArr.Length - 1) / 2]}{midnameArr[midnameArr.Length - 1]}{telephoneNumberArr[telephoneNumberArr.Length - 1]}{telephoneNumberArr[telephoneNumberArr.Length - 2]}{telephoneNumberArr[telephoneNumberArr.Length - 3]}";
                Users newUsers = new Users() { surname = surnameArr, name = nameArr, midname = midnameArr, telephoneNumber = telephoneNumberArr, password = u.password };
                L[i] = newUsers;
            }
        }

        static void Main(string[] args)
        {
            List<Users> users = new List<Users>();

            getData("horoscopeEastern.csv", users);
            printData(users);
            createNewPassword(users);
            Console.WriteLine();
            printData(users);
            createNewFile("users1.csv", users);

        }
    }
}