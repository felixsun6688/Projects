using AorangiPeak.Domain.Core.ComplexType;
using System;

namespace AorangiPeak.Domain.Core.Model
{
    /// <summary>
    /// User Model
    /// </summary>
    public class User : AggregateRootBase
    {
        public string Username { get; private set; }
        public string Userpwd { get; private set; }
        public string Email { get; private set; }
        public DateTime Createtime { get; private set; }
        public Guid RoleId { get; private set; }
        public UserStatus Status { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleId"></param>
        /// <param name="username"></param>
        /// <param name="userpwd"></param>
        /// <param name="email"></param>
        public User(Guid id, Guid roleId, string username, string userpwd, 
                          string email, DateTime createtime, UserStatus status)
        {
            this.Id = id;
            this.RoleId = roleId;
            this.Username = username;
            this.Userpwd = userpwd;
            this.Email = email;
            this.Createtime = createtime;
            this.Status = status;
        }

        #region override methods
        public override bool Equals(Object obj)
        {
            bool equalObjects = false;
            if (obj != null && this.GetType() == obj.GetType())
            {
                User user = (User)obj;
                equalObjects = this.Id.Equals(user.Id);
            }

            return equalObjects;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion
    }
}
