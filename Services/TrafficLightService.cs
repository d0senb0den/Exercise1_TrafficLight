using Exercise1.Models;
using Exercise1.Enums;
using System.Timers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;
using Exercise1.Hubs;

namespace Exercise1.Services
{
    public class TrafficLightService
    {
        private TrafficLight _trafficLight;
        private System.Timers.Timer _timer = new System.Timers.Timer();
        private ILogger<TrafficLightService> _logger;
        private readonly IHubContext<TrafficLightHub> _hubContext;

        public TrafficLightService(ILogger<TrafficLightService> logger, IHubContext<TrafficLightHub> hubContext)
        {
            
            _logger = logger;
            _hubContext = hubContext;
            _trafficLight = new TrafficLight(120, 360); // minRedTime = 180 sek, maxGreenTime = 360 sek
            _timer.Elapsed += ChangeState;
            _timer.Interval = 120000; // Set default interval to 2 mins for Red state
            _timer.Start();
        }

         public void ChangeState(object sender, ElapsedEventArgs e)
        {
            switch (_trafficLight.CurrentState)
            {
                case TrafficLightState.Red:
                    _trafficLight.CurrentState = TrafficLightState.Green;
                    _timer.Interval = 120000; // Change interval to 2 mins for Green state
                    break;
                case TrafficLightState.Green:
                    _trafficLight.CurrentState = TrafficLightState.Yellow;
                    _timer.Interval = 5000; // Change interval to 5 seconds for Yellow state
                    break;
                case TrafficLightState.Yellow:
                    _trafficLight.CurrentState = TrafficLightState.Red;
                    _timer.Interval = 120000; // Change interval back to 2 mins for Red state
                    //FrontendCLient.updateTrafficLight(TrafficLight);
                    break;
            }
            _logger.LogInformation("Current State: " + _trafficLight.CurrentState);
            _hubContext.Clients.All.SendAsync("TrafficLightStateChange", _trafficLight.CurrentState);
        }
        public TrafficLight GetTrafficLight()
        {
            return _trafficLight;
        }

        public TrafficLightState GetCurrentState()
        {
            return _trafficLight.CurrentState;
        }
    }
}
