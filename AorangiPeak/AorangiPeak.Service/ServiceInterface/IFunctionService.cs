using AorangiPeak.Dto.FunctionDto;
using System.Linq;

namespace AorangiPeak.Service.ServiceInterface
{
    public interface IFunctionService
    {
        void Add(NewFunctionDto dto);
        void Save(FunctionDetailDto dto);
        void Remove(FunctionDeleteDto dto);

        FunctionDetailDto GetByKey(string mid);
        IQueryable<FunctionDetailDto> GetAll();
        IQueryable<FunctionBriefDto> GetBriefAll();
    }
}
