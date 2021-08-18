using MyStore.Domain.Abstract;
using MyStore.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Web.Http;

namespace MyStore.WebUI.Controllers
{
    public class VoteController : ApiController
    {
        private IProductRepository repository;
        public VoteController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }


        // POST api/Vote
        public HttpResponseMessage Post([FromBody]Vote vote)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }

            //todo: Session-9.2 Cross Site Request Forgery Fix (API)
            //ValidateRequestHeader(Request);
            
            var connString = WebConfigurationManager.ConnectionStrings["EFDbContext"].ConnectionString;
            var sqlString = "INSERT INTO Votes(UserID, ProductID, Comments) VALUES (" + vote.UserID + ", " + vote.ProductID + ", N'" + vote.Comments + "')";

            using (var conn = new SqlConnection(connString))
            {
                var command = new SqlCommand(sqlString, conn);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            //repository.SaveProductVote(vote);
            return Request.CreateResponse(HttpStatusCode.Created);
        }


        void ValidateRequestHeader(HttpRequestMessage request)
        {
            const string csrfCookieName = "__RequestVerificationToken";
            var cookieToken = string.Empty;
            var headerToken = string.Empty;

            var cookie = request.Headers.GetCookies(csrfCookieName).FirstOrDefault();
            if (cookie != null)
            {
                cookieToken = cookie[csrfCookieName].Value;
            }

            IEnumerable<string> tokenHeaders;
            if (request.Headers.TryGetValues("X-Csrf-Token", out tokenHeaders))
            {
                headerToken = tokenHeaders.First();
            }

            AntiForgery.Validate(cookieToken, headerToken);
        }
    }

    
}
