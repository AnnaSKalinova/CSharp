using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> family;

        public Family()
        {
            this.family = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.family.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = this.family
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();
            return oldestPerson;
        }

        public List<Person> OlderThat30()
        {
            List<Person> olderThan30 = family
                .Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToList();
            return olderThan30;
        }
    }
}
