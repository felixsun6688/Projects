using AorangiPeak.Domain.Core.ComplexType;
using System;

namespace AorangiPeak.Domain.Core.Model
{
    /// <summary>
    /// Role Model
    /// </summary>
    public class Role : AggregateRootBase
    {
        public string Rolename { get; private set; }
        public RoleStatus Status { get; private set; }
        public DateTime Createtime { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rolename"></param>
        /// <param name="createtime"></param>
        /// <param name="status"></param>
        public Role(Guid id, string rolename, DateTime createtime, RoleStatus status)
        {
            this.Id = id;
            this.Rolename = rolename;
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
