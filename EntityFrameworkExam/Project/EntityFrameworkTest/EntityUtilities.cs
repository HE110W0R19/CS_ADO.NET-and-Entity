using EntityFrameworkTests.Models;

namespace RequestUtilities
{
    internal static class EntityUtilities
    {
        public static void addTeacher(string firstName, string lastName, string patronymic)
        {
            using (EntityTestDbContext EntityData = new EntityTestDbContext())
            {
                var newTeacher = new Teacher();
                newTeacher.FirstName = firstName;
                newTeacher.LastName = lastName;
                newTeacher.Patronymic = patronymic;

                EntityData.Teachers.Add(newTeacher);
                EntityData.SaveChanges();

                Console.WriteLine($"...New\n" +
                    $"Teacher: {newTeacher.FirstName} " +
                    $"{newTeacher.LastName} " +
                    $"{newTeacher.Patronymic}\n" +
                    $"...Added!");
            }
        }

        public static void addLesson(string lessonName)
        {
            using (EntityTestDbContext EntityData = new EntityTestDbContext())
            {
                var newLesson = new AcademySubject();
                newLesson.SubjectName = lessonName;

                EntityData.AcademySubjects.Add(newLesson);
                EntityData.SaveChanges();

                Console.WriteLine($"...New" +
                    $"Lesson: {newLesson.SubjectName}\n" +
                    $"...Added!");
            }
        }

        public static void addTeacherInLesson(string firstName, string lastName, string patronymic, string lessonName, DateTime startLessonTime, DateTime endLessonTime)
        {
            try
            {
                using (EntityTestDbContext EntityData = new EntityTestDbContext())
                {
                    var findTeacher = findTeacherInDataBase(firstName, lastName, patronymic);
                    var findLesson = findLessonInDataBase(lessonName);

                    if (findTeacher != null && findLesson != null)
                    {
                        var newDayliEntry = new WeekJournal();
                        newDayliEntry.JournalTeacherId = findTeacher.Id;
                        newDayliEntry.JournalAcademSubId = findLesson.Id;
                        newDayliEntry.StartLessonDt = startLessonTime;
                        newDayliEntry.EndLessonDt = endLessonTime;

                        EntityData.WeekJournals.Add(newDayliEntry);
                        EntityData.SaveChanges();

                        Console.WriteLine
                            ($"...New\n" +
                            $"Teacher: {findTeacher.FirstName} {findTeacher.Patronymic}\n" +
                            $"Lesson: {findLesson.SubjectName}\n" +
                            $"Start: {startLessonTime}\n" +
                            $"Finish: {endLessonTime}\n" +
                            $"...Added!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Teacher? findTeacherInDataBase(string firstName, string lastName, string patronymic)
        {
            using (EntityTestDbContext EntityData = new EntityTestDbContext())
            {
                var findTeacher = EntityData.Teachers.FirstOrDefault
                                        (x => x.LastName == lastName && x.FirstName == firstName && x.Patronymic == patronymic);

                if (findTeacher != null)
                {
                    return findTeacher;
                }
                else
                {
                    return null;
                }
            }
        }

        public static AcademySubject? findLessonInDataBase(string lessonName)
        {
            using (EntityTestDbContext EntityData = new EntityTestDbContext())
            {
                var findLesson = EntityData.AcademySubjects.FirstOrDefault
                                        (x => x.SubjectName == lessonName);

                if (findLesson != null)
                {
                    return findLesson;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
