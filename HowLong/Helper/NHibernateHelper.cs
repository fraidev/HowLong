using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
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
                {
                    CreateSessionFactory();
                }

                return _sessionFactory;
            }
        }

        private static void CreateSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Data Source=.;Initial Catalog=HowLongDb;Integrated Security=SSPI;").ShowSql)
                .Mappings(m => 
                    m.FluentMappings.AddFromAssemblyOf<Serie>() // NHibernate, olhe o assembly onde está a classe Serie e procure por arquivos de mapemanento que eu conheço.
                    .Conventions.Add(DefaultLazy.Never())) // para não precisar do Virtual na classe
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))

                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();

        }
    }
}