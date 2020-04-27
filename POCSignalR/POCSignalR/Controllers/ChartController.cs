using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using POCSignalR.DataStorage;
using POCSignalR.Hubs;
using POCSignalR.TimerFeatures;

namespace POCSignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IHubContext<ChartHub> _hub;

        public ChartController(IHubContext<ChartHub> hub)
        {
            _hub = hub;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var timermanager =
                new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));
            return Ok(new {Message = "Request completed"});
        }
    }
}