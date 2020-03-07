using ProfileManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileManagementApp.Services
{
    public interface IProfileService
    {
        List<ProfileDTO> GetAllProfiles();
    }
}
