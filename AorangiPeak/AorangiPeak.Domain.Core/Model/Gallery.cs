using AorangiPeak.Domain.Core.ComplexType;
using System;

namespace AorangiPeak.Domain.Core.Model
{
    public class Gallery : AggregateRootBase
    {
        public string Imagecaption { get; private set; }
        public string Originalpath { get; private set; }
        public string Thumbpath { get; private set; }
        public DateTime Publishtime { get; private set; }
        public DateTime Createtime { get; private set; }
        public string Originalsize { get; private set; }
        public string Thumbsize { get; private set; }
        public int Order { get; private set; }
        public GalleryStatus Status { get; private set; }

        public Gallery(Guid id, string caption, string orig, string thumb, DateTime pub, 
            DateTime create, string origsize, string thumbsize, int order, GalleryStatus status)
        {
            this.Id = id;
            this.Imagecaption = caption;
            this.Originalpath = orig;
            this.Thumbpath = thumb;
            this.Publishtime = pub;
            this.Createtime = create;
            this.Originalsize = origsize;
            this.Thumbsize = thumbsize;
            this.Order = order;
            this.Status = status;
        }

        public Gallery(Guid id)
        {
            this.Id = id;
        }

        #region override methods
        public override bool Equals(Object obj)
        {
            bool equalObjects = false;
            if (obj != null && this.GetType() == obj.GetType())
            {
                Gallery g = (Gallery)obj;
                equalObjects = this.Id.Equals(g.Id);
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
