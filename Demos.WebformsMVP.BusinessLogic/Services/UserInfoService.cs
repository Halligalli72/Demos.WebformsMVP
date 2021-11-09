using Demos.WebformsMVP.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        private DataAccess.IUserProfileRepository _repo = null; 
        public UserInfoService()
        {
            _repo = DataAccess.UserProfileRepository.CreateInstance();
        }

        public IList<IUserInfo> GetByDepartment(string department)
        {
            throw new NotImplementedException();
        }

        public IList<IUserInfo> GetByTeam(string teamname)
        {
            throw new NotImplementedException();
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
                _repo.CreateUser(Translator.TranslateToDatabaseObject(userinfo));
                return Translator.TranslateToBusinessObject(_repo.GetUserByUsername(userinfo.UserName));
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
