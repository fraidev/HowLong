using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HowLong.Models;
using NHibernate.Tool.hbm2ddl;

namespace HowLong.Models
{
    public class SerieMap : ClassMap<Serie>
    {
        public SerieMap()
        {
            Table("Serie");

            Id(x => x.Id, "Id").GeneratedBy.Identity().UnsavedValue(0);

            Map(x => x.Nome);
            Map(x => x.Tempo);
            Map(x => x.QtdEp);
        }
    }
}