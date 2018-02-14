﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HowLong.Models;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace HowLong.Helper
{
    public class NHibernateHelper
    {
        
        private static ISessionFactory _sessionFactory;
        //const string ConnectionString = @"Data Source=.;Initial Catalog=HowLongDb;Integrated Security=SSPI;";
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    CreateSessionFactory();

                return _sessionFactory;
            }
        }

        private static void CreateSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Data Source=.;Initial Catalog=HowLongDb;Integrated Security=SSPI;").ShowSql)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Serie>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false,false))
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();

        }
    }
}