using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceHumanResourceNhibernate.Models.NHibernate
{
    public class DSTK
    {
        public virtual int ID { get; set; }
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
    }
}