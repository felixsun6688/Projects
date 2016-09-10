using AorangiPeak.Dto.GalleryDto;
using System.Linq;

namespace AorangiPeak.Service.ServiceInterface
{
    public interface IGalleryService
    {
        void Add(NewGalleryDto dto);
        void Save(GalleryDetailDto dto);
        void Remove(GalleryDetailDto udto);

        GalleryDetailDto GetByKey(string uid);
        GalleryBriefDto GetLoginUserByName(string username);
        GalleryBriefDto GetLoginUserById(string uid);
        IQueryable<GalleryDetailDto> GetAll();
        IQueryable<GalleryBriefDto> GetBriefAll();

        bool IsExist(string username);
    }
}
