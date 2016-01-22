using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    /// <exception cref="ArgumentOutOfRangeException">Grade cannot be negative number.</exception>
    public int Grade
    {
        get { return this.grade; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Grade cannot be negative number.");
            }
            this.grade = value;
        }
    }

    /// <exception cref="ArgumentOutOfRangeException">"Minimum grade cannot be a negative number.</exception>
    public int MinGrade
    {
        get { return this.minGrade; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Minimum grade cannot be a negative number.");
            }
            this.minGrade = value;
        }
    }

    /// <exception cref="ArgumentOutOfRangeException">"Maximum grade cannot be a negative number.</exception>
    public int MaxGrade
    {
        get { return this.maxGrade; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Maximum grade cannot be a negative number.");
            }
            this.maxGrade = value;
        }
    }

    /// <exception cref="ArgumentNullException">"Comments cannot be null or empty.</exception>
    public string Comments
    {
        get { return this.comments; }
        private set
        {
            if (string.IsNullOrEmpty(comments))
            {
                throw new ArgumentNullException("Comments cannot be null or empty.");
            }
            comments = value;
        }
    }
}
