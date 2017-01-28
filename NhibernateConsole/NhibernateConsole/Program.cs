using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using System.Reflection;
using NHibernate.Driver;

namespace NhibernateConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration configuration = new Configuration();
            
            // Another way to configuration
            // "hibernate.cfg.xml"          

            configuration.DataBaseIntegration(x => 
            {
                x.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bookstore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent =ReadWrite;MultiSubnetFailover=False";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
            });

            configuration.AddAssembly(Assembly.GetExecutingAssembly());
            ISessionFactory factory = configuration.BuildSessionFactory();
            ISession session = factory.OpenSession();

            using (session.BeginTransaction())
            {
                //Book book = new Book { Id = 2, Title = "Riddick" };
                //session.Save(book);
                //session.Transaction.Commit();

                var books = session.CreateCriteria<Book>().List<Book>();

                foreach (var book in books)
                    Console.WriteLine(book);
            }

            Console.WriteLine("\nTap to continue...");
            Console.ReadKey(true);
        }
    }
}
