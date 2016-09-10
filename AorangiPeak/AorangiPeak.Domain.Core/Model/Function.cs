using AorangiPeak.Domain.Core.ComplexType;
using System;

namespace AorangiPeak.Domain.Core.Model
{
    public class Function : AggregateRootBase
    {
        public string Functionname { get; private set; }
        public string Firstimg { get; private set; }
        public string Introduction { get; private set; }
        public string Content { get; private set; }
        public FunctionStatus Status { get; private set; }

        public Function(Guid id, string name, string img1, string intro, string content, FunctionStatus status)
        {
            this.Id = id;
            this.Functionname = name;
            this.Firstimg = img1;
            this.Introduction = intro;
            this.Content = content;
            this.Status = status;
        }

        public Function(Guid id)
        {
            this.Id = id;
        }

        #region override methods
        public override bool Equals(Object obj)
        {
            bool equalObjects = false;
            if (obj != null && this.GetType() == obj.GetType())
            {
                Function function = (Function)obj;
                equalObjects = this.Id.Equals(function.Id);
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
