using System;

namespace SimpleClassConlsole
{
    class Program
    {

        static void Main(string[] args)
        {
            Student[] students = new Student[0];
            Student[] studentRubbish = new Student[0];
            int menu = -1;
            string consoleRead;
            Console.WriteLine("Практична робота №3");
            Console.WriteLine("Ващенюк Арсен П-42\n\n\n");


            while(menu != 0)
            {
                Console.WriteLine("- Меню -");
                Console.WriteLine("0 - Завершити програму");
                Console.WriteLine("1 - Записати студентів");
                Console.WriteLine("2 - Вивести інформацію про студента по його порядковому номеру");
                Console.WriteLine("3 - Вивести список інформації про всіх студентів");
                Console.WriteLine("4 - Вивести список студентів з їх найліпшим та найгіршим предметом по балам");
                Console.WriteLine("5 - Відсортувати список студентів по середньому балу");
                Console.WriteLine("6 - Відсортувати список студентів по прізвищу");
                Console.WriteLine("Введіть цифру пункта меню:");
                consoleRead = Console.ReadLine();

                while (!Int32.TryParse(consoleRead, out menu))
                {
                    Console.WriteLine("Помилка. Введіть ціле число:");

                    consoleRead = Console.ReadLine();
                }

                Console.Clear();

                switch (menu)
                {
                    case 1:
                        Student[] tempStudents = new Student[0];
                        if (students.Length > 0)
                            studentRubbish = students;

                        tempStudents = ReadStudentsArray();

                        students = new Student[tempStudents.Length + studentRubbish.Length];

                        for (int value = 0; value < studentRubbish.Length; value++)
                        {
                            students[value] = studentRubbish[value];
                        }

                        int studentRubbishCount = studentRubbish.Length;

                        for (int value = 0; value < tempStudents.Length; value++)
                        {
                            students[studentRubbishCount++] = tempStudents[value];
                        }
                        break;
                    case 2:
                        if (students.Length < 1)
                            break;
                        int studentId;
                        Console.Write("\nВведіть порядковий номер студента(1-");
                        Console.Write(students.Length);
                        Console.Write("):\n");
                        consoleRead = Console.ReadLine();

                        while (!Int32.TryParse(consoleRead, out studentId))
                        {
                            Console.WriteLine("Помилка. Введіть ціле число:");

                            consoleRead = Console.ReadLine();
                        }

                        PrintStudent(students[studentId-1]);
                        break;
                    case 3:
                        PrintStudents(students);
                        break;
                    case 4:
                        if (students.Length < 1)
                            break;
                        GetStudentsInfo(students);
                        break;
                    case 5:
                        students = SortStudentsByPoints(students);
                        break;
                    case 6:
                        students = SortStudentsByName(students);
                        break;
                    default:
                        break;
                }
            }

            Console.ReadKey();
        }

