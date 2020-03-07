using Repository.DataEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Repository.DataContext
{
    public class DataContext:DbContext,IDataContext
    {
        public DataContext()
            : base("ProfileDB")
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
        public IDbSet<Profile> Profiles { get; set; }
   

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public void ExecuteCommand(string command, params object[] parameters)
        {
            base.Database.ExecuteSqlCommand(command, parameters);
        }

       
    }
}