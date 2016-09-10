using AorangiPeak.Common.Pagination;
using AorangiPeak.Domain.Core.ComplexType;
using AorangiPeak.Domain.Core.ValueObjct;
using AorangiPeak.Dto.TableBookingDto;
using AorangiPeak.Infrastructure.Context;
using AorangiPeak.Service.ServiceInterface;
using Autofac;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace AorangiPeak.Web.Areas.APManage.Models
{
    public class TableReserveViewModel
    {
        public NewTableBookingDto NewTableBookingDto { get; set; }
        public SelectList NumberOfAdultsList { get; set; }
        public SelectList NumberOfChildrenList { get; set; }
        public SelectList TimeList { get; set; }
        public SelectList StatusList { get; set; }
        public SelectList StatusSearchList { get; set; }
        public TableBookingDetailDto TableBookingDetailDto { get; set; }
        public IList<TableBookingBriefDto> TableBookingBriefDtos { get; set; }
        public IList<bool> BookingsCheckedList { get; set; }

        public int TotalOfBookings
        {
            get
            {
                return _total;
            }
        }
        private int _total;

        private ITableBookingService _tbs;

        public TableReserveViewModel()
        {
            CreateService();
            InitNumberOfAdultsList();
            InitNumberOfChildrenList();
            InitTimeList();
            InitStatusList();
            InitStatusSearchList();
            GetBookingsByPageNumber(1);
            BookingsCheckedList = new bool[_total];
        }

        public void GetBookingsByPageNumber(int pageIndex)
        {
            TableBookingBriefDtos = _tbs.GetPagedBooking(pageIndex, Pagination.AdminPagSize, out _total,
                                                                                      (x => x.Status == Enum.GetNames(typeof(TableBookingStatus))[0]), 
                                                                                      (x=> Convert.ToDateTime(x.Bookingdate)), true).ToList();
        }

        public void GetBookingsByBookingNumber(int pageIndex, string bookingNum)
        {
            TableBookingBriefDtos = _tbs.GetPagedBooking(pageIndex, Pagination.AdminPagSize, out _total, 
                                                                                     (x=>x.Bookingnumber==bookingNum), 
                                                                                     (x => Convert.ToDateTime(x.Bookingdate)), true).ToList();
        }

        public void GetBookingsByStatus(int pageIndex, int status)
        {
            if (status != -1)
            {
                TableBookingBriefDtos = _tbs.GetPagedBooking(pageIndex, Pagination.AdminPagSize, out _total, 
                                                                                         (x => x.Status == Enum.GetNames(typeof(TableBookingStatus))[status]), 
                                                                                         (x => Convert.ToDateTime(x.Bookingdate)), true).ToList();
            }
            else {
                TableBookingBriefDtos = _tbs.GetPagedBooking(pageIndex, Pagination.AdminPagSize, out _total, 
                                                                                           null, (x => Convert.ToDateTime(x.Bookingdate)), true).ToList();
            }
        }

        public void GetBookingsByAdvancedConditions(int pageIndex, 
                                                                                 DateTime beginDate,
                                                                                 DateTime endDate, 
                                                                                 string name, 
                                                                                 string email, 
                                                                                 string phoneNumber, 
                                                                                 int numOfPeople,
                                                                                 int status)
        {
            TableBookingBriefDtos = _tbs.GetPagedBooking(pageIndex, Pagination.AdminPagSize, out _total, 
                (x =>((Convert.ToDateTime(x.Bookingdate) >= beginDate)
                      && (Convert.ToDateTime(x.Bookingdate) <= endDate))
                      && (name == "" ? true : x.Firstname == name.Trim() || x.Lastname == name.Trim())
                      && (email == "" ? true : x.Email == email.Trim())
                      && (phoneNumber == "" ? true : x.Phonenumber == phoneNumber.Trim())
                      && (numOfPeople == 0 ? true : (Convert.ToInt32(x.Numberofadults) + Convert.ToInt32(x.Numberofchildren)) == numOfPeople)
                      && (status == -1 ? true : (x.Status == Enum.GetNames(typeof(TableBookingStatus))[status]))), (x => Convert.ToDateTime(x.Bookingdate)), true).ToList();
        }

        public void AddNewTableBooking(NewTableBookingDto dto)
        {
            if (dto != null)
            {
                _tbs.Add(dto);
            }
        }

        public void ModifyTableBooking(TableBookingDetailDto dto)
        {
            if (dto != null)
            {
                _tbs.Save(dto);
            }
        }

        public TableBookingDetailDto ShowBookingInfo(string bid)
        {
            return _tbs.GetByKey(bid);
        }

        public void GetCurrentBookingInfo(string bid)
        {
            TableBookingDetailDto = _tbs.GetByKey(bid);
        }

        private void InitNumberOfAdultsList()
        {
            IEnumerable adultsList = _tbs.GetTableBookingAdults();

            NumberOfAdultsList = new SelectList(adultsList, "Value", "Text");
        }

        private void InitNumberOfChildrenList()
        {
            IEnumerable childrenList = _tbs.GetTableBookingChildren();

            NumberOfChildrenList = new SelectList(childrenList, "Value", "Text");
        }

        private void InitTimeList()
        {
            IEnumerable bookingTimeList = _tbs.GetTableBookingTime();

            TimeList = new SelectList(bookingTimeList, "TimeValue", "TimeText");
        }

        private void InitStatusList()
        {
            IEnumerable statusList = GetTableBookingStatusList();

            StatusList = new SelectList(statusList, "Value", "Text");
        }

        private void InitStatusSearchList()
        {
            IList<TableReservationStatus> statusList = new List<TableReservationStatus>() { new TableReservationStatus() { Value = -1, Text = "All" } };
            StatusSearchList = new SelectList(statusList.Concat(GetTableBookingStatusList()), "Value", "Text", "0");
        }

        private IList<TableReservationStatus> GetTableBookingStatusList()
        {
            int length = Enum.GetNames(typeof(TableBookingStatus)).Count();
            IList<TableReservationStatus> bookingStatus = new List<TableReservationStatus>();

            for (int i = 0; i < length; i++)
            {
                TableReservationStatus status = new TableReservationStatus()
                {
                    Value = i,
                    Text = Enum.GetNames(typeof(TableBookingStatus))[i]
                };

                bookingStatus.Add(status);
            }

            return bookingStatus;
        }

        private void CreateService()
        {
            using (IContainer container = IOC.AutofacContainer.GetContainer())
            {
                _tbs = container.Resolve<ITableBookingService>(new TypedParameter(typeof(IRepositoryContext), new AdoRepositoryContext()));
            }
        }

        public void RemoveSelectedBookings(IList<string> checkedList)
        {
            foreach (var item in checkedList)
            {
                _tbs.Remove(item);
            }
        }
    }
}
