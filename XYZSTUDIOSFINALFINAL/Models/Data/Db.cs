using System.Data.Entity;

namespace XYZSTUDIOSFINALFINAL.Models.Data
{
    public class Db : DbContext
    {
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<RoleDTO> Roles { get; set; }
        public DbSet<UserRoleDTO> UserRoles { get; set; }
        public DbSet<PageDTO> pages { get; set; }
        //  public DbSet<ImageDTO> Images { get; set; }

    }
}