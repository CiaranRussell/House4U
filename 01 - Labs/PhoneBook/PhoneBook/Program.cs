using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class programe
    {
        static void Main()
        {
            Context ctx = new Context();
            ctx.Database.EnsureCreated();
            AddSomeRecords(ctx);

            static void AddSomeRecords(Context dbx)
            {
                PhoneBookEntry entry1 = new PhoneBookEntry() { Number = "085-1234", Name = "Jim", Address = "1 New Street" };
                PhoneBookEntry entry2 = new PhoneBookEntry() { Number = "085-1235", Name = "Mary", Address = "2 New Street" };
                PhoneBookEntry entry3 = new PhoneBookEntry() { Number = "085-1236", Name = "John", Address = "3 New Street" };
                PhoneBookEntry entry4 = new PhoneBookEntry() { Number = "085-1237", Name = "Tracey", Address = "4 New Street" };
                PhoneBookEntry entry5 = new PhoneBookEntry() { Number = "085-1238", Name = "Ciaran", Address = "5 New Street" };
                dbx.Add(entry1);
                dbx.Add(entry2);
                dbx.Add(entry3);
                dbx.Add(entry4);
                dbx.Add(entry5);
                dbx.SaveChanges();
            }
        }
    }
}