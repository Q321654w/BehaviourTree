﻿using UnityEngine;

namespace BehaviourTree
{
    public class DelayNode : INode
    {
        private readonly Timer _timer;

        private bool _thisNodeIsActive;

        public DelayNode(Timer timer)
        {
            _timer = timer;
            _thisNodeIsActive = true;
            _timer.TimIsUp += OnTimeIsUp;
        }

        private void OnTimeIsUp()
        {
            _thisNodeIsActive = false;
            _timer.Stop();
        }

        public void Enter()
        {
            _timer.Resume();
        }

        public bool Execute()
        {
            if (_thisNodeIsActive)
            {
                _timer.Update(Time.deltaTime);
                return true;
            }
            
            Reset();
            return false;
        }
        
        private void Reset()
        {
            _timer.Reset();
            _thisNodeIsActive = true;
        }
    }
}