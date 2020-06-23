using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person
{
    class Person
    {
        private string firstName;
        private string lastName;
        private System.DateTime data;

        public Person()
        {
            firstName = "";
            lastName = "";
            data = System.DateTime.Now;
        }

        public Person(string fname, string lname, System.DateTime data)
        {
            firstName = fname;
            lastName = lname;
            this.data = data;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public System.DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        public int ChangeYear
        {
            get { return Data.Year; }
            set { Data = new DateTime(value, Data.Month, Data.Day); }
        }

        public override string ToString()
        {
            return $"First Name {firstName } \nlast name {lastName}\nData{data}";
        }

        public string ToShortString()
        {
            return "First Name:" + firstName + "\nlast name" + lastName;
        }


    }

    enum Frequency
    {
        Weekly,
        Monthly,
        Yearly
    }

    class Article
    {
        private Person persona;
        private string stateName;
        private double rate;

        public Person Persona
        {
            get { return persona; }
            set { persona = value; }
        }

        public string StateName
        {
            get { return stateName; }
            set { stateName = value; }
        }

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public Article()
        {
            rate = 0;
            stateName = "";
            persona = new Person();
        }

        public Article(Person person, string stateName, double rate)
        {
            this.persona = person;
            this.stateName = stateName;
            this.rate = rate;
        }

        public override string ToString()
        {
            return $"{Persona} {StateName} {Rate}";
        }
    }

    class Magazine
    {
        private string magName;
        private Frequency freq;
        private DateTime date;
        private int turaz;
        private Article art;
        private List<double> rates = new List<double>();
        private List<Article> ar = new List<Article>();

        public Magazine()
        {
            magName = "";
            freq = new Frequency();
            turaz = 0;
            art = new Article();
        }

        public Magazine(string magName, Frequency frequency, DateTime date, int turaz, Article article)
        {
            this.magName = magName;
            this.freq = frequency;
            this.date = date;
            this.turaz = turaz;
            this.art = article;
            rates.Add(art.Rate);
        }

        public string MagName
        {
            get { return MagName; }
            set { magName = value; }
        }

        public Frequency Freq
        {
            get { return freq; }
            set { freq = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Turaz
        {
            get { return turaz; }
            set { turaz = value; }
        }

        public Article Art
        {
            get { return art; }
            set { art = value; }
        }


        public double MiddleRate
        {
            get
            {
                int count = 0;
                double sum = 0;
                foreach (double i in rates)
                {
                    sum += i;
                    count++;
                }
                return sum / count;
            }
        }


        public void AddArticles(params Article[] artc)
        {
            ar.AddRange(artc);
            foreach (Article _art in ar)
            {
                rates.Add(_art.Rate);
            }
        }


        public void toString()
        {
            Console.Write("{0} {1} {2} {3} {4}", magName, freq, date, turaz, art);
            for (int i = 0; i < ar.Count; i++)
            {
                Console.Write(ar[i].StateName + " ");
            }
            Console.WriteLine();

        }

        public virtual string ToShortString()
        {
            return $"{magName} {freq} {date} {turaz} {art.StateName} {this.MiddleRate}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Nikol", "Kuzina", new DateTime(2020, 08, 6));
            Article article = new Article(person, "About Animal", 65.6);
            Magazine magazine = new Magazine("Sadovod", Frequency.Monthly, new DateTime(1904, 5, 6), 100, article);

            magazine.AddArticles(new Article(person, "Nikki", 70.5));
            magazine.AddArticles(new Article(person, "Rikki", 50.1));
            magazine.AddArticles(new Article(person, "Dikki", 85.6));

            magazine.toString();

            Console.WriteLine();

            Console.WriteLine(magazine.ToShortString());

            Console.ReadKey();
        }
    }
}
