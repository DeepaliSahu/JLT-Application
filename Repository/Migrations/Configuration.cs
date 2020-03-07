namespace Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using global::Repository.DataEntity;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using global::Repository.DataContext;
    using Newtonsoft.Json.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {

            if(context.Profiles.Count() == 0) {
                GetProfiles(context);
                context.SaveChanges();
            }
          
           
        }


        private void GetProfiles(DataContext context)
        {
           
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), @"APPDATA\personProfileList.json");

            System.Uri uri = new System.Uri(Assembly.GetExecutingAssembly().CodeBase);
            string path = Path.Combine(Path.GetDirectoryName(uri.LocalPath), @"APPDATA\MOCK_PROFILE_DATA.json");
            List<Profile> profileData = JsonConvert.DeserializeObject<List<Profile>>(File.ReadAllText(path));

            foreach (Profile pdata in profileData)
            {
                context.Profiles.Add(new Profile
                {
                    
                FirstName = pdata.FirstName,
                LastName = pdata.LastName,
                MiddleName = pdata.MiddleName,
                NRIC = pdata.NRIC,
                DateCreated = pdata.DateCreated,
                DateLastActivated = pdata.DateLastActivated,
                DateLastDeactivated = pdata.DateLastDeactivated,
                CurrentStatus = pdata.CurrentStatus
            
                });

            }
        }
    }
}
