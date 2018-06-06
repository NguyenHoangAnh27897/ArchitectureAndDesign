using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceRecruimentNhibernate.Models.NHibernate
{
    public class TTUT
    {
        public virtual int ID { get; set; }
        public virtual int Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual System.DateTime DayofBirth { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual string ApplyPosition { get; set; }
        public virtual System.DateTime DateofApplication { get; set; }
        public virtual string FileAttach { get; set; }
    }
}