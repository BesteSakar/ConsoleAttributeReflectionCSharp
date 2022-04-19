using System;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            student student1 = new student()
            {
                name = "Beste",
                surname = "Sakar",
                student_number = 1234,
                age = 22
            };
            Console.WriteLine(control.check(student1));
            Console.ReadLine();
           
        }



        public class student
        {
            [zorunlu]
            public string name;
            [zorunlu]
            public string surname;
            [zorunlu]
            public int student_number;
            [zorunlu]
            public int age;
        }

        public class zorunluAttribute : Attribute
        {

        }

        public static class control
        {
            public static bool check(student std)
            {
                Type type = std.GetType();
                foreach(var item in type.GetFields())
                {
                    object[] attributes = item.GetCustomAttributes(typeof(zorunluAttribute), true);
                    if(attributes.Length != 0)
                    {
                        object value = item.GetValue(std);
                        if(value == null)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }


    }
}
