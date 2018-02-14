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
    public class SeriesController : ApiController
    {
        static readonly ISerieRepository ServerDataRepository = new SerieRepository();

        public IEnumerable<Serie> GetServerData()
        {
            return ServerDataRepository.GetAll();
        }

        public Serie GetServerDataById(int id)
        {
            var serie = ServerDataRepository.Get(id);

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
        //public ServerData PostServerData(ServerData serverData)
        //{
        //    return serverDataRepository.Add(serverData);
        //}

        public HttpResponseMessage PostServerData([FromBody] Serie serie)
        {
            serie = ServerDataRepository.Add(serie);

            var response = Request.CreateResponse(HttpStatusCode.Created, serie);

            var uri = Url.Link("DefaultApi", new { id = serie.Id });
            response.Headers.Location = new Uri(uri);

            return response;

        }

        public void PutServerData(int id, Serie serie)
        {
            serie.Id = id;

            if (!ServerDataRepository.Update(serie))
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        public void DeleteServerData(int id)
        {
            var serverData = ServerDataRepository.Get(id);

            if (serverData == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            ServerDataRepository.Delete(id);
        }
    }
}
