using System;

using System.Linq;

namespace EFCoreDemo
{
    public class program
    {
        static void Add()
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {   db.Database.EnsureCreated();
                PhoneBook P1 = new PhoneBook() {PhoneNumber = 0851234567, Name = "Ciaran", Address = "1 New Street"};
                PhoneBook P2 = new PhoneBook() {PhoneNumber = 0851234561, Name = "John", Address = "2 New Street"};
                PhoneBook P3 = new PhoneBook() {PhoneNumber = 0851234562, Name = "Mary", Address = "3 New Street"};
                PhoneBook P4 = new PhoneBook() {PhoneNumber = 0851234563, Name = "Tom", Address = "4 New Street"};
                PhoneBook P5 = new PhoneBook() {PhoneNumber = 0851234564, Name = "Laura", Address = "4 New Street"};

                db.PhoneBooks.Add(P1);
                db.PhoneBooks.Add(P2);
                db.PhoneBooks.Add(P3);
                db.PhoneBooks.Add(P4);
                db.PhoneBooks.Add(P5);
                db.SaveChanges();
            }

        }

        static void Update()
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {
                var phBook = db.PhoneBooks.FirstOrDefault(p => p.PhoneNumber == 0851234567);
                if (phBook != null)
                {
                    phBook.Address = "10 New Street";
                    db.SaveChanges();
                }
            }
        }

        static void Delete()
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {
                var phBook = db.PhoneBooks.FirstOrDefault(p => p.Name.ToUpper() == "john");
                if (phBook != null)
                {
                    db.PhoneBooks.Remove(phBook);
                    db.SaveChanges();
                }
            }
        }

        static void phoneBookNameOrder()
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {
                var phoneBookNameOrder = db.PhoneBooks.OrderBy(p => p.Name);

                foreach (var p in phoneBookNameOrder)
                {
                    Console.WriteLine(p);
                } 
            }
        }

        static void searchPhoneNo()
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {
                var searchPhone = db.PhoneBooks.Where(phone => phone.PhoneNumber == 0851234567)
                                            .Select(phone => new{phone.Name,phone.Address});

                foreach(var phone in searchPhone)
                {
                    Console.WriteLine(phone);
                }
            }
        }

        static void searchName()
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {
                var searchName = db.PhoneBooks.Where(n => n.Name == "Ciaran")
                                            .Select(n => new{n.PhoneNumber,n.Address});

                foreach (var n in searchName)
                {
                    Console.WriteLine(n);
                }
            }
        }


        static void Main()
        {
            //program.Add();
            program.Update();
            program.Delete();
            program.phoneBookNameOrder();
            program.searchName();
            program.searchPhoneNo();
        }

    }
}

