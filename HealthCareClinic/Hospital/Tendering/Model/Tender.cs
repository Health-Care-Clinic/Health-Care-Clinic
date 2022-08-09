using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Tendering.Model
{
    public class Tender
    {
        private DateRange _dateRange;
        public int Id { get; set; }

        public DateRange DateRange { 
            get
            {
                return _dateRange;
            }
            set 
            {
                if (value.Start < DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _dateRange = value;
            }
        }

        public virtual ICollection<TenderItem> TenderItems { get; set; }
        public string Description { get; set; }

        public Tender()
        {
        }

    }
}
