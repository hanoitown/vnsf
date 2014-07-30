using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities
{
    public class MonthYear : IComparable
    {
        public Month Month { get; set; }
        public int Year { get; set; }

        public MonthYear()
        {

        }
        public MonthYear(Month month, int year)
        {
            Month = month;
            Year = year;
        }

        public int CompareTo(object obj)
        {
            if (((MonthYear)obj).Year > this.Year)
                return 1;
            else
                return -1;
        }
    }

    public enum Month
    {
        Jan,
        Feb,
        Mar,
        Apr,
        May,
        Jun,
        Jul,
        Aug,
        Sep,
        Oct,
        Nov,
        Dec
    }
}
