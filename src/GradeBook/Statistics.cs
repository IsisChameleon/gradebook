using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class Statistics
    {
        public Statistics ()
        {
            this.Average = 0;
            this.High = double.MinValue;
            this.Low = double.MaxValue;
        }
        public Statistics(List<double> l)
        {
            this.High = l.Max();
            this.Low = l.Min();
            this.Average = l.Average();
        }

        public double High;
        public double Low;
        public double Average;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90:
                        return 'A';   
                    case var d when d >= 80:
                        return 'B';
                    case var d when d >= 70:
                        return 'C';
                    case var d when d >= 60:
                        return 'D';
                    default:
                        return 'F';

                }
            }
        }
    }
}