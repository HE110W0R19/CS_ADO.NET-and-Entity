using EntityFrameworkTests.Models;

namespace RequestUtilitie
{
    internal static class EntityGetRequests
    {
        //Request 1
        public static void getTeachersAndSumHoursOfWeek()
        {
            using (EntityTestDbContext DataBase = new EntityTestDbContext())
            {
                var dataBaseRequestResult = DataBase.WeekJournals
                    .GroupBy((x) => new { x.JournalTeacher.FirstName, x.JournalTeacher.Patronymic })
                    .Select((y) => new
                    {
                        Teacher = y.Key,
                        weekHoursSum = y.Sum(i =>
                    ((i.EndLessonDt.Hour - i.StartLessonDt.Hour) * 60) +
                    (i.EndLessonDt.Minute - i.StartLessonDt.Minute) +
                    ((i.EndLessonDt.Second - i.StartLessonDt.Second) / 60)
                    )
                    }).OrderBy(p => p.Teacher.FirstName);

                foreach (var item in dataBaseRequestResult)
                {
                    Console.WriteLine($"{item.Teacher.FirstName} {item.Teacher.Patronymic} - {item.weekHoursSum / 60}hour {item.weekHoursSum % 60}min");
                }
            }
        }

        //Request 2
        public static void getTeacherWithLessons()
        {
            using (EntityTestDbContext DataBase = new EntityTestDbContext())
            {
                var dataBaseRequestResult = DataBase.WeekJournals
                    .GroupBy((x) => new { x.JournalTeacher.FirstName, x.JournalTeacher.Patronymic, x.JournalAcademSub.SubjectName })
                    .Select((y) => new
                    {
                        Teacher = y.Key,
                        weekHoursSum = y.Sum(i =>
                    ((i.EndLessonDt.Hour - i.StartLessonDt.Hour) * 60) +
                    (i.EndLessonDt.Minute - i.StartLessonDt.Minute) +
                    ((i.EndLessonDt.Second - i.StartLessonDt.Second) / 60)
                    )
                    }).OrderBy(p => p.Teacher.FirstName);

                foreach (var item in dataBaseRequestResult)
                {
                    Console.WriteLine($"\nName: {item.Teacher.FirstName} {item.Teacher.Patronymic} " +
                        $"\nLesson: {item.Teacher.SubjectName} - {item.weekHoursSum / 60}hour {item.weekHoursSum % 60}min");
                }
            }
        }

        //Request 3
        public static void getTeacherAndOverageTimeOfWeek()
        {
            using (EntityTestDbContext DataBase = new EntityTestDbContext())
            {
                var dataBaseRequestResult = DataBase.WeekJournals
                    .GroupBy((x) => new { x.JournalTeacher.FirstName, x.JournalTeacher.Patronymic })
                    .Select((y) => new
                    {
                        Teacher = y.Key,
                        Subjects = y.Select(j => new Tuple<string, DateTime, DateTime>(j.JournalAcademSub.SubjectName, j.StartLessonDt, j.EndLessonDt)),
                        weekHoursSum = y.Sum(i =>
                    ((i.EndLessonDt.Hour - i.StartLessonDt.Hour) * 60) +
                    (i.EndLessonDt.Minute - i.StartLessonDt.Minute) +
                    ((i.EndLessonDt.Second - i.StartLessonDt.Second) / 60)
                    )
                    }).OrderBy(p => p.Teacher.FirstName);

                foreach (var item in dataBaseRequestResult)
                {
                    Console.WriteLine($"\nName: {item.Teacher.FirstName} {item.Teacher.Patronymic}");
                    var lessons = item.Subjects;
                    int lessontTimeMinutesSum = 0;
                    foreach (var item2 in lessons)
                    {
                        lessontTimeMinutesSum += (item2.Item3.Hour - item2.Item2.Hour)*60 + (item2.Item3.Minute - item2.Item2.Minute);
                        Console.WriteLine($"Lesson: {item2.Item1} \t Spend time:    {item2.Item2}   to  {item2.Item3}");
                    }
                    lessontTimeMinutesSum /= lessons.Count();
                    Console.WriteLine($"Average time spent per subject: {lessontTimeMinutesSum / 60} hour   {lessontTimeMinutesSum % 60} min");
                    Console.WriteLine($"Sum of time spent per week: {item.weekHoursSum / 60} hour {item.weekHoursSum % 60} min\n");
                }
            }
        }

        //My Request
        public static void getAllTeachers()
        {
            using (EntityTestDbContext EntityData = new EntityTestDbContext())
            {
                var allTeachers = EntityData.Teachers.Select(x => new { x.Id, x.FirstName, x.LastName, x.Patronymic }).ToList();

                foreach (var teacher in allTeachers)
                {
                    Console.WriteLine($"{teacher.Id}: {teacher.FirstName} {teacher.LastName} {teacher.Patronymic}");
                }
            }
        }
    }
}
