using AorangiPeak.Domain.Core.ComplexType;
using System;

namespace AorangiPeak.Domain.Core.Model
{
    public class Menu : AggregateRootBase
    {
        public string Menuname { get; private set; }
        public string Firstimg { get; private set; }
        public string Secondimg { get; private set; }
        public string Introduction { get; private set; }
        public string Content { get; private set; }
        public MenuStatus Status { get; private set; }

        public Menu(Guid id, string name, string img1, string img2, string intro, string content, MenuStatus status)
        {
            this.Id = id;
            this.Menuname = name;
            this.Firstimg = img1;
            this.Secondimg = img2;
            this.Introduction = intro;
            this.Content = content;
            this.Status = status;
        }

        public Menu(Guid id)
        {
            this.Id = id;
        }

        #region override methods
        public override bool Equals(Object obj)
        {
            bool equalObjects = false;
            if (obj != null && this.GetType() == obj.GetType())
            {
                Menu menu = (Menu)obj;
                equalObjects = this.Id.Equals(menu.Id);
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
