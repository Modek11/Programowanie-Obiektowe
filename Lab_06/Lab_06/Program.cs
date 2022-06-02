using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Lab_06
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      //string name, string role, int age, int[] marks, DateTime createdAt, DateTime removedAt
      List<User> userList = new List<User>();
      
      userList.Add(new User("Eustachy Sobczak","STUDENT",20,new int[] {2,5,4,4},"22-04-2022",null));
      userList.Add(new User("Martin Pawlak", "ADMIN", 43,null,"01-01-1990","01-01-2001"));
      userList.Add(new User("Norbert Szulc","MODERATOR",15,null,"21/02/2017",null));
      userList.Add(new User("Józef Duda","TEACHER",56,null,"20/10/2017","01/12/2020"));
      userList.Add(new User("Eugeniusz Wiśniewski","STUDENT",19,new int[]{2,6,4,3},"06/08/2018",null));
      userList.Add(new User("Kryspin Stępień","STUDENT",18,new int[]{3,5,5},"30/08/2017","02/12/2021"));
      userList.Add(new User("Lucjan Kowalczyk","TEACHER",36,null,"30/06/2017","07/05/2020"));
      userList.Add(new User("Adrian Górski","STUDENT",20,new int[]{5,5,5,4},"29/05/2017","08/09/2021"));
      userList.Add(new User("Igor Szulc","ADMIN",43,null,"06/08/2018",null));
      userList.Add(new User("Arkadiusz Przybylski","STUDENT",18,new int[]{3,6,4},"13/06/2019","08/12/2022"));
      userList.Add(new User("Kazimierz Szczepański","STUDENT",16,new int[]{5,3,2,1},"27/11/2017","29/06/2022"));
      userList.Add(new User("Ernest Baran","TEACHER",33,null,"26/01/2018","18/02/2021"));
      userList.Add(new User("Rafał Malinowski","STUDENT",22,new int[]{6,3,4},"30/05/2017","28/10/2021"));
      userList.Add(new User("Olgierd Sikora","STUDENT",17,new int[]{3,5,4,4},"26/01/2018","15/11/2022"));
      userList.Add(new User("Emil Bąk","TEACHER",52,null,"03/07/2017","30/09/2019"));
      userList.Add(new User("Cezary Szczepański","STUDENT",13,new int[]{2,1},"18/12/2017","28/10/2021"));
      userList.Add(new User("Mieszko Duda","TEACHER",49,null,"22/10/2018","13/08/2021"));
      userList.Add(new User("Julian Pietrzak","MODERATOR",31,null,"15/03/2018","02/12/2021"));
      userList.Add(new User("Hubert Andrzejewski","STUDENT",20,new int[]{4,3},"22/10/2018","12/07/2022"));
      userList.Add(new User("Gniewomir Przybylski","STUDENT",21,new int[]{6,2,5,5,3},"22/10/2018","02/12/2021"));

      var query1 = (
        from user in userList
        select user
      ).Count();

      var query2 = (
        from user in userList
        select user.Name
      );

      var query3 = (
        from user in userList
        orderby user.Name ascending
        select user.Name
      );

      var query4 = (
        from user in userList
        group user by user.Role into userGrouped
        select userGrouped.OrderBy(x => x.Role).First()
      ); 
      
      var query5 = (
        from user in userList
        orderby user.Role
          select new {user.Name,user.Role}
      ); 
      
      var query6 = (
        from user in userList
        where user.Marks != null && user.Marks.Length > 0
          select user.Marks
          ).Count();

      var query7 = (
        from user in userList
        select new 
        {
          Count = (from user2 in userList where user2.Marks != null select user2.Marks).Count(),
          Sum = (from user2 in userList where user2.Marks != null select user2.Marks.Sum()).Sum(),
          Average = (from user2 in userList where user2.Marks != null select user2.Marks.Average()).Average()
        }
      ).First();
      
      var query8 = (
        from user in userList
        where user.Marks != null && user.Marks.Length > 0
        select user.Marks.Max()

      ).Max();
      
      var query9 = (
        from user in userList
        where user.Marks != null && user.Marks.Length > 0
        select user.Marks.Min()

      ).Min();

      var query10 = (
        from user in userList
        where user.Marks != null
        orderby user.Marks.Average() descending 
        select user
      ).First();

      int najmniej = int.MaxValue;
      var query11 = (
        from user in userList
        where user.Marks != null && user.Marks.Count() <= najmniej
        orderby user.Marks.Count() ascending
        select user
      );
      
      int najwiecej = int.MinValue;
      var query12 = (
        from user in userList
        where user.Marks != null && user.Marks.Count() >= najwiecej
        orderby user.Marks.Count() descending 
        select user
      );

      var query13 = (
        from user in userList
        where user.Marks != null
        select new
        {
          Name = user.Name,
          Average = user.Marks.Average()
        }
      );

      var query14 = (
        from user in userList
        where user.Role == "STUDENT"
        orderby user.Marks.Average() descending
        select new
        {
          Name = user.Name,
          Average = user.Marks.Average()
        }
      );

      var query15 = (
        from user in userList
        select new
        {
          Average = (from user2 in userList where user.Role == "STUDENT" select user.Marks.Average()).Average()
        }
      ).First();

      var query16 = (
        from user in userList
        orderby user.CreatedAt
        select new
        {
          Name = user.Name,
          CreateDate = user.CreatedAt
        }
      );

      var query17 = (
        from user in userList
        where user.RemovedAt == default(DateTime)
        select user.Name
      );
      
      var query18 = (
        from user in userList
        where user.Role == "STUDENT"
        orderby user.CreatedAt descending 
        select new
        {
          User = (user.Name)
        }
      ).First();




      Console.WriteLine("Query1:");
      Console.WriteLine($"{query1}"); Console.WriteLine();
      
      Console.WriteLine("Query2:");
      foreach (string x in query2) Console.Write($"{x}, "); Console.WriteLine();
      
      Console.WriteLine("Query3:");
      foreach (string x in query3) Console.Write($"{x}, "); Console.WriteLine();
      
      Console.WriteLine("Query4:");
      foreach (var x in query4) Console.Write($"{x.Role}, "); Console.WriteLine(); 
      
      Console.WriteLine("Query5:");
      foreach (var x in query5) Console.WriteLine($"{x}, "); Console.WriteLine();
      
      Console.WriteLine("Query6:");
      Console.WriteLine($"{query6}, "); Console.WriteLine();
      
      Console.WriteLine("Query7:");
      Console.WriteLine($"{query7}, "); Console.WriteLine();
      
      Console.WriteLine("Query8:");
      Console.WriteLine($"Best mark: {query8}"); Console.WriteLine();
      
      Console.WriteLine("Query9:");
      Console.WriteLine($"Worst mark: {query9}"); Console.WriteLine();
      
      Console.WriteLine("Query10:");
      query10.Info(); Console.WriteLine();
      
      Console.WriteLine("Query11:");
      foreach (var x in query11)
      {
        if (x.Marks.Count() <= najmniej)
        {
          najmniej = x.Marks.Count();
          x.Info();
        }
      } Console.WriteLine();
      
      Console.WriteLine("Query12:");
      foreach (var x in query12)
      {
        if (x.Marks.Count() >= najwiecej)
        {
          najwiecej = x.Marks.Count();
          x.Info();
        }
      } Console.WriteLine();
      
      Console.WriteLine("Query13:");
      foreach(var x in query13) Console.WriteLine($"{x}, "); Console.WriteLine();
      
      Console.WriteLine("Query14:");
      foreach(var x in query14) Console.WriteLine($"{x}, "); Console.WriteLine();
      
      Console.WriteLine("Query15:");
      Console.WriteLine($"{query15}, "); Console.WriteLine();
      
      Console.WriteLine("Query16:");
      foreach(var x in query16) Console.WriteLine($"{x}, "); Console.WriteLine();
      
      Console.WriteLine("Query17:");
      foreach(var x in query17) Console.WriteLine($"{x}, "); Console.WriteLine();
      
      Console.WriteLine("Query18:");
      Console.WriteLine(query18);







    }
  }
  
  public class User
  {
    public string Name { get; set; }
    public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT
    public int Age { get; set; }
    public int[] Marks { get; set; } // zawsze null gdy ADMIN, MODERATOR lub TEACHER
    public DateTime? CreatedAt { get; set; }
    public DateTime? RemovedAt { get; set; }

    public User(string name, string role, int age, int[] marks, string createdAt, string removedAt)
    {
      this.Name = name;
      this.Role = role;
      this.Age = age;
      this.Marks = role == "STUDENT" ? marks : null;
      this.CreatedAt = DateTime.Parse(createdAt);
      this.RemovedAt = removedAt != null ? DateTime.Parse(removedAt) : new DateTime();
    }

    public void Info()
    {
      Console.WriteLine($"Name: {this.Name}");
      Console.WriteLine($"Role: {this.Role}");
      Console.WriteLine($"Age: {this.Age}");
      Console.Write($"Marks: ");
      if(this.Marks != null) foreach (int x in this.Marks) Console.Write(x+" ");
      Console.WriteLine();
      Console.WriteLine($"CreatedAt: {this.CreatedAt}");
      Console.WriteLine($"RemovedAt: {this.RemovedAt}");
    }
  }
  
}