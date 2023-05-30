using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Wpf_Karaokay.Model;

namespace Wpf_Karaokay.Model
{
    public class TimerService
    {
        private Dictionary<Room, int> _elapsedTimes;
        private Dictionary<Room, Timer> _roomTimers;

        public TimerService()
        {
            _elapsedTimes = new Dictionary<Room, int>();
            _roomTimers = new Dictionary<Room, Timer>();
        }

        public void StartTimerForRoom(Room room, Action<Room> timerCallback)
        {
            if (!_roomTimers.ContainsKey(room))
            {
                _elapsedTimes[room] = 0; // Initialize elapsed time to 0
                Timer timer = new Timer(state =>
                {
                    UpdateElapsedSeconds(room); // Increment elapsed time
                    timerCallback((Room)state); // Invoke the timer callback
                }, room, TimeSpan.Zero, TimeSpan.FromSeconds(1));
                _roomTimers.Add(room, timer);
            }
        }

        public void StopTimerForRoom(Room room)
        {
            if (_roomTimers.TryGetValue(room, out Timer timer))
            {
                timer.Dispose();
                _roomTimers.Remove(room);
                _elapsedTimes.Remove(room);
            }
        }

        public int GetElapsedSeconds(Room room)
        {
            if (_elapsedTimes.ContainsKey(room))
            {
                return _elapsedTimes[room];
            }

            return 0;
        }

        private void UpdateElapsedSeconds(Room room)
        {
            if (_elapsedTimes.ContainsKey(room))
            {
                _elapsedTimes[room]++;
            }
        }
    }

}
