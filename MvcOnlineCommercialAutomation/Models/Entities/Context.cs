using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Entities
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CurrentAccount> CurrentAccounts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SaleTransaction> SaleTransactions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ToDo> ToDoList { get; set; }
        public DbSet<ShipmentDetail> ShipmentDetails { get; set; }
        public DbSet<ShipmentTrack> ShipmentTracks { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}