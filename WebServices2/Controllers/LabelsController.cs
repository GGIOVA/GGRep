using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServices2.Models;

namespace WebServices2.Controllers
{
    public class LabelsController : ApiController
    {
        public List<Label> LabelsIT = new List<Label>
        {
            new Label("IT_1","La mietitrebbiatrice (nota anche come mietitrebbia o mietibatte) è una macchina agricola in grado di mietere ed allo stesso tempo trebbiare vari tipi di colture principalmente cereali e leguminose secche."),
            new Label("IT_2","La mietitrebbiatrice (nota anche come mietitrebbia o mietibatte) è una macchina agricola in grado di mietere ed allo stesso tempo trebbiare vari tipi di colture principalmente cereali e leguminose secche."),
            new Label("IT_3","La mietitrebbiatrice (nota anche come mietitrebbia o mietibatte) è una macchina agricola in grado di mietere ed allo stesso tempo trebbiare vari tipi di colture principalmente cereali e leguminose secche."),
            new Label("IT_4","La mietitrebbiatrice (nota anche come mietitrebbia o mietibatte) è una macchina agricola in grado di mietere ed allo stesso tempo trebbiare vari tipi di colture principalmente cereali e leguminose secche."),
            new Label("IT_5","La mietitrebbiatrice (nota anche come mietitrebbia o mietibatte) è una macchina agricola in grado di mietere ed allo stesso tempo trebbiare vari tipi di colture principalmente cereali e leguminose secche."),
        };

        public List<Label> LabelsEN = new List<Label>
        {
            new Label("EN_1","The modern combine harvester, or simply combine, is a versatile machine designed to efficiently harvest a variety of grain crops. The name derives from its combining three separate harvesting operations - reaping, threshing, and winnowing - into a single process."),
            new Label("EN_2","The modern combine harvester, or simply combine, is a versatile machine designed to efficiently harvest a variety of grain crops. The name derives from its combining three separate harvesting operations - reaping, threshing, and winnowing - into a single process."),
            new Label("EN_3","The modern combine harvester, or simply combine, is a versatile machine designed to efficiently harvest a variety of grain crops. The name derives from its combining three separate harvesting operations - reaping, threshing, and winnowing - into a single process."),
            new Label("EN_4","The modern combine harvester, or simply combine, is a versatile machine designed to efficiently harvest a variety of grain crops. The name derives from its combining three separate harvesting operations - reaping, threshing, and winnowing - into a single process."),
            new Label("EN_5","The modern combine harvester, or simply combine, is a versatile machine designed to efficiently harvest a variety of grain crops. The name derives from its combining three separate harvesting operations - reaping, threshing, and winnowing - into a single process."),
        };

        [HttpGet]
        public IEnumerable<Label> GetLabels()
        {

            return LabelsEN;
        }

        [HttpGet]
        public IEnumerable<Label> GetLabels(string Locale)
        {

            if (Locale.Equals("IT"))
                return LabelsIT;

            return LabelsEN;
        }
    }
}
