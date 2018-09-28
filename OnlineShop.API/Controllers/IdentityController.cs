using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Models;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    // [Authorize]
    public class IdentityController : ControllerBase
    {
        [HttpGet("login")]
        public IActionResult Get()
        {
            return Redirect("Login");
        }

        [HttpGet]
        public async Task<IActionResult> GetRequest()
        {
            var clients = await DiscoveryClient.GetAsync("http://localhost:5000");
            var tokenClient = new TokenClient(clients.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("resourceApi");

            if (tokenResponse.IsError)
            {
                return new JsonResult(tokenResponse.Error);
            }

            return new JsonResult(tokenResponse.Json);
        }
    }
}