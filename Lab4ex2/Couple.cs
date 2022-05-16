using System;

namespace Lab4ex2
{
    public class Couple : IComparable
    {

        private string numcouple;
        private string weekday;
        private string item;
        private string surname;
        private string form;

        public override string ToString()
        {
            return $"Номер пари: {numcouple}, День тижня: {weekday}, Предмет: {item}, Прiзвище викладача: {surname}, Форма заняття: {form}";
        }

        public int CompareTo(object? obj)
        {
            Couple other = (Couple)obj;
            return Numcouple.CompareTo(other.Numcouple);
        }


         public Couple()
        {
        }

        public Couple(string numcouple, string weekday,  string item, string surname, string form)
        {
            Numcouple = numcouple;
            Weekday = weekday;
            Item = item;
            Surname = surname;
            Form = form;
        }

        public string Numcouple
        {
            get => numcouple;
            set => numcouple = value;
        }

        public string Weekday
    {
            get => weekday;
            set => weekday = value;
        }

        public string Item
        {
            get => item;
            set => item = value;
        }

        public string Surname
    {
            get => surname;
            set => surname = value;
        }

        public string Form
    {
            get => form;
            set => form = value;
        }
    }
}
