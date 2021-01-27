using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectsLoaneds.Models
{
    public class ObjectsLoanedsModel
    {

        public int Id { get; set; }
        public string NamePeopleLoaned { get; set; }
        public string NameObjectLoaned { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateLoanedObject { get; set; }
        [DataType(DataType.Date)]
        public DateTime LimitDate { get; set; }


    }
}
