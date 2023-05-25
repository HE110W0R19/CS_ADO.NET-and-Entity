using EntityFrameworkTests.Models;
using RequestUtilitie;
using RequestUtilities;

namespace ProgramMain
{
    class Program
    {
        public static void Main(string[] args)
        {
            int? userInputNumber = null;
            Console.WriteLine("\n\n\t\t...Welcome\n");
            while (userInputNumber != 0)
            {
                Console.Clear();
                printTitleText();
                userInputNumber = Convert.ToInt16(Console.ReadLine());

                switch (userInputNumber)
                {
                    //Get Requests Case
                    case 1:
                        Console.Clear();
                        EntityGetRequests.getAllTeachers();

                        Console.WriteLine("\n\n\t\t\t...Press any button to continue");

                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();

                        EntityGetRequests.getTeachersAndSumHoursOfWeek();

                        Console.WriteLine("\n\n\t\t\t...Press any button to continue");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();

                        EntityGetRequests.getTeacherWithLessons();

                        Console.WriteLine("\n\n\t\t\t...Press any button to continue");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();

                        EntityGetRequests.getTeacherAndOverageTimeOfWeek();

                        Console.WriteLine("\n\n\t\t\t...Press any button to continue");
                        Console.ReadKey();
                        break;

                    //Insert Requests Case
                    case 5:
                        Console.Clear();

                        createTeacher();

                        Console.WriteLine("\n\n\t\t\t...Press any button to continue");
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();

                        createLesson();
                        
                        Console.WriteLine("\n\n\t\t\t...Press any button to continue");
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();

                        createTeacherAtTeaching();

                        Console.WriteLine("\n\n\t\t\t...Press any button to continue");
                        Console.ReadKey();
                        break;

                    //Default and Exit case
                    case 0:
                        return;
                    default:
                        continue;
                }
            }
        }

        public static void printTitleText()
        {
            Console.WriteLine(
                            "\n\t\t*Get Requests*\n" +
                            "\t\t- 1) Get all teachers\n" +
                            "\t\t- 2) Get all teachers and the sum of time spent teaching in week.\n" +
                            "\t\t- 3) Get teachers, subjects and time spent teaching per week.\n" +
                            "\t\t- 4) Get subject and average time spent teaching per week (every day).\n" +
                            "\n\t\t*Insert Requests*\n" +
                            "\t\t- 5) Insert Teacher.\n" +
                            "\t\t- 6) Insert Academy Subject.\n" +
                            "\t\t- 7) Add teacher and teaching time.\n" +
                            "\n\t\t- 0) Exit.");
            Console.Write("\n\n\n...Enter choise: ");
        }

        public static void createTeacher()
        {
            Console.Write($"\n...Enter First Name: ");
            string? firstName = Console.ReadLine();
            Console.Write($"\n...Enter Last Name: ");
            string? lastName = Console.ReadLine();
            Console.Write($"\n...Enter Patronymic: ");
            string? patronymic = Console.ReadLine();

            Console.Clear();

            EntityUtilities.addTeacher(firstName, lastName, patronymic);
        }

        public static void createLesson()
        {
            Console.Write($"\n...Enter Academy Subject Name: ");
            string? lessonName = Console.ReadLine();

            Console.Clear();

            EntityUtilities.addLesson(lessonName);
        }

        public static void createTeacherAtTeaching()
        {
            Console.Write($"\n...Enter First Name: ");
            string? firstName = Console.ReadLine();
            Console.Write($"\n...Enter Last Name: ");
            string? lastName = Console.ReadLine();
            Console.Write($"\n...Enter Patronymic: ");
            string? patronymic = Console.ReadLine();

            Console.Write($"\n\n...Enter academy subject name: ");
            string? subjectName = Console.ReadLine();

            Console.Write($"\n\n...Enter lesson start date and time: ");
            var startDateTime = createDateTime();
            Console.Write($"\n\n...Enter lesson end date and time: ");
            var endDateTime = createDateTime();

            Console.Clear();

            EntityUtilities.addTeacherInLesson(firstName, lastName, patronymic, subjectName, startDateTime, endDateTime);
        }

        public static DateTime createDateTime()
        {
            Console.Write($"\n...Enter year: ");
            int wear = Convert.ToInt32(Console.ReadLine());
            Console.Write($"\n...Enter month: ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.Write($"\n...Enter day: ");
            int day = Convert.ToInt32(Console.ReadLine());

            Console.Write($"\n...Enter hour: ");
            int hour = Convert.ToInt32(Console.ReadLine());
            Console.Write($"\n...Enter minutes: ");
            int minutes = Convert.ToInt32(Console.ReadLine());
            Console.Write($"\n...Enter seconds: ");
            int seconds = Convert.ToInt32(Console.ReadLine());

            return new DateTime(wear, month, day, hour, minutes, seconds);
        }
    }
}