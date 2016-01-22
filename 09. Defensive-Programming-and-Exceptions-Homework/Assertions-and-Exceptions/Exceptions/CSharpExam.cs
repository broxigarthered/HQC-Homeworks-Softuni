using System;

public class CSharpExam : Exam
{
    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    /// <exception cref="ArgumentOutOfRangeException">Score cannot be a negative number.</exception>
    public int Score
    {
        get { return this.score; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Score cannot be negative number.");
            }
            this.score = value;
        }
    }

    public override ExamResult Check()
    {
            return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}
