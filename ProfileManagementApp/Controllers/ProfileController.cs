using ProfileManagementApp.ViewModels;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace ProfileManagementApp.Controllers
{
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepo;
        // GET: Profile

        public ProfileController(IProfileRepository profileRepo)
        {
            this._profileRepo = profileRepo;
           
        }

        public ActionResult Index(string currentFilter, string searchString,int page = 1, int pageSize = 15)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            
            var profiles = _profileRepo.GetAll().OrderByDescending(o=>o.Id).ToList();


            if (!String.IsNullOrEmpty(searchString))
            {
                profiles = profiles.Where(s => s.NRIC.ToUpper().Contains(searchString.ToUpper())
                                            || s.FirstName.ToUpper().Contains(searchString.ToUpper())
                                            || s.LastName.ToUpper().Contains(searchString.ToUpper())
                                            || s.MiddleName.ToUpper().Contains(searchString.ToUpper())
                                            ).ToList();
            }
            var viewModel = new ProfileListViewModel(profiles);

            PagedList<ProfileViewModel> model = new PagedList<ProfileViewModel>(viewModel.Profiles.ToList(), page, pageSize);
            return View(model);
        }
        


        public ActionResult Create()
        {
           
            return View(new ProfileManageViewModel());
        }

        [HttpPost]
        public ActionResult Create(ProfileManageViewModel model)
        {
            ValidateProfile(model);
            if (ModelState.IsValid)
            {
                try
                {
                    model.CurrentStatus = "New";
                    model.DateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    model.DateLastActivated = string.Empty;
                    model.DateLastDeactivated = string.Empty;
                    
                    var profile = model.ToDalEntity();
                    _profileRepo.InsertAndSubmit(profile);

                    base.SetSuccessMessage("The Profile with Name [{0}] has been created.", profile.FirstName+" "+ profile.MiddleName +" " + profile.LastName);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    base.SetErrorMessage("Whoops! Couldn't create the new Profile. The error was [{0}]", ex.Message);
                }
            }

         
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var profile = _profileRepo.GetById(id);

            if (profile == null)
            {
                base.SetErrorMessage("Profile with Id [{0}] does not exist", id.ToString());
                return RedirectToAction("Index");
            }

           
            return View(new ProfileManageViewModel(profile));
        }

        [HttpPost]
        public ActionResult Edit(ProfileManageViewModel model)
        {
            ValidateProfile(model);
            if (ModelState.IsValid)
            {
                var profile = _profileRepo.GetById(model.Id);
                if (profile == null) { throw new ArgumentException(string.Format("Profile with Id [{0}] does not exist", model.Id)); }

                try
                {
                    if(profile.CurrentStatus == "New")
                    {
                        
                        model.IsActive = null;
                        
                    }
                    else
                    {
                       
                        if(profile.CurrentStatus == "Active")
                        {
                            model.IsActive = true;
                        }
                        else
                        {
                            model.IsActive = false;
                        }
                     
                    }
                    model.CurrentStatus = profile.CurrentStatus;
                    model.DateCreated = profile.DateCreated;
                    model.DateLastActivated = profile.DateLastActivated;
                    model.DateLastDeactivated = profile.DateLastDeactivated;
                
                    model.ToDalEntity(profile);
                    _profileRepo.UpdateAndSubmit(profile);

                    base.SetSuccessMessage("The Profile with ProfileId:  [{0}]--> Name :[{1}] has been updated.", profile.Id.ToString(), profile.FirstName + " " + profile.MiddleName + " " + profile.LastName);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    base.SetErrorMessage("Whoops! Couldn't update the Profile. The error was [{0}]", ex.Message);
                }
            }

            //LoadTeamsInViewData();
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int id)
        {
            ProfileManageViewModel model = new ProfileManageViewModel();
            var profile = _profileRepo.GetById(id);
            if(profile.CurrentStatus == "Active")
            {
                model.FirstName = profile.FirstName;
                model.MiddleName = profile.MiddleName;
                model.LastName = profile.LastName;
                model.NRIC = profile.NRIC;
                model.CurrentStatus = "InActive";
                model.IsActive = false;
                model.DateCreated = profile.DateCreated;
                model.DateLastActivated = profile.DateLastActivated;
                model.DateLastDeactivated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (profile.CurrentStatus == "InActive")
            {
                model.FirstName = profile.FirstName;
                model.MiddleName = profile.MiddleName;
                model.LastName = profile.LastName;
                model.NRIC = profile.NRIC;
                model.CurrentStatus = "Active";
                model.IsActive = true;
                model.DateCreated = profile.DateCreated;
                model.DateLastActivated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                model.DateLastDeactivated = profile.DateLastDeactivated;
            }

            if (profile.CurrentStatus == "New")
            {
                model.FirstName = profile.FirstName;
                model.MiddleName = profile.MiddleName;
                model.LastName = profile.LastName;
                model.NRIC = profile.NRIC;
                model.CurrentStatus = "Active";
                model.IsActive = true;
                model.DateCreated = profile.DateCreated;
                model.DateLastActivated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                model.DateLastDeactivated = string.Empty;
            }
            model.ToDalEntity(profile);
            _profileRepo.UpdateAndSubmit(profile);

            base.SetSuccessMessage("The Profile Status of [{0}] has been updated.", profile.FirstName + " " + profile.MiddleName + " " + profile.LastName);
            return RedirectToAction("Index");
        }


        private void ValidateProfile(ProfileManageViewModel profileModel)
        {

            var entity = _profileRepo.GetAll()
                                   .Where(w => w.NRIC == profileModel.NRIC && w.Id != profileModel.Id).Any();
           
                    
            if (entity)
            {
                ModelState.AddModelError("NRIC", "Profile with NRIC already exist");
            }

        }

    }
}