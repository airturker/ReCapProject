using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }


        private DateTime dateNow = DateTime.Today;

        public DateTime Date
        {
            get { return dateNow; }
            set { dateNow = value; }
        }

    }
}
