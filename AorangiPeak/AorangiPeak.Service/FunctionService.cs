using AorangiPeak.Dto.FunctionDto;
using AorangiPeak.Service.ServiceInterface;
using System;
using System.Linq;

namespace AorangiPeak.Service
{
    public class FunctionService : IFunctionService
    {

        public IQueryable<FunctionDetailDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<FunctionBriefDto> GetBriefAll()
        {
            throw new NotImplementedException();
        }

        public FunctionDetailDto GetByKey(string mid)
        {
            throw new NotImplementedException();
        }

        public void Add(NewFunctionDto dto)
        {
            throw new NotImplementedException();
        }

        public void Save(FunctionDetailDto dto)
        {
            throw new NotImplementedException();
        }

        public void Remove(FunctionDeleteDto dto)
        {
            throw new NotImplementedException();
        }

    }
}
