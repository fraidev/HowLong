using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HowLong.Helper;

namespace HowLong.Models.Persistance
{
    public class SerieRepository : ISerieRepository
    {

        public Serie Get(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
           //     return session.Get<Serie>(id);
            return session.QueryOver<Serie>()
                .Where(c => c.Id == id)
                .SingleOrDefault();
        }

        public IEnumerable<Serie> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
                return session.Query<Serie>().ToList();
        }

        public Serie Add(Serie serie)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(serie);
                    transaction.Commit();
                }
                return serie;
            }
        }

        public void Delete(int id)
        {
            var serie = Get(id);

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(serie);
                    transaction.Commit();
                }
            }

        }

        public bool Update(Serie serie)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(serie);
                    try
                    {
                        transaction.Commit();
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
                return true;
            }
        }
    }
}