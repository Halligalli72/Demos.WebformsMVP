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

        IList<UserProfile> GetByDepartment(string department);

        IList<UserProfile> GetAllRegularUsers();

        IList<UserProfile> GetAdminUsers();

        IList<string> GetRegistredTeamNames();
    }

    /// <summary>
    /// IMPLEMENTATION
    /// </summary>
    public class UserProfileRepository: IUserProfileRepository
    {
        private readonly IDbContext _dbCtx;

        /// <summary>
        /// Factory method
        /// </summary>
        /// <returns></returns>
        public static IUserProfileRepository CreateInstance(IDbContext dbCtx)
        {
            return new UserProfileRepository(dbCtx);
        }

        /// <summary>
        /// Hide default constructor by making it private
        /// </summary>
        private UserProfileRepository(IDbContext dbCtx) 
        {
            _dbCtx = dbCtx ?? throw new ArgumentNullException(nameof(dbCtx));
        }

        public UserProfile GetUserByUsername(string username)
        {
            return _dbCtx.Set<UserProfile>()
                .Where(up => up.UserName.ToLower().Equals(username.ToLower()))
                .FirstOrDefault();
        }

        public void CreateUser(UserProfile newUser)
        {
            newUser.IsAdmin = false;
            newUser.Created = newUser.Updated = DateTime.Now;
            _dbCtx.Set<UserProfile>().Add(newUser);
            _dbCtx.SaveChanges();
        }

        public void UpdateUser(string existingUsername, UserProfile updatedUser)
        {
            UserProfile hit = _dbCtx.Set<UserProfile>().Where(up => up.UserName.Equals(existingUsername)).FirstOrDefault();
            if (hit != null)
            {
                hit.UserName = updatedUser.UserName;
                hit.Name = updatedUser.Name;
                hit.Team = updatedUser.Team;
                hit.Department = updatedUser.Department;
                hit.IsPublic = updatedUser.IsPublic;
                hit.Updated = DateTime.Now;
                _dbCtx.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Could not find user with username:{existingUsername}!");
            }
        }

        public IList<UserProfile> GetByTeamname(string teamname)
        {
            return _dbCtx.Set<UserProfile>()
                .Where(up => up.Team.ToLower().Equals(teamname.ToLower()))
                .ToList();
        }
        public IList<UserProfile> GetByDepartment(string department)
        {
            return _dbCtx.Set<UserProfile>()
                .Where(up => up.Department.ToLower().Equals(department.ToLower()))
                .ToList();
        }


        public IList<string> GetRegistredTeamNames()
        {
            var result = _dbCtx.Set<UserProfile>()
                .GroupBy(up => up.Team.ToLower())
                .Select(g => g.FirstOrDefault().Team);
            return result.ToList();
        }

        public IList<UserProfile> GetAllRegularUsers()
        {
            return _dbCtx.Set<UserProfile>()
                .Where(up => up.IsAdmin.Equals(false))
                .ToList();
        }

        public IList<UserProfile> GetAdminUsers()
        {
            return _dbCtx.Set<UserProfile>()
                .Where(up => up.IsAdmin.Equals(true))
                .ToList();
        }

    }
}
