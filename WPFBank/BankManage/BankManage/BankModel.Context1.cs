﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankManage
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BankEntities : DbContext
    {
        public BankEntities()
            : base("name=BankEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AccountInfo> AccountInfo { get; set; }
        public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        public DbSet<LoginInfo> LoginInfo { get; set; }
        public DbSet<MoneyInfo> MoneyInfo { get; set; }
        public DbSet<RateInfo> RateInfo { get; set; }
        public DbSet<LoanRate> LoanRate { get; set; }
        public DbSet<Lost> Lost { get; set; }
        public DbSet<Salary> Salary { get; set; }
    }
}
