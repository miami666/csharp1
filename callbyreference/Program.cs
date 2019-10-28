using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace callbyreference
{
    public class User
    {
        public string Vorname;
        public string Nachname;
        public string vn;
       
    }

    public class Users
    {
        private User[] users = { new User { Vorname = "Roy", Nachname = "Black" },
                        new User { Vorname= "Uschi", Nachname = "Glas" }
                       };
        private User nouser= null;

        public ref User GetUserByNachname(string nachname)
        {
            for (int ctr = 0; ctr < users.Length; ctr++)
            {
                if (nachname == users[ctr].Nachname)
                    return ref users[ctr];
            }
            return ref nouser;
        }

        public void ListUsers()
        {
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Vorname}, {user.Nachname},{user.vn}");
            }
            //Console.WriteLine();
        }
        public  void VnUsers()
        {
            foreach (var user in users)
            {
                user.vn=user.Vorname.Substring(0, 1)+ user.Nachname.Substring(0, 1);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                var bc = new Users();
                bc.VnUsers();
                bc.ListUsers();
                var such = Console.ReadLine();
                ref var user = ref bc.GetUserByNachname(such);
                if (user != null)
                    Console.WriteLine(user.Nachname);
                 
                    user = new User { Vorname = "MUschi", Nachname = "Glas"  };
                bc.ListUsers();
               
                Console.ReadKey();

            }
        }
    }
}



