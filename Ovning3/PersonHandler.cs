using System;
using System.Collections.Generic;
using System.Text;

namespace Ovning3
{
    internal class PersonHandler
    {

        private List<Person> personlist;

        public PersonHandler()                                                  // Want to be able to iterate over all added persons.
        {
            personlist = new List<Person>();
        }

        public void SetAge(Person pers, int age)
        {
            pers.Age = age;
        }

        public void SetFName(Person pers, string fname)
        {
            pers.FName = fname;
        }

        public void SetLName(Person pers, string lname)
        {
            pers.LName = lname;
        }

        public void SetHeight(Person pers, double height)
        {
            pers.Height = height;
        }

        public void SetWeight(Person pers, double weight)
        {
            pers.Weight = weight;
        }

        public Person CreatePerson(int age, string fname, string lname, double height, double weight)
        {

            Person person = new Person(fname, lname);   // Because the Person consructor requires this.
            person.Age = age;
            person.Height = height;
            person.Weight = weight;
            AddPersonToList(person);
            return person;

        }

        public void AddPersonToList(Person p)                                   // Made this separate incase user doesn't want to use CreatePerson.
        {
            personlist.Add(p);
        }

        public void ShowPersons()                                               // Print all info about every person.
        {
            foreach (Person p in personlist)
            {
                Console.WriteLine($"{p.FName} {p.LName} is {p.Age} years old. {p.FName} is {p.Height} cm and weighs {p.Weight} kg.");
            }
            
        }


        public void RemovePerson(string attribute, object arg)                  // User choses attribute and value, removes all persons with those values.
        {
            if (attribute == "age")
            {
                personlist.RemoveAll(person => person.Age == (int)arg);
            }
            if (attribute == "fname")
            {
                personlist.RemoveAll(person => person.FName == (string)arg);
            }
            if (attribute == "lname")
            {
                personlist.RemoveAll(person => person.LName == (string)arg);
            }
            if (attribute == "height")
            {
                personlist.RemoveAll(person => person.Height == (double)arg);
            }
            if (attribute == "weight")
            {
                personlist.RemoveAll(person => person.Weight == (double)arg);
            }

        }


    }
}
