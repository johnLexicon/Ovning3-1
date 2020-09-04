using System;

namespace Ovning3
{
    internal class Person
    {


        private int age;
        private string fName;
        private string lName;
        private double height;
        private double weight; 

        
        // Restraints on member values.
        public int Age 
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative number.");
                }
                this.age = value;
            } 
        }
        public string  FName 
        {
            get
            {
                return this.fName; 
            }
            set
            {
                if (value.Length < 2 || value.Length > 10)
                {
                    throw new ArgumentException("First name must be 2 - 10 characters.");
                }
                this.fName = value;
            } 

        }
        public string LName
        {
            get
            {
                return this.lName;
            }
            set
            {
                if (value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentException("Last name must be 3 - 15 characters.");
                }
                this.lName = value;
            }
        }
        public double Height 
        {
            get
            {
                return this.height;
            } 
            set
            {
                if (value < 20.0 || value > 300.0)
                {
                    throw new ArgumentException("Height must be 20 - 300.");
                }
                this.height = value;

            } 
        }
        public double Weight  
        { 
            get
            {
                return this.weight;
            }
            set
            {
                if (value < 20.0 || value > 300.0)
                {
                    throw new ArgumentException("Weight must be 20 - 300.");
                }
                this.weight = value;
            }
            
        }


        public Person(string fname, string lname)      // Make first and last name mandatory.
        {
            fName = fname;
            lName = lname;
        }
    
    }
}