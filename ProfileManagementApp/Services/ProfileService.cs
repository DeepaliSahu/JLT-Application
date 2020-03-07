
using ProfileManagementApp.Models;
using ProfileManagementDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProfileManagementApp.Services
{
    public class ProfileService:IProfileService
    {
        public readonly IProfileRepository _profileRepository;
        public ProfileService(IProfileRepository profileRepository)
        {
            this._profileRepository = profileRepository;

        }


        public List<ProfileDTO> GetAllProfiles()
        {
            List<ProfileDTO> profileList = new List<ProfileDTO>();
            var profiles = _profileRepository.GetAll().OrderBy(p => p.FirstName);
            foreach(var profile in profiles)
            {
                ProfileDTO pdto = new ProfileDTO();
                pdto.FirstName = profile.FirstName;
                pdto.LastName = profile.LastName;
                pdto.MiddleName = profile.MiddleName;
                pdto.NRIC = profile.NRIC;
                pdto.DateCreated = profile.DateCreated;
                pdto.DateLastActivated = profile.DateLastActivated;
                pdto.DateLastDeactivated = profile.DateLastDeactivated;
                pdto.CurrentStatus = profile.CurrentStatus;
                profileList.Add(pdto);
            }
            return profileList;
        }
    }
}