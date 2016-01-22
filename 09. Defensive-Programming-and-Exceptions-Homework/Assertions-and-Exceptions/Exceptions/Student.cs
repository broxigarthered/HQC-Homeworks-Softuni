using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams;

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    /// <exception cref="ArgumentNullException">The first name cannot be null or empty.</exception>
    public string FirstName
    {
        get { return this.firstName; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The first name cannot be null or empty.");
            }
            this.firstName = value;
        }
    }

    /// <exception cref="ArgumentNullException">The first name cannot be null or empty.</exception>
    public string LastName
    {
        get { return this.lastName; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The first name cannot be null or empty.");
            }
            this.lastName = value;
        }
    }

    /// <exception cref="ArgumentException">Exams cannot be null or empty.</exception>
    public IList<Exam> Exams
    {
        get { return this.exams; }
        private set
        {
            if (value == null || value.Count == 0)
            {
                throw new ArgumentException("Exams cannot be null or empty.");
            }
            this.exams = value;
        }
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new Exception("Wow! Error happened!!!");
        }

        if (this.Exams.Count == 0)
        {
            Console.WriteLine("The student has no exams!");
            return null;
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            // Cannot calculate average on missing exams
            throw new Exception();
        }

        if (this.Exams.Count == 0)
        {
            // No exams --> return -1;
            return -1;
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                ((double)examResults[i].Grade - examResults[i].MinGrade) /
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
