using AorangiPeak.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AorangiPeak.Dto.GalleryDto;

namespace AorangiPeak.Service
{
    public class GalleryService : IGalleryService
    {
        public void Add(NewGalleryDto dto)
        {
            throw new NotImplementedException();
        }

        public IQueryable<GalleryDetailDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<GalleryBriefDto> GetBriefAll()
        {
            throw new NotImplementedException();
        }

        public GalleryDetailDto GetByKey(string uid)
        {
            throw new NotImplementedException();
        }

        public GalleryBriefDto GetLoginUserById(string uid)
        {
            throw new NotImplementedException();
        }

        public GalleryBriefDto GetLoginUserByName(string username)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(string username)
        {
            throw new NotImplementedException();
        }

        public void Remove(GalleryDetailDto udto)
        {
            throw new NotImplementedException();
        }

        public void Save(GalleryDetailDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
