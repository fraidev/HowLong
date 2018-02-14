using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HowLong.Models
{
    public class Serie
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Tempo { get; set; }
        public decimal QtdEp { get; set; }


        //public Serie(Serie series)
        //{
        //    this.Id = series.Id;
        //    this.Nome = series.Nome;
        //    this.Tempo = series.Tempo;
        //    this.QtdEp = series.QtdEp;
        //}
    }

}