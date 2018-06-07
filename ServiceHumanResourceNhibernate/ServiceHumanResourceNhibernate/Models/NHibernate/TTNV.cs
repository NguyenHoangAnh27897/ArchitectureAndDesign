using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceHumanResourceNhibernate.Models.NHibernate
{
    public class TTNV
    {
        public virtual string ID { get; set; }
        public virtual string Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual System.DateTime DayofBirth { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Position { get; set; }
        public virtual int IDCard { get; set; }
        public virtual string Address { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual string WorkatBranch { get; set; }
    }
}