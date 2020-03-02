using Gol.Domain.Entities;
using Gol.Test.Helpers;
using NUnit.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gol.Test
{
    public class TestTravel
    {
        //Testing nulls in/and api endpoints;

        public HttpRequestHelper helper;

        [SetUp]
        public void Setup()
        {
            helper = new HttpRequestHelper();
            helper.Configure(new HttpHelperConfig
            {
                _urlapi = "http://localhost:33965/api/Travel",
                _body = "",
                _method = "",
                _headerCollection = null,
                _parameters = "",
                _timeoutConnection = 60000,
                _action = ""
            });
        }

        [Test]
        public void TestGetAll()
        {
            helper.action = "GetAll";
            helper.method = "GET";
            var h = helper.ExecuteRequest<IEnumerable<Travel>>();


            if (h == null)
            {
                Assert.Fail();
            }
            else
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestGetById()
        {
            helper.method = "GET";
            helper.action = "GetById";
            helper.parameters = "/1";
            var h = helper.ExecuteRequest<Travel>();


            if (h == null)
            {
                Assert.Fail();
            }
            else
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestInsert()
        {

            helper.action = "Insert";
            helper.method = "POST";
            helper.body = JsonConvert.SerializeObject(new Travel() { Nome = "nova Viagem", DataPartida = DateTime.Now.ToString(), Origem = "Brasil - São Paulo", Destino = "Irlanda - Dublin" });
            var h = helper.ExecuteRequest<Travel>();


            if (h == null)
            {
                Assert.Fail();
            }
            else
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestUpdate()
        {


            helper.action = "Update";
            helper.method = "PUT";
            helper.body = JsonConvert.SerializeObject(new Travel() { Id=1, Nome = "Viagem São Paulo-Dublin", DataPartida = DateTime.Now.ToString(), Origem = "Brasil - São Paulo", Destino = "Irlanda - Dublin" });
            var h = helper.ExecuteRequest<Travel>();


            if (h == null)
            {
                Assert.Fail();
            }
            else
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestDelete()
        {
            helper.action = "Delete";
            helper.parameters = "/1";
            helper.method = "DELETE";
            var h = helper.ExecuteRequest();


            if (h == null)
            {
                Assert.Fail();
            }
            else
            {
                Assert.Pass();
            }
        }

    }


}