namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentSystem.Data.Contracts;
    using StudentSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            SeedCourses(context);
            SeedTeachers(context);
            SeedStudents(context);
        }

        private static void SeedStudents(IStudentSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Students.Add(new Student { FirstName = "Dimo", LastName = "Petrov", Age = 30 });

            context.Students.Add(new Student { FirstName = "Plamen", LastName = "Stepanian", Age = 36 });

            context.Students.Add(new Student { FirstName = "Hristo", LastName = "Stoichev", Age = 18 });
        }

        private static void SeedTeachers(IStudentSystemDbContext context)
        {
            if (context.Teachers.Any())
            {
                return;
            }

            context.Teachers.Add(
                new Teacher { FirstName = "Evlogi", LastName = "Hristov", HireDate = new DateTime(2014, 08, 01)});

            context.Teachers.Add(
                new Teacher { FirstName = "Ivaylo", LastName = "Kenov", HireDate = new DateTime(2013, 07, 28) });

            context.Teachers.Add(
                new Teacher { FirstName = "Doncho", LastName = "Minkov", HireDate = new DateTime(2010, 04, 28) });

            context.Teachers.Add(
                new Teacher { FirstName = "Nikolay", LastName = "Kostov", HireDate = new DateTime(2008, 09, 13) });
        }

        private static void SeedCourses(IStudentSystemDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            context.Courses.Add(
                new Course
                    {
                        Name = "C# Programming Course - Part I", 
                        Description =
                            "����������� ���� \"C# ������������ - ���� I\" ��������� "
                            + "���������� � �������� �� ��������������. �������� �� ������ "
                            + "������� ������� �� �������������� ������������, ����� C#, ������� "
                            + "�� ���������� Visual Studio, ������ ����� � ��������������, ���������� "
                            + "� ������ � ���, ��������� ���������, ����������� ������, �������� �� ������"
                            + " � ������ �� ���������, ������� ����������� �� ���������� (if, if-else � "
                            + "switch-case) � �������� ������ ����� (while, do-while, for, foreach)."
                            + " ���� ����� �������� � �������� �� ������� ������ �� ������� "
                            + "�������������� ������� � �������� �� �������� �� ������ � �� "
                            + "����� �������� ��� �������� �� ��������� ��� � �� ��������� "
                            + "������ ������ �� �������� � ���������.", 
                        StartDate = new DateTime(2013, 10, 28), 
                        EndDate = new DateTime(2013, 12, 08)
                    });

            context.Courses.Add(
                new Course
                    {
                        Name = "C# Programming Course - Part II", 
                        Description =
                            "����������� ���� \"C# ������������ - ���� II\" � ����������� �� �����������"
                            + " � �������� �� ��������������. �������� �� ����� ��-������, �� ��� ��� ������,"
                            + " ��������� �� �������������� ���� ���������� �� ������ �� ��������� �� ������"
                            + " � ������� �� ��������, ��������� ����� ������ � �������, ������ � ������ "
                            + "(���������� � ���������, ���������� �� ���������), ������ ������� � �����������"
                            + " ����� ���, ������ � ������ �� ������������ ���������� �� .NET (��������� �� "
                            + "������ � ��������� �� �������� � ������), ��������� �� ������ � ������ � "
                            + "����������, ������ ��� ��������� � ��������� �� �����, ��������� �� ��������"
                            + " �� ����� � ������ � �������� �������. ������ �������� � ���� � �����������"
                            + " ����� �� ������������.", 
                        StartDate = new DateTime(2013, 10, 28), 
                        EndDate = new DateTime(2013, 12, 08)
                    });
        }
    }
}