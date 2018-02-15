using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HowLong.Models;
using HowLong.Models.Persistance;

namespace HowLong.Controllers
{
    [RoutePrefix("api/Series")]
    public class SeriesController : ApiController
    {
        static readonly ISerieRepository SerieRepository = new SerieRepository();

        public IEnumerable<Serie> GetServerData()
        {
            return SerieRepository.GetAll();
        }

        public Serie GetServerDataById(int id)
        {
            var serie = SerieRepository.Get(id);

            if (serie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return serie;
        }

        //public IEnumerable<Serie> GetServerDataByType(int type)
        //{
        //    return ServerDataRepository.GetAll().Where(d => d.Type == type);
        //}

        //public IEnumerable<Serie> GetServerDataByIP(string ip)
        //{
        //    return ServerDataRepository.GetAll().Where(d => d.IP.ToLower() == ip.ToLower());
        //}

        //Why commented this - explained in the article

        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public Serie PostSerie(Serie serie)
        {
            return SerieRepository.Add(serie);
        }

        //public HttpResponseMessage PostSerie([FromBody] Serie serie)
        //{
        //    serie = SerieRepository.Add(serie);

        //    var response = Request.CreateResponse(HttpStatusCode.Created, serie);

        //    var uri = Url.Link("DefaultApi", new { id = serie.Id });
        //    response.Headers.Location = new Uri(uri);

        //    return response;

        //}

        public void PutSerie(int id, Serie serie)
        {
            serie.Id = id;

            if (!SerieRepository.Update(serie))
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        public void DeleteSerie(int id)
        {
            var serverData = SerieRepository.Get(id);

            if (serverData == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            SerieRepository.Delete(id);
        }
    }
}
