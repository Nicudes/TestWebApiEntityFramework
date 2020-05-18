using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace PragueDbTest
{
    

   public class CustomersDataAccess
    {
        LocalConnectionDb localconn = new LocalConnectionDb();
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<Customer> Customers { get; set; }

        public CustomersDataAccess()
        {
           
            database = localconn.GetConnection();
            database.CreateTable<Customer>();
            this.Customers = new ObservableCollection<Customer>(database.Table<Customer>());

            if (!database.Table<Customer>().Any())
            {
                AddNewCustomer();
            }
        }

        public void AddNewCustomer()
        {
            this.Customers.Add(new Customer
            {
                Name = "Name...",
                LastName = "Last Name..."

            });
        }


        public IEnumerable<Customer> GetFilteredCustomers(string mainName)
        {
            lock (collisionLock)
            {
                var query = from cust in database.Table<Customer>()
                            where cust.Name == mainName
                            select cust;
                return query.AsEnumerable();
            }
        }

        public IEnumerable<Customer> GetFilteredCustomer()
        {
            lock (collisionLock)
            {
                return database.Query<Customer>
                    ("SELECT * FROM item WHERE Name = 'Andre'").AsEnumerable();
            }
        }

        public Customer GetCustomer(int id)
        {
            lock (collisionLock)
            {
                return database.Table<Customer>().FirstOrDefault();
            }
        }


        public int SaveCustomer(Customer customerInstance)
        {
            lock(collisionLock)
            {
                if (customerInstance.Id != 0)
                {
                    database.Update(customerInstance);
                    return customerInstance.Id;
                }
                else
                {
                    database.Insert(customerInstance);
                    return customerInstance.Id;
                }
            
            }
        }

        public void SaveAllCustomers()
        {
            lock(collisionLock)
            {
                foreach (var customerInstance in this.Customers)
                {
                    if (customerInstance.Id != 0)
                    {
                        database.Update(customerInstance);

                    }
                    else
                    {
                        database.Insert(customerInstance);
                    }

                }
            }
        }

        public int DeleteCustomer(Customer customerInstance)
        {
            var id = customerInstance.Id;
            if (id != 0)
            {
                lock(collisionLock)
                {
                    database.Delete<Customer>(id);
                }
            }
            this.Customers.Remove(customerInstance);
            return id;
        }

        public void DeleteAllCustomers()
        {
            lock (collisionLock)
            {
                database.DropTable<Customer>();
                database.CreateTable<Customer>();
            }
            this.Customers = null;
            this.Customers = new ObservableCollection<Customer>(database.Table<Customer>());
        }

    }
    
}
