using Exercise1.Enums;
using System;

namespace Exercise1.Models
{
    public class TrafficLight
    {
        public TrafficLightState CurrentState { get; set; }
        public DateTime StateStartingTime { get; set; }
        public int MinRedTime { get; set; }
        public int MaxGreenTime { get; set; }

        public TrafficLight(int minRedTime, int maxGreenTime)
        {
            CurrentState = TrafficLightState.Red;
            StateStartingTime = DateTime.Now;
            MinRedTime = minRedTime;
            MaxGreenTime = maxGreenTime;
        }
    }
}