using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Ovning3
{
    class Program
    {
        static void Main(string[] args)
        {

            TestEncapsulation();
            TestAnimalPolymorphism();
            TestDogPolymorphism();
            TestUserErrorPolymorphism();



            void TestEncapsulation() // Test every method from PersonHandler
            {
                Console.WriteLine("Testing Encapsulation with PersonHandler...\n");
                try 
                {
                    PersonHandler ph = new PersonHandler();

                    Person person1 = ph.CreatePerson(30, "Dado", "Nokto", 188.00, 85.00);

                    // try making and adding person-object without CreatePerson.
                    Person person2 = new Person("Anette", "Kniberg");
                    ph.SetAge(person2, 39);
                    ph.SetHeight(person2, 165.00);
                    ph.SetWeight(person2, 70.00);
                    ph.AddPersonToList(person2);

                    // make temp person to remove
                    Person person3 = ph.CreatePerson(51, "Temp", "Tempsson", 200.00, 100.00);
                    Person person4 = ph.CreatePerson(50, "Temp2", "Tempsson2", 200.00, 100.00);
                    Person person5 = ph.CreatePerson(50, "Temp3", "Tempsson3", 200.00, 100.00);
                    Person person6 = ph.CreatePerson(50, "Temp4", "Tempsson4", 201.00, 100.00);
                    Person person7 = ph.CreatePerson(50, "Temp5", "Tempsson5", 200.00, 100.00);    // this person should not be removed
                    ph.RemovePerson("age", 51);
                    ph.RemovePerson("fname", "Temp2");
                    ph.RemovePerson("lname", "Tempsson3");
                    ph.RemovePerson("height", 201.00);
                    

                    // Print entire list of persons
                    ph.ShowPersons();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("_________________________________________________\n");

            }

            void TestAnimalPolymorphism()
            {
                Console.WriteLine("Testing Polymorphism, Inheritence and Interface with the Animal-classes...\n");
                try
                {
                    List<Animal> Animals = new List<Animal>                        
                    {
                    new Horse("Icelandic", 4, 5, 300.00, "Epona"),
                    new Dog("Sit", 4, 3, 10.0, "Fido"),
                    new Hedgehog(100000, 4, 1, 0.5, "Sonic"),
                    new Worm(false, 0, 1, 0.001, "Crawly"),
                    new WolfMan(1, 2, 38, 90.0, "Pekka"),
                    new Pelican(100.0f, 50, 2, 2, 50.0, "Flappy")
                    };

                    foreach (Animal a in Animals)
                    {

                        Console.WriteLine(a.GetType());
                        Console.WriteLine(a.Stats());                               // F: Här anropas Stats() för varje element i listan. Eftersom varje klass har sin egen definierade Stats() så skrivs olika saker ut.
                        a.DoSound();
                        if (a is IPerson person) //Tips: Kan typ-casta direkt i villkoret.
                        {
                            //IPerson person = (IPerson)a;
                            person.Talk();
                        }
                        Console.WriteLine();
                    }

                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("_________________________________________________\n");

            }
                
            void TestDogPolymorphism()
            {
                Console.WriteLine("Testing Polymorphism and Inheritence with the Dog-class...\n");

                try
                {
                    List<Dog> Dogs = new List<Dog>                                  // F: Skulle behöva ha List<Animal> här för att kunna lägga i alla typer av djur.
                    {
                        //new Horse("Icelandic", 4, 5, 300.00, "Epona"),            // F: Blir error när jag försöker lägga i en Horse eftersom typen för listan är List<Dog>. 
                    };


                    List<Animal> Animals = new List<Animal>
                {
                    new Horse("Icelandic", 4, 5, 300.00, "Epona"),
                    new Dog("Sit", 4, 3, 10.0, "Fido"),
                    new Dog("Roll", 4, 6, 20.0, "Buster"),
                    new Dog("Play Dead", 3, 1, 5.0, "Pelle"),
                    new Hedgehog(100000, 4, 1, 0.5, "Sonic"),
                    new Worm(false, 0, 1, 0.001, "Crawly"),
                    new WolfMan(1, 2, 38, 90.0, "Pekka"),
                    new Pelican(100.0f, 50, 2, 2, 50.0, "Flappy")
                };

                    foreach (Animal a in Animals)                                   // Skriv endast ut Stats om djuret är en hund.
                    {
                        if (a is Dog)
                        {
                            Console.WriteLine(a.Stats());                           // Skriv endast ut Stats om djuret är en hund.
                            //a.WagTail;                                            // F: Kommer inte åt WagTail() eftersom den är specifik för Dog-klassen. Måste först göra en ny instans och casta till Dog.

                            Dog dog = (Dog)a;
                            dog.WagTail();
                        }

                    }

                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }

                

                Console.WriteLine("_________________________________________________\n");

            }
                
            void TestUserErrorPolymorphism()
            {
                Console.WriteLine("Testing Polymorphism and Inheritence with the UserError-class...\n");

                List<UserError> errors = new List<UserError>
                {
                    new NumericInputError(),
                    new TextInputError(),
                    new RangeInputError(),
                    new NegativeNumberError(),
                    new IllegalCharError(),
                };

                foreach (UserError e in errors)
                {
                    Console.WriteLine(e.UEMessage());
                }

                Console.WriteLine("_________________________________________________\n");
            }

            /*
            
            F:  Polymorphism är viktigt att behärska eftersom det gör koden mer flexibel, underhållbar, expanderbar och lättförstådd.


            F:  Exempel på hur min kod har förbättrats av polymorphism: foreach-loopen i TestUserErrorPolymorphism() 
                skulle tex inte kunna vara så kort utan polymorphism. Samma sak med Animal.Stats() som har en base-form men alla djur lägger sedan 
                på sina unika egenskaper. Om jag beslöt mig för att alla djur skulle ha en till egenskap (tex längd) så behöver jag bara ändra det 
                på ett ställe, utan att de förlorar sina unika egenskaper.
               
             
             
            F:  Skillnad mellan Abtract Class och interface: 
            
                - Interfaces har bara deklarationer, inga implementationer av sin medlemmar. Abstract class kan ha det (som min Animal.Stats()).
                - Klasser kan ärva från flera interfaces men bara från en abstract class.
                - Alla medlemmar i interfaces är public. I abtract class kan de ha andra access modifiers.
                - Interfaces kan endast ha properties, methods, events och indexers. Abstract class kan ha alla typer av medlemmar som en concrete class har.
            */

        }
    }
}
