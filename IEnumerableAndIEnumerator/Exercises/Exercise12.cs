using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableAndIEnumerator.Exercises
{
    class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public void Call()
        {
            System.Console.WriteLine("Calling to {0}. Phone number is {1}", Name, Phone);
        }

        public Contact(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
    }

    class PhoneBook : IEnumerable<Contact>
    {
        public List<Contact> Contacts;

        public PhoneBook()
        {
            Contacts = new List<Contact>{
                new Contact("Andre", "435797087"),
                new Contact("Lisa", "435677087"),
                new Contact("Dine", "3457697087"),
                new Contact("Sofi", "4367697087")
            };
        }

        IEnumerator<Contact> IEnumerable<Contact>.GetEnumerator()
        {
            return Contacts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        internal class Exercise12
        {
            // static public void Main(string[] args)
            // {
            //     PhoneBook MyPhoneBook = new PhoneBook();

            //     foreach (Contact contact in MyPhoneBook)
            //     {
            //         contact.Call();
            //     }
            // }
        }
    }
}
