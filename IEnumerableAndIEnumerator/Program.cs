using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumerableAndIEnumerator
{
    // 1. IEnumerable <T> for generic collections
    // 1. IEnumerable for non generic collections

    /// <summary>
    /// IEnumerable<T> contains a single method that you must implement when implementing this interface.
    /// GetEnumerator(), which returns an IEnumerator<T> object.
    /// The returned IEnumerator<T> provides the ability to iterate through the collection.
    /// By exposing a Current property that points at the object we are currently at in the collection.
    /// </summary>

    /// When it is recommended to use the IEnumerable interface:
    /// Your collection represents a massive database table.
    /// You dont't want to copy the entire thing into memory and cause performance issues in your application.
    /// When it is not recommended to use the IEnumable interace:
    /// You need the results right away and are possibly mutating / editing the objects later on.
    /// In this case, it is better to use an Array or a List.

    internal class Program
    {
        static void Main(string[] args)
        {
            DogShelter shelter = new DogShelter();

            foreach (Dog dog in shelter)
            {
                if (!dog.IsNaughtyDog)
                {
                    dog.GiveTreat(2);
                }
                else
                {
                    dog.GiveTreat(1);
                }
            }
        }
    }

    class Dog
    {
        // The name of the dog
        public string Name { get; set; }

        // Is this a naughty dog
        public bool IsNaughtyDog { get; set; }

        // Simple constructor
        public Dog(string name, bool isNaughtyDog)
        {
            this.Name = name;
            this.IsNaughtyDog = isNaughtyDog;
        }

        // This method will print, how many treat the dog received
        public void GiveTreat(int numberofTreats)
        {
            // Print a message containing the number of treats and the name of the dog
            Console.WriteLine("Dog: {0} said wuoff {1} times!", Name, numberofTreats);
        }
    }

    // A class named DogShelter this class contains a generic collection of type Dog
    // Objects of this class can't be used inside a for-each-loop because it lacks an implemntation of the IEnumerable interface
    class DogShelter : IEnumerable<Dog>
    {
        // List of type List<Dog>
        public List<Dog> dogs;

        // This constructor will initialize the dogs list with some values
        public DogShelter()
        {
            // Initialize the dogs list using the collection-initializer
            dogs = new List<Dog>()
            {
                new Dog("Casper", false),
                new Dog("Sif", true),
                new Dog("Oreo", false),
                new Dog("Pixel", false),
            };
        }

        IEnumerator<Dog> IEnumerable<Dog>.GetEnumerator()
        {
            return dogs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
