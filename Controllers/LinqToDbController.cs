using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using LinqToDBBlog.Entities;
using LinqToDBBlog.Entities.DbContexts;
using LinqToDBBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinqToDBBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinqToDbController : ControllerBase
    {
        private readonly DashboardContext _context;
        public LinqToDbController(DashboardContext context)
        {
            _context = context;
        }

        [HttpGet("GetUserList")]
        public List<CustomUserModel> Get()
        {
            var users = from user in _context.DbUser
                        join role in _context.DbSecurityRole on user.IdSecurityRole equals role.IdSecurityRole into roleLeft
                        from role in roleLeft.DefaultIfEmpty()
                        select new CustomUserModel
                        {
                            Name = user.Name,
                            LastName = user.LastName,
                            UserName = user.UserName,
                            Password = user.Password,
                            Email = user.Email,
                            Gsm = user.Gsm,
                            IsAdmin = user.IsAdmin,
                            SecurityRoleName = role.SecurityRoleName,
                            IdSecurityRole = role.IdSecurityRole,
                            IdUser = user.IdUser,
                            CreDate = user.CreDate
                        };
            return users.ToList();
        }
        [HttpGet("GetUserListFromTableName/{tableName}")]
        public List<CustomUserModel> GetFromTableName(string tableName)
        {
            var users = from user in _context.Set<DbUser>().ToLinqToDBTable().TableName(tableName)
                        join role in _context.DbSecurityRole on user.IdSecurityRole equals role.IdSecurityRole into roleLeft
                        from role in roleLeft.DefaultIfEmpty()
                        where user.Deleted != true
                        select new CustomUserModel
                        {
                            Name = user.Name,
                            LastName = user.LastName,
                            UserName = user.UserName,
                            Password = user.Password,
                            Email = user.Email,
                            Gsm = user.Gsm,
                            IsAdmin = user.IsAdmin,
                            SecurityRoleName = role.SecurityRoleName,
                            IdSecurityRole = role.IdSecurityRole,
                            IdUser = user.IdUser,
                            CreDate = user.CreDate
                        };
            return users.ToList();
        }

        [HttpGet("GetUserListFromTableNameWithExtension/{tableName}")]
        public List<CustomUserModel> GetFromTableNameWithExtension(string tableName)
        {
            var users = _context.Set<DbUser>().ToLinqToDBTable().TableName(tableName)
                        .Where(u => u.Deleted != true)
                        .GroupJoin(
                            _context.DbSecurityRole,
                            u => u.IdSecurityRole,
                            r => r.IdSecurityRole,
                            (u, roles) => new { u, roles }
                        )
                        .SelectMany(
                                    ur => ur.roles.DefaultIfEmpty(),
                                    (ur, r) => new CustomUserModel
                                    {
                                        Name = ur.u.Name,
                                        LastName = ur.u.LastName,
                                        UserName = ur.u.UserName,
                                        Password = ur.u.Password,
                                        Email = ur.u.Email,
                                        Gsm = ur.u.Gsm,
                                        IsAdmin = ur.u.IsAdmin,
                                        SecurityRoleName = r.SecurityRoleName,
                                        IdSecurityRole = r.IdSecurityRole,
                                        IdUser = ur.u.IdUser,
                                        CreDate = ur.u.CreDate
                                    }
                        );
            return users.ToList();
        }
    }
}
