using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    //https://dirask.com/posts/WSEI-2021-2022-lato-labN-1-IS-Programowanie-obiektowe-lab-7-jMA6zj

    public static void Main()
    {
        // Hint: change `DESKTOP-123ABC\SQLEXPRESS` to your server name
        //       alternatively use `localhost` or `localhost\SQLEXPRESS`

        string connectionString = @"Data Source=DESKTOP-0IMPUT0\SQLEXPRESS;Initial Catalog=Wypozyczalnia;Integrated Security=True";

        using (WypozyczalniaContext db = new WypozyczalniaContext(connectionString))
        {
            //TODO: catch null reference exception
            //Login(db);
            //Register(db);
            UserChangePassword(db);
        }
    }

    public static void UserChangePassword(WypozyczalniaContext db)
    {
        Console.Write("Podaj E-mail: ");
        string insertedEmail = Console.ReadLine().Trim();
        Console.Write("Podaj PESEL: ");
        string insertedPesel = Console.ReadLine().Trim();
        
        foreach (var user in db.Uzytkownicy)
        {
            if(insertedEmail == user.Email)
            {
                if(insertedPesel == user.Pesel)
                {
                    //TODO
                }
                else
                {
                    //TODO
                }
            }
        }

        Console.Write("Podaj nowe hasło:");
        string newPassword = Console.ReadLine().Trim();
        Console.Write("Powtórz hasło:");
        string newPasswordRepeat = Console.ReadLine().Trim();

        if (newPassword == newPasswordRepeat)
        {
            foreach (var user in db.Uzytkownicy)
            {
                if (user.Pesel == insertedPesel)
                {
                    user.Haslo = newPassword;
                }
            }
        }
        db.SaveChanges();
        //TODO
    }
    
    public static void Login(WypozyczalniaContext db)
    {
        Console.Write("Podaj E-mail: ");
        string insertedEmail = Console.ReadLine().Trim();
        Console.Write("Podaj hasło: ");
        string insertedPassword = Console.ReadLine().Trim();

        foreach (var user in db.Uzytkownicy)
        {
            if(insertedEmail == user.Email)
            {
                if(insertedPassword == user.Haslo)
                {
                    Console.WriteLine("Zalogowano!");
                    return;
                }
                else
                {
                    Console.WriteLine("Błędne hasło");
                    return;
                }
            }
        }
        Console.WriteLine("Błędny E-mail");

    }

    public static void Register(WypozyczalniaContext db)
    {
        Console.Write("Podaj Imię: ");
        string insertedName = Console.ReadLine().Trim();
        Console.Write("Podaj Nazwisko: ");
        string insertedSurname = Console.ReadLine().Trim();
        Console.Write("Podaj E-mail: ");
        string insertedEmail = Console.ReadLine().Trim();
        Console.Write("Podaj Haslo: ");
        string insertedPassword = Console.ReadLine().Trim();
        Console.Write("Podaj PESEL: ");
        string insertedPESEL = Console.ReadLine().Trim();
        Console.Write("Podaj numer telefonu: ");
        bool parsedPhoneNumber  = Int32.TryParse(Console.ReadLine().Trim(), out int insertedPhoneNumber);
        bool parsedDrivingLicenseYears = short.TryParse(Console.ReadLine().Trim(), out short insertedDrivingLicenseYears);
        
        if (!parsedPhoneNumber || !parsedDrivingLicenseYears)
        {
            Console.WriteLine("Podano złe liczby w formularzu!");
            return;
        }

        if(insertedPhoneNumber < 100000000 || insertedPhoneNumber > 999999999)
        {
            Console.WriteLine("Podany numer telefonu jest błędny!");
            return;
        }

        foreach (var user in db.Uzytkownicy)
        {
            if(insertedEmail == user.Email)
            {
                Console.WriteLine("Podany E-mail już istnieje!");
                return;
            }
            if(insertedPESEL == user.Pesel)
            {
                Console.WriteLine("Podany PESEL już istnieje!");
                return;
            }
            if(insertedPhoneNumber == user.NrTelefonu)
            {
                Console.WriteLine("Podany numer telefonu już istnieje!");
                return;
            }
        }

        db.Add(new Uzytkownicy { Imie = insertedName, Nazwisko = insertedSurname, Pesel = insertedPESEL, NrTelefonu = insertedPhoneNumber, Email = insertedEmail, Haslo = insertedPassword, LataPrawaJazdy = insertedDrivingLicenseYears});
        db.SaveChanges();
        Console.WriteLine("Użytkownik został stworzony");
        
        
    }


    public static void TestQuery(WypozyczalniaContext db)
    {
        Console.WriteLine($"Database ConnectionString: {db.ConnectionString}.");

        // Create
        /*Console.WriteLine("Inserting a new blog");

        db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
        db.SaveChanges();*/

        // Read
        Console.WriteLine("Querying for a blog");

        var klasyPojazdow = db.Uzytkownicy
            .OrderBy(b => b.Id);

        foreach (var x in klasyPojazdow) Console.WriteLine(x.Nazwisko + ", ");


        // Update
        /*Console.WriteLine("Updating the blog and adding a post");

        blog.Url = "https://devblogs.microsoft.com/dotnet";
        blog.Posts.Add(new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
        db.SaveChanges();*/

        // Delete
        /*Console.WriteLine("Delete the blog");*/


        /*db.Remove(blog);
        db.SaveChanges();*/
    }

}