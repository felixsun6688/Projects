using AorangiPeak.Dto.TableBookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AorangiPeak.Service.ServiceInterface
{
    public interface ITableBookingService
    {
        void Add(NewTableBookingDto dto);
        void Save(TableBookingDetailDto dto);
        void Remove(TableBookingDetailDto udto);
        void Remove(string id);

        TableBookingDetailDto GetByKey(string bid);
        TableBookingBriefDto GetBookingByCondition(string name);

        IQueryable<TableBookingDetailDto> GetAll();

        IQueryable<TableBookingBriefDto> GetPagedBooking<TP>(int pageIndex,
                                                           int pageSize,
                                                           out int total,
                                                           Expression<Func<TableBookingBriefDto, bool>> filter = null,
                                                           Expression<Func<TableBookingBriefDto, TP>> orderBy = null,
                                                           bool ascending = true);

        IList<TableBookingAdultsDto> GetTableBookingAdults();
        IList<TableBookingChildrenDto> GetTableBookingChildren();
        IList<TableBookingTimeDto> GetTableBookingTime();
    }
}
