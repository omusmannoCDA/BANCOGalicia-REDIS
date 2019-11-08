using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core.Abstractions;

namespace ProyectoGalicia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WSGaliciaController : ControllerBase
    {
        IDatabase redis = DAL.Redis.RedisCache;

        #region Get and Set

        [HttpPost]
        public void Set(string Key, string Value)
        {
            redis.HashSet(Key, "Datos", Value);
            redis.Multiplexer.GetSubscriber().Publish(Key, Value);
           
        }


        [HttpGet]
        public string Get(string key, string id)
        {
            try { return Encoding.ASCII.GetString(redis.HashGet(key + ":" + id, Encoding.ASCII.GetBytes("Datos"))); }
            catch { return "No se encontro el objeto"; }
        }

        [HttpPut]
        public void Put(string key, string id, string value)
        { 
            if (key == "IdTelefonoPersona" || key == "IdMailPersona")
            {
                Set(key + ":" + id, value);             
            }
            else
            {
                dynamic jsonObj = JsonConvert.DeserializeObject(value);
                var NumeroTribu = (string)jsonObj.SelectToken("NRO_IDEN_TRIBUTARI");
                var NumeroDocu = (string)jsonObj.SelectToken("NRO_DOCUMENTO");
                Set("PERSONA:" + id, value);
                Set("NRO-IDEN-TRIBUTARIO:" + NumeroTribu, value);
                Set("NRO-DOCUMENTO:" + NumeroDocu, value);
            }
           
        }

      
        #endregion
    }
}
