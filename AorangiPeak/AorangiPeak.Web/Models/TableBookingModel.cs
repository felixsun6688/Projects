using AorangiPeak.Dto.TableBookingDto;
using AorangiPeak.Infrastructure.Context;
using AorangiPeak.Service.ServiceInterface;
using AorangiPeak.Web.IOC;
using Autofac;
using System.Collections;
using System.Web.Mvc;

namespace AorangiPeak.Web.Models
{
    public class TableBookingModel
    {
        public NewTableBookingDto NewTableBookingDto { get; set; }
        public SelectList NumberOfAdultsList { get; set; }
        public SelectList NumberOfChildrenList { get; set; }
        public SelectList TimeList { get; set; }
        public TableBookingDetailDto TableBookingDetailDto { get; set; }

        private ITableBookingService _tbs;

        public TableBookingModel()
        {
            CreateService();
            InitNumberOfAdultsList();
            InitNumberOfChildrenList();
            InitTimeList();
        }

        public void AddNewTableBooking(NewTableBookingDto dto)
        {
            if (dto!=null)
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

        private void InitNumberOfAdultsList()
        {
            IEnumerable peopleNumberList = _tbs.GetTableBookingAdults();

            NumberOfAdultsList = new SelectList(peopleNumberList, "Value", "Text");
        }

        private void InitNumberOfChildrenList()
        {
            IEnumerable peopleNumberList = _tbs.GetTableBookingChildren();

            NumberOfChildrenList = new SelectList(peopleNumberList, "Value", "Text");
        }

        private void InitTimeList()
        {
            IEnumerable bookingTimeList = _tbs.GetTableBookingTime();

            TimeList = new SelectList(bookingTimeList, "TimeValue", "TimeText");
        }

        private void CreateService()
        {
            using (IContainer container = AutofacContainer.GetContainer())
            {
                _tbs = container.Resolve<ITableBookingService>(new TypedParameter(typeof(IRepositoryContext), new AdoRepositoryContext()));
            }
        }
    }
}