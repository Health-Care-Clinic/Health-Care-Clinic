using Hospital.Events.Model;
using Hospital.Events.Repository;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Events.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly ITransferService _transferService;

        public EventService(IEventRepository eventRepository, ITransferService transferService)
        {
            _eventRepository = eventRepository;
            _transferService = transferService;
        }
        public void Add(Event entity)
        {
            _eventRepository.Add(entity);
            _eventRepository.Save();
        }

        public IEnumerable<Event> GetAll()
        {
            return _eventRepository.GetAll();
        }

        public Event GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Event entity)
        {
            throw new NotImplementedException();
        }
        public Transfer GetMostFrequentEvent()
        {
            IEnumerable<Event> allEvents = GetAll();
            List<int> srcs = new List<int>();
            List<int> dsts = new List<int>();
            List<string> names = new List<string>();
            List<int> qtys = new List<int>();

            bool found = false;

            foreach (Event e in allEvents) {
                if (e.UserId.Equals(100))
                {
                    if (e.Content.Split(":").Length > 0)
                    {
                        srcs.Add(Int32.Parse(e.Content.Split(":")[0]));
                        dsts.Add(Int32.Parse(e.Content.Split(":")[1]));
                        names.Add(e.Content.Split(":")[2]);
                        qtys.Add(Int32.Parse(e.Content.Split(":")[3]));
                        found = true;
                    }
                }
            }

            var mostSrc = 2;
            var mostDst = 1;
            var mostName = "Bed";
            var mostQty = 1;

            if (found)
            {
                mostSrc = srcs.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
                mostDst = dsts.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
                mostName = names.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
                mostQty = qtys.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
            }

            Transfer transfer = new Transfer(0, new Equipment(mostName, mostQty), mostSrc, mostDst, new DateTime(2022, 2, 1, 9, 0, 0), 60);
            if (GetAll().Count() % 2 > 0)
            {
                transfer.RoomsForTransfer.SourceRoomId = mostDst;
                transfer.RoomsForTransfer.DestinationRoomId = mostSrc;
            }

            transfer.DateAndDuration.Date = GetFreeDate();

            return transfer;
        }

        private DateTime GetFreeDate()
        {
            DateTime dateTime = DateTime.Now.AddDays(1);
            foreach (Transfer t in _transferService.GetAll())
            {
                if (t.DateAndDuration.Date.Date.CompareTo(dateTime.Date) == 0)
                {
                   dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 00, 00).AddDays(1);
                } 
                else
                {
                    dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, (dateTime.Minute / 15) * 15, 0).AddMinutes(15);
                }
            }

            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0);
        }
    }
}
