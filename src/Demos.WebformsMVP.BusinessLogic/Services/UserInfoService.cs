using Demos.WebformsMVP.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


/// <summary>
/// INTERFACE
/// </summary>
namespace Demos.WebformsMVP.BusinessLogic.Interfaces
{
    public interface IUserInfoService
    {
        IUserInfo CreateUser(IUserInfo userinfo);
        IUserInfo UpdateUser(string existingUsername, IUserInfo newUserinfo);
        IUserInfo GetByUsername(string username);
        IList<IUserInfo> GetByDepartment(string department);
        IList<IUserInfo> GetByTeam(string teamname);
        IList<IUserInfo> GetAllUsers(bool includeAdmins);
        IList<IUserInfo> GetAdminUsers();


        IList<string> GetAllTeamNames();
    }
}


/// <summary>
/// IMPLEMENTATION
/// </summary>
namespace Demos.WebformsMVP.BusinessLogic.Services
{
    public class UserInfoService : IUserInfoService
    {
        private DataAccess.Repositories.IUserProfileRepository _repo = null; 
        
        public UserInfoService(DataAccess.Repositories.IUserProfileRepository userProfileRepo)
        {
            _repo = userProfileRepo ?? throw new ArgumentNullException(nameof(userProfileRepo));
        }

        private UserInfoService() { }

        public IList<IUserInfo> GetByDepartment(string department)
        {
            var hits = _repo.GetByDepartment(department);
            if (hits != null)
                return Translator.TranslateToBusinessObject(hits);
            else
                return new List<IUserInfo>();
        }

        public IList<IUserInfo> GetByTeam(string teamname)
        {
            var hits = _repo.GetByTeamname(teamname);
            if (hits != null)
                return Translator.TranslateToBusinessObject(hits);
            else
                return new List<IUserInfo>();
        }

        public IUserInfo GetByUsername(string username)
        {
            var hit = _repo.GetUserByUsername(username);
            if (hit != null)
                return Translator.TranslateToBusinessObject(hit);
            else
                return Factory.CreateUserInfo();
        }

        public IUserInfo CreateUser(IUserInfo userinfo)
        {
            //Check first if user already exist
            IUserInfo tmpUser = GetByUsername(userinfo.UserName);
            if (tmpUser.UserName.Length > 0)
            {
                throw new Exception("A user profile with that username already exists!");
            }
            else
            {
                int key = _repo.CreateUser(Translator.TranslateToDatabaseObject(userinfo));
                return Translator.TranslateToBusinessObject(_repo.GetByKey(key));
            }
        }

        public IUserInfo UpdateUser(string existingUsername, IUserInfo newUserinfo)
        {
            _repo.UpdateUser(existingUsername, Translator.TranslateToDatabaseObject(newUserinfo));
            return Translator.TranslateToBusinessObject(_repo.GetUserByUsername(newUserinfo.UserName));
        }

        public IList<string> GetAllTeamNames()
        {
            //sort ascending
            return _repo.GetRegistredTeamNames().OrderBy(s => s.First()).ToList();
        }

        public IList<IUserInfo> GetAllUsers(bool includeAdmins)
        {
            var users = _repo.GetAllRegularUsers();
            if (includeAdmins)
            {
                var admins = _repo.GetAdminUsers();
                foreach (var admin in admins)
                {
                    users.Add(admin);
                }
            }
            return Translator.TranslateToBusinessObject(users.OrderBy(u => u.Name).ToList());
        }

        public IList<IUserInfo> GetAdminUsers()
        {
            var admins = _repo.GetAdminUsers();
            return Translator.TranslateToBusinessObject(admins.OrderBy(u => u.Name).ToList());
        }
    }
}
