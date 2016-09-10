using AorangiPeak.Domain.Core.ComplexType;
using AorangiPeak.Domain.Core.Model;
using AorangiPeak.Domain.Core.Repository;
using AorangiPeak.Dto.TableBookingDto;
using AorangiPeak.Infrastructure.Context;
using AorangiPeak.Service.ServiceInterface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AorangiPeak.Service
{
    public class TableBookingService : ITableBookingService
    {
        #region private fields
        private IRepositoryContext _context;
        #endregion

        #region constructor
        public TableBookingService(IRepositoryContext context)
        {
            _context = context;
        }
        #endregion

        public void Add(NewTableBookingDto dto)
        {
            using (_context)
            {
                IRepository<TableBooking> tableBookingRep = _context.GetRepository<TableBooking>();
                TableBooking booking = Mapper.Map<NewTableBookingDto, TableBooking>(dto);
                tableBookingRep.Add(booking);
                _context.SaveChanges();
            }
        }

        public void Save(TableBookingDetailDto dto)
        {
            using (_context)
            {
                IRepository<TableBooking> tableBookingRep = _context.GetRepository<TableBooking>();
                TableBooking booking = Mapper.Map<TableBookingDetailDto, TableBooking>(dto);
                tableBookingRep.Save(booking);
                _context.SaveChanges();
            }
        }

        public void Remove(TableBookingDetailDto udto)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                using (_context)
                {
                    IRepository<TableBooking> tableBookingRep = _context.GetRepository<TableBooking>();
                    tableBookingRep.Remove(new TableBooking(new Guid(id)));
                    _context.SaveChanges();
                }
            }        
        }

        public IQueryable<TableBookingDetailDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public TableBookingBriefDto GetBookingByCondition(string name)
        {
            throw new NotImplementedException();
        }

        public TableBookingDetailDto GetByKey(string bid)
        {
            using (_context)
            {
                IRepository<TableBooking> tableBookingRep = _context.GetRepository<TableBooking>();
                TableBooking tb = tableBookingRep.FindBy(new Guid(bid));
                TableBookingDetailDto dto = Mapper.Map<TableBooking, TableBookingDetailDto>(tb);

                return dto;
            }
        }

        public IQueryable<TableBookingBriefDto> GetPagedBooking<TP>(int pageIndex, 
                                                                                                    int pageSize, 
                                                                                                    out int total, 
                                                                                                    Expression<Func<TableBookingBriefDto, bool>> filter = null, 
                                                                                                    Expression<Func<TableBookingBriefDto, TP>> orderBy = null, 
                                                                                                    bool ascending = true)
        {
            IList<TableBookingBriefDto> dtos = null;

            IRepository<TableBooking> rep = _context.GetRepository<TableBooking>();

            IQueryable<TableBooking> bookings = rep.FindAll();
            UpdateBookingsStatus(bookings,rep);

            dtos = Mapper.Map<IList<TableBooking>, IList<TableBookingBriefDto>>(bookings.ToList());

            if (dtos == null || dtos.Count==0)
            {
                total = 0;
                return new List<TableBookingBriefDto>().AsQueryable();
            }

            IQueryable<TableBookingBriefDto> bookingQuery = dtos.AsQueryable();

            if (filter != null)
                bookingQuery = bookingQuery.Where(filter);

            total = bookingQuery.Count();

            if (ascending)
                return bookingQuery.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return bookingQuery.OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        private void UpdateBookingsStatus(IQueryable<TableBooking> bookings, IRepository<TableBooking> rep)
        {
            using (_context)
            {
                if (bookings !=null && bookings.Count()>0)
                {
                    foreach (var item in bookings)
                    {
                        if (item.Bookingdate < DateTime.Now && item.Status== TableBookingStatus.Booked)
                        {
                            item.Status = TableBookingStatus.Expired;
                            rep.Save(item);
                            _context.SaveChanges();
                        }
                    }
                }
            }
        }

        public IList<TableBookingAdultsDto> GetTableBookingAdults()
        {
            IList<TableBookingAdultsDto> dtos = null;
            using (_context)
            {
                IRepository<TableBookingAdults> rep = _context.GetRepository<TableBookingAdults>();
                dtos = Mapper.Map<List<TableBookingAdults>, List<TableBookingAdultsDto> >(rep.FindAll().ToList());
            }

            return dtos;
        }

        public IList<TableBookingChildrenDto> GetTableBookingChildren()
        {
            IList<TableBookingChildrenDto> dtos = null;
            using (_context)
            {
                IRepository<TableBookingChildren> rep = _context.GetRepository<TableBookingChildren>();
                dtos = Mapper.Map<List<TableBookingChildren>, List<TableBookingChildrenDto>>(rep.FindAll().ToList());
            }

            return dtos;
        }

        public IList<TableBookingTimeDto> GetTableBookingTime()
        {
            IList<TableBookingTimeDto> dtos = null;
            using (_context)
            {
                IRepository<TableBookingTime> rep = _context.GetRepository<TableBookingTime>();
                dtos = Mapper.Map<List<TableBookingTime>, List<TableBookingTimeDto>>(rep.FindAll().ToList());
            }

            return dtos;
        }
    }
}
