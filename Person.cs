using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10053116_CLDV6212_POE_Part1
{
    public class Person
    {
        private string id;
        private string name;
        private string surname;
        private Boolean vaxxed;
        private string? vaxxType;
        private DateTime vaxx_Date;
        private string clinic;

        public Person(string id, string name, string surname, bool vaxxed, string vaxxType, DateTime vaxx_Date, string clinic)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.vaxxed = vaxxed;
            this.vaxxType = vaxxType;
            this.vaxx_Date = vaxx_Date;
            this.clinic = clinic;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public bool Vaxxed { get => vaxxed; set => vaxxed = value; }
        public string VaxxType { get => vaxxType; set => vaxxType = value; }
        public DateTime Vaxx_Date { get => vaxx_Date; set => vaxx_Date = value; }
        public string Clinic { get => clinic; set => clinic = value; }
    }
}