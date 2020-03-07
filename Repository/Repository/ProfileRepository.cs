using Repository.DataContext;
using Repository.DataEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository.Repository
{
    public class ProfileRepository:RepositoryBase<Profile>, IProfileRepository
    {
           public ProfileRepository(IDataContext dataContext) : base(dataContext) { }
    }
}