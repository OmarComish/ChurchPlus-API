using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using ChurchPlus_v1._0.Middleware;

namespace ChurchPlus_v1._0.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ConfigurationController: Controller
    {
       private readonly ISettings _settings;
       public ConfigurationController(ISettings settings)
       {
            _settings = settings;
       }
       [HttpGet]
       public async Task<IActionResult> GetOfferingGroups()
       {
          var response = await Task.Run(() =>_settings.GetOfferingGroups());
          return Ok(response);
       }
    }
}