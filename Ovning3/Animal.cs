using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ovning3
{

    
    abstract class Animal                                      // F: Om alla djur behöver ett nytt attribut läggs det här eftersom alla djur ärver från Animal-klassen.
    {


        public int NrOfLegs { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Name { get; set; }

        public Animal(int nrOfLegs, int age, double weight, string name) 
        {
            NrOfLegs = nrOfLegs;
            Age = age;
            Weight = weight;
            Name = name;

        }

        public abstract void DoSound();

        public virtual string Stats()
        {
            var temp = $"Number of legs: {NrOfLegs}, Age: {Age}, Weight: {Weight}, Name: {Name}, ";
            return temp;
        }



    }


    class Horse : Animal
    {
       
        public string Breed { get; set; }

        public Horse(string breed, int nrOfLegs, int age, double weight, string name) : base(nrOfLegs, age, weight, name)
        {
             Breed = breed;
        }
                    
        
        public override void DoSound()
        {
            Console.WriteLine("*neigh*");
        }

        public override string Stats()
        {
            var temp = base.Stats();
            var Stats = temp + $"Breed: {Breed}.";
            return Stats;
        }
    }


    class Dog : Animal
    {
        public string Trick { get; set; }

        public Dog(string trick, int nrOfLegs, int age, double weight, string name) : base(nrOfLegs, age, weight, name)
        {
            Trick = trick;
        }



        public override void DoSound()
        {
            Console.WriteLine("*bark*");
        }

        public void WagTail()                                       // WagTail() är min extra Dog metod.
        {
            Console.WriteLine("*wags tail*");
        }

        public override string Stats()
        {
            var temp = base.Stats();
            var Stats = temp + $"Trick: {Trick}.";
            return Stats;
        }

    }


    class Hedgehog : Animal
    {
        public int NrOfSpikes { get; set; }

        public Hedgehog(int nrOfSpikes, int nrOfLegs, int age, double weight, string name) : base(nrOfLegs, age, weight, name)
        {
            NrOfSpikes = nrOfSpikes;
        }


        public override void DoSound()
        {
            Console.WriteLine("*squeal*");
        }

        public override string Stats()
        {
            var temp = base.Stats();
            var Stats = temp + $"Number of spikes: {NrOfSpikes}.";
            return Stats;
        }

    }

    class Worm : Animal
    {
        public bool IsPoisonous { get; set; }

        public Worm(bool isPoisonous, int nrOfLegs, int age, double weight, string name) : base(nrOfLegs, age, weight, name)
        {
            IsPoisonous = isPoisonous;
        }

        public override void DoSound()
        {
            Console.WriteLine("*squirm*");
        }

        public override string Stats()
        {
            var temp = base.Stats();
            var Stats = temp + $"Is Poisonous: {IsPoisonous}.";
            return Stats;
        }
    }




    class Wolf : Animal
    {
        public int PackSize { get; set; }

        public Wolf(int packSize, int nrOfLegs, int age, double weight, string name) : base(nrOfLegs, age, weight, name)
        {
            PackSize = packSize;
        }


        public override void DoSound()
        {
            Console.WriteLine("*howl*");
        }

        public override string Stats()
        {
            var temp = base.Stats();
            var Stats = temp + $"Pack Size: {PackSize}.";
            return Stats;
        }

    }


    class WolfMan : Wolf, IPerson
    {

        public WolfMan(int packSize, int nrOfLegs, int age, double weight, string name) : base(packSize, nrOfLegs, age, weight, name)
        {
            PackSize = packSize;
        }

        public void Talk()
        {
            Console.WriteLine("Lift my curse!"); //:-)
        }

        public override string Stats()
        {
            var temp = base.Stats();
            var Stats = temp + $"Pack Size: {PackSize}.";
            return Stats;
        }
    }





    class Bird : Animal                          // F: Om samtliga fåglar behöver nya attribut bör de läggas här eftersom alla fåglar ärver av Bird-klassen.
    {
        public float WingSpan { get; set; }

        public Bird(float wingSpan, int nrOfLegs, int age, double weight, string name) : base(nrOfLegs, age, weight, name)
        {
            WingSpan = wingSpan;
        }


        public override void DoSound()
        {
            Console.WriteLine("*chirp*");
        }

        public override string Stats()
        {
            var temp = base.Stats();
            var Stats = temp + $"Wing Span: {WingSpan}.";
            return Stats;
        }

    }


    class Pelican : Bird 
    {
        public float BeakSize { get; set; }

        public Pelican(float beakSize, float wingSpan, int nrOfLegs, int age, double weight, string name) : base(wingSpan, nrOfLegs, age, weight, name)
        {
            BeakSize = beakSize;
        }

        public override string Stats()
        {
            var temp = base.Stats();
            var Stats = temp + $"Wing Span: {WingSpan}, Beak Size {BeakSize}.";
            return Stats;
        }
    }

    class Flamingo : Bird
    {
        public int FlockSize { get; set; }

        public Flamingo(int flockSize, float wingSpan, int nrOfLegs, int age, double weight, string name) : base(wingSpan, nrOfLegs, age, weight, name)
        {
            FlockSize = flockSize;
        }

        public override string Stats()
        {
            var temp = base.Stats();
            var Stats = temp + $"Wing Span: {WingSpan}, Flock Size: {FlockSize}.";
            return Stats;
        }

    }

    class Swan : Bird
    {
        public int BeautyRating { get; set; }

        public Swan(int beautyRating, float wingSpan, int nrOfLegs, int age, double weight, string name) : base(wingSpan, nrOfLegs, age, weight, name)
        {
            BeautyRating = beautyRating;
        }

        public override string Stats()
        {
            var temp = base.Stats();
            var Stats = temp + $"Wing Span: {WingSpan}, Beauty Rating: {BeautyRating}.";
            return Stats;
        }

    }



    //public string ShowProps(object obj)
    //{
    //    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
    //    {
    //        string name = descriptor.Name;
    //        object value = descriptor.GetValue(obj);
    //        Console.WriteLine("{0}={1}", name, value);
    //    }
    //}


}