        public static Student[] ReadStudentsArray()
        {
            Student[] students = new Student[0];
            Student[] tempStudents = new Student[256];
            int addMore = 1;
            int tempValue = 0;
            int studentsCount = 0;

            while (addMore != 0)
            {
                int resultsCount = 0;
                Student student = new Student();
                Result[] results;
                Result[] tempResults = new Result[256];
                string consoleRead;
                int tempInt;

                Console.WriteLine("\n\n- Заповнення студента -");
                Console.WriteLine("Введіть ім'я: ");
                student.GSName = Console.ReadLine();

                Console.WriteLine("Введіть прізвище:");
                student.GSSurname = Console.ReadLine();

                Console.WriteLine("Введіть шифр групи:");
                student.GSGroup = Console.ReadLine();

                Console.WriteLine("Введіть номер курсу:");
                consoleRead = Console.ReadLine();

                while (!Int32.TryParse(consoleRead, out tempInt))
                {
                    Console.WriteLine("Помилка. Введіть ціле число:");

                    consoleRead = Console.ReadLine();
                }

                student.GSYear = tempInt;

                int addMoreResults = 1;

                while (addMoreResults != 0)
                {
                    Result result = new Result();
                    Console.WriteLine("\n\n- Заповнення результатів студента - ");
                    Console.WriteLine("Введіть назву предмета:");
                    result.GSSubject = Console.ReadLine();

                    Console.WriteLine("Введіть назву викладача:");
                    result.GSTeacher = Console.ReadLine();

                    Console.WriteLine("Введіть кількість балів:");
                    consoleRead = Console.ReadLine();
                    while (!Int32.TryParse(consoleRead, out tempInt))
                    {
                        Console.WriteLine("Помилка. Введіть ціле число:");

                        consoleRead = Console.ReadLine();
                    }

                    result.GSPoints = tempInt;

                    tempResults[resultsCount++] = result;

                    Console.WriteLine("\nДобавити ще 1 результат? \n0 - Ні \n1 - Так");
                    consoleRead = Console.ReadLine();
                    

                    while (!Int32.TryParse(consoleRead, out tempValue))
                    {
                        Console.WriteLine("Помилка. Введіть ціле число:");

                        consoleRead = Console.ReadLine();
                    }

                    if (tempValue == 0)
                    {
                        results = new Result[resultsCount];
                        
                        for(int i = 0; i < resultsCount; i++)
                        {
                            results[i] = tempResults[i];
                        }

                        student.GSResults = results;

                        addMoreResults = 0;
                    }
                }
                
                tempStudents[studentsCount++] = student;

                Console.WriteLine("\nДобавити ще 1 студента? \n0 - Ні \n1 - Так");
                consoleRead = Console.ReadLine();
                while (!Int32.TryParse(consoleRead, out tempValue))
                {
                    Console.WriteLine("Помилка. Введіть ціле число:");

                    consoleRead = Console.ReadLine();
                }

                if (tempValue == 0)
                {
                    students = new Student[studentsCount];

                    for (int i = 0; i < studentsCount; i++)
                    {
                        students[i] = tempStudents[i];
                    }

                    addMore = 0;
                }
            }   

            return students;
        }

        public static void PrintStudent(Student student)
        {
            Console.WriteLine("\n- Інформація про студента -");
            Console.WriteLine("Ім'я: {0}", student.GSName);
            Console.WriteLine("Прізвище: {0}", student.GSSurname);
            Console.WriteLine("Група: {0}", student.GSGroup);
            Console.WriteLine("Курс: {0}", student.GSYear);
            Console.WriteLine("Результати:");
            Result[] results = student.GSResults;
            for (int value = 0; value < results.Length; value++)
            {
                Console.WriteLine("     Предмет: " + results[value].GSSubject);
                Console.WriteLine("     Вчитель: " + results[value].GSTeacher);
                Console.WriteLine("     Бали: " + results[value].GSPoints);
                Console.WriteLine();
            }
        }

        public static void PrintStudents(Student[] students)
        {
            for(int value = 0; value < students.Length; value++)
            {
                PrintStudent(students[value]);
            }
        }

        public static void GetStudentsInfo(Student[] students)
        {
            string bestSubject, worstSubject;

            Console.Clear();

            for(int value = 0; value < students.Length; value++)
            {
                int id = value + 1;

                bestSubject = students[value].GetBestSubject();
                worstSubject = students[value].GetWorstSubject();

                Console.WriteLine(id + ". " + students[value].GSName + " ", students[value].GSSurname + ":");
                Console.WriteLine("    Ліпший предмет по балам - " + bestSubject);
                Console.WriteLine("    Гірший предмет по балам - " + worstSubject);
                Console.WriteLine();
            }
        }

        public static void Swap(ref Student student1, ref Student student2)
        {
            var tempStudent = student1;
            student1 = student2;
            student2 = tempStudent;
        }

        public static Student[] SortStudentsByPoints(Student[] students)
        {
            for (int value = 1; value < students.Length; value++)
            {
                for(int value2 = 0; value2 < students.Length - value; value2++)
                {
                    if(students[value2].GetAveragePoints() > students[value2 + 1].GetAveragePoints())
                    {
                        Swap(ref students[value2], ref students[value2 + 1]);
                    }
                }
            }

            return students;
        }

        public static Student[] SortStudentsByName(Student[] students)
        {
            Student[] sortedStudents = new Student[students.Length];
            string[] studentsName = new string[students.Length];

            for(int value = 0; value < students.Length; value++)
            {
                studentsName[value] = students[value].GSName;
            }

            Array.Sort(studentsName);

            for (int value = 0; value < students.Length; value++)
            {
                for(int value2 = 0; value2 < students.Length; value2++)
                {
                    if(studentsName[value] == students[value2].GSName)
                    {
                        sortedStudents[value] = students[value2];
                    }
                }
            }

            return sortedStudents;
        }
    }
}
