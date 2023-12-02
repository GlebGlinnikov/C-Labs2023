using System;
using System.Collections.Generic;

namespace Lab2
{
    public class MarkList
    {
        private List<Mark> list;
        public MarkList()
        {
            list = new List<Mark>();
        }
        public void add(double a, double b, double c)
        {
            Mark mark = new Mark(a, b, c);
            list.Add(mark);
        }

        public void add(double k, double b)
        {
            Mark mark = new Mark(k, b);
            list.Add(mark);
        }

        public void add(Mark m)
        {
            list.Add(m);
        }

        public void printmark(int n)
        {
            list[n-1].print();
        }

        public int getlength()
        {
            return list.Count;
        }

        public Mark GetMark(int n)
        {
            return list[n];
        }
    }
}
