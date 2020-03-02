using Gol.Domain.Entities;
using Gol.Test.Helpers;
using NUnit.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gol.Test
{
    public class TestAuthUser
    {


        //Testing nulls in/and api endpoints;


        public HttpRequestHelper helper;

        [SetUp]
        public void Setup()
        {
            helper = new HttpRequestHelper();
            helper.Configure(new HttpHelperConfig
            {
                _urlapi = "http://localhost:33965/api/Auth",
                _body = "",
                _method = "",
                _headerCollection = null,
                _parameters = "",
                _timeoutConnection = 60000,
                _action = ""
            });
        }

        [Test]
        public void TestRegister()
        {
            helper.action = "Register";
            helper.method = "POST";
            helper.body = JsonConvert.SerializeObject(new AuthUser() { User = "teste1", Password = "Admin" });
            
            
            var h = helper.ExecuteRequestString();
            
            if (h == null || (h.ToLower().Contains("erro") && !h.ToLower().Contains("this user is already used")))
            {
                Assert.Fail();
            }
            else
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestAuthenticate()
        {
            helper.method = "POST";
            helper.action = "Authenticate";
            helper.body = JsonConvert.SerializeObject(new AuthUser() { User = "teste1", Password = "Admin" });
            var h = helper.ExecuteRequest<AuthUser>();


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