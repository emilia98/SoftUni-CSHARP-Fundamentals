using System;

namespace _03.Mankind
{
    public class StartUp
    {
        static void Main()
        {
            var studentTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var workerTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string student_firstName = studentTokens[0];
            string student_lastName = studentTokens[1];
            string student_facultyNumber = studentTokens[2];

            string worker_firstName = workerTokens[0];
            string worker_lastName = workerTokens[1];
            decimal weekSalary = decimal.Parse(workerTokens[2]);
            double workingHours = double.Parse(workerTokens[3]);

            try
            {
                Student student = new Student(student_firstName, student_lastName, student_facultyNumber);
                Worker worker = new Worker(worker_firstName, worker_lastName, weekSalary, workingHours);  
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        static bool PrintStudent(string[] tokens)
        {
            string firstName = tokens[0];
            string lastName = tokens[1];
            string facultyNumber = tokens[2];

            try
            {
                Student student = new Student(firstName, lastName, facultyNumber);
                Console.WriteLine(student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        static bool PrintWorker(string[] tokens)
        {
            string firstName = tokens[0];
            string lastName = tokens[1];
            decimal weekSalary = decimal.Parse(tokens[2]);
            double workingHours = double.Parse(tokens[3]);

            try
            {
                Worker worker = new Worker(firstName, lastName, weekSalary, workingHours);
                Console.WriteLine(worker);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }
}
