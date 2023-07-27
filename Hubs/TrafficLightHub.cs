using Exercise1.Enums;
using Exercise1.Models;
using Microsoft.AspNetCore.SignalR;

namespace Exercise1.Hubs
{
    public class TrafficLightHub : Hub
    {
        private readonly TrafficLight _trafficLight;
        public TrafficLightHub(TrafficLight trafficLight)
        {
            _trafficLight = trafficLight;
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        /*public TrafficLightState GetCurrentState()
        {
            return _trafficLight.CurrentState;
        }*/
    }
}
