using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.WebformsMVP.DataAccess
{
    /// <summary>
    /// INTERFACE
    /// </summary>
    public interface IUserProfileRepository
    {
        void CreateUser(UserProfile newUser);

        void UpdateUser(string existingUsername, UserProfile updatedUser);

        UserProfile GetUserByUsername(string username);

        IList<UserProfile> GetByTeamname(string teamname);

        IList<UserProfile> GetAllRegularUsers();

        IList<UserProfile> GetAdminUsers();

        IList<string> GetRegistredTeamNames();
    }

    /// <summary>
    /// IMPLEMENTATION
    /// </summary>
    public class UserProfileRepository: IUserProfileRepository
    {
        /// <summary>
        /// Factory method
        /// </summary>
        /// <returns></returns>
        public static IUserProfileRepository CreateInstance()
        {
            return new UserProfileRepository();
        }

        /// <summary>
        /// Hide default constructor by making it private
        /// </summary>
        private UserProfileRepository() { }

        public UserProfile GetUserByUsername(string username)
        {
            using (WebformsMVPDemoEntities demoDbContext = new WebformsMVPDemoEntities())
            {
                return demoDbContext.UserProfile.Where(up => up.UserName.ToLower().Equals(username.ToLower())).FirstOrDefault();
            }
        }

        public void CreateUser(UserProfile newUser)
        {
            using (WebformsMVPDemoEntities demoDbContext = new WebformsMVPDemoEntities())
            {
                newUser.IsAdmin = false;
                newUser.Created = newUser.Updated = DateTime.Now;
                demoDbContext.UserProfile.Add(newUser);
                demoDbContext.SaveChanges();
            }
        }

        public void UpdateUser(string existingUsername, UserProfile updatedUser)
        {
            using (WebformsMVPDemoEntities demoDbContext = new WebformsMVPDemoEntities())
            {
                UserProfile hit = demoDbContext.UserProfile.Where(up => up.UserName.Equals(existingUsername)).FirstOrDefault();
                if (hit != null)
                {
                    hit.UserName = updatedUser.UserName;
                    hit.Name = updatedUser.Name;
                    hit.Team = updatedUser.Team;
                    hit.Department = updatedUser.Department;
                    hit.IsPublic = updatedUser.IsPublic;
                    hit.Updated = DateTime.Now;
                    demoDbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("User with username '" + existingUsername + "' was not found!");
                }
            }
        }

        public IList<UserProfile> GetByTeamname(string teamname)
        {
            using (WebformsMVPDemoEntities demoDbContext = new WebformsMVPDemoEntities())
            {
                return demoDbContext.UserProfile.Where(up => up.Team.ToLower().Equals(teamname.ToLower())).ToList();
            }
        }

        public IList<string> GetRegistredTeamNames()
        {
            using (WebformsMVPDemoEntities demoDbContext = new WebformsMVPDemoEntities())
            {
                var result = demoDbContext.UserProfile.GroupBy(up => up.Team.ToLower()).Select(g => g.FirstOrDefault().Team);
                return result.ToList();
            }
        }

        public IList<UserProfile> GetAllRegularUsers()
        {
            using (WebformsMVPDemoEntities demoDbContext = new WebformsMVPDemoEntities())
            {
                return demoDbContext.UserProfile.Where(up => up.IsAdmin.Equals(false)).ToList();
            }
        }

        public IList<UserProfile> GetAdminUsers()
        {
            using (WebformsMVPDemoEntities demoDbContext = new WebformsMVPDemoEntities())
            {
                return demoDbContext.UserProfile.Where(up => up.IsAdmin.Equals(true)).ToList();
            }
        }
    }
}
