using System.Collections.Generic;

namespace SelectExpressionBuilder.Core.Console
{
    public class Person
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public PersonName PName { get; set; }

        public List<PersonName> PNames { get; set; }

        public static List<Person> GetPeople()
        {
            List<Person> people = new List<Person>()
            {
                new Person()
                {
                    Id=1000,
                    Gender = "Male",
                    PName = new PersonName()
                    {
                        Id=1, Name = "Razali"
                    },
                    PNames = new List<PersonName>()
                    {
                        new PersonName()
                        {
                            Id=2, Name = "Razali2"
                        },
                        new PersonName()
                        {
                            Id=3, Name = "Razali3"
                        },
                    }
                },

                new Person()
                {

                    Id=2000,
                    Gender = "Female",
                    PName = new PersonName()
                    {
                        Id=1, Name = "Zana"
                    },
                    PNames = new List<PersonName>()
                    {
                        new PersonName()
                        {
                            Id=2, Name = "Zana2"
                        },
                        new PersonName()
                        {
                            Id=3, Name = "Zana3"
                        },
                    }
                }
            };

            return people;
        }
    }

    public class PersonName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
