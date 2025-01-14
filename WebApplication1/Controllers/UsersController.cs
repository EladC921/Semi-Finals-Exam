﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsersController : ApiController
    {
        //GET users list
        public IEnumerable<User> Get()
        {
            User u = new User();
            return u.GetUList();
        }

        //GET fans list
        [Route("api/Users/fans/{sId}")]
        public IEnumerable<User> Get(int sId)
        {
            User u = new User();
            return u.GetUList(sId);
        }

        //GET login details
        public HttpResponseMessage Get(string mail, string password)
        {
            User u = new User();
            u = u.Get(mail, password); //get list of emails
            if (u.Mail != null)
                return Request.CreateResponse(HttpStatusCode.OK, u); //check if any of the emails has the typed password
            return Request.CreateResponse(HttpStatusCode.NotFound, "Email address or Password is incorrect");
        }

        // POST user
        public HttpResponseMessage Post([FromBody] User user)
        {
            int numOfEffected = user.Insert();
            if (numOfEffected == -1)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Email address already taken");
            else
                return
                   Request.CreateResponse(HttpStatusCode.OK, numOfEffected);
        }

        // PUT api/<controller>/5
        public void Put(int id, string status)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}