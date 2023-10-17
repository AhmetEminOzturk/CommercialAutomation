namespace MvcOnlineCommercialAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_employee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EmployeeAbout", c => c.String(maxLength: 300, unicode: false));
            AddColumn("dbo.Employees", "EmployeeAdress", c => c.String(maxLength: 300, unicode: false));
            AddColumn("dbo.Employees", "EmployeePhone", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "EmployeePhone");
            DropColumn("dbo.Employees", "EmployeeAdress");
            DropColumn("dbo.Employees", "EmployeeAbout");
        }
    }
}
