using System;

namespace ECS.Legacy
{
    public class ECS
    {
        private int _upperThreshold;
        private int _lowerThreshold;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;
        private readonly IWindow _window;

        public ECS(ITempSensor tempSensor, IHeater heater, IWindow window, int loThr, int hiThr)
        {
            SetUpperThreshold(hiThr);
            SetLowerThreshold(loThr);
            _tempSensor = tempSensor;
            _heater = heater;
            _window = window;
        }

        public void Regulate()
        {
            var curTemp = _tempSensor.GetTemp();
            // Determine which action to take according to the temperature
            if (curTemp < _lowerThreshold)
            {
                _heater.TurnOn();
                _window.CloseWindow();
            }
            else if (curTemp >= _lowerThreshold && curTemp <= _upperThreshold)
            {
                _heater.TurnOff();
                _window.CloseWindow();
            }
            else
            {
                _heater.TurnOff();
                _window.OpenWindow();
            }
        }

        public void SetUpperThreshold(int thr)
        {
            if(thr>=_lowerThreshold)
            {
                _upperThreshold = thr;
            }
            else
            {
                throw new ArgumentException("Upper threshold must be >= lower threshold");
            }
        }

        public void SetLowerThreshold(int thr)
        {
            if (thr <= _upperThreshold)
            {
                _lowerThreshold = thr;
            }
            else
            {
                throw new ArgumentException("Lower threshold must be <= upper threshold");
            }
        }

        public int GetUpperThreshold()
        {
            return _upperThreshold;
        }

        public int GetLowerThreshold()
        {
            return _lowerThreshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }
    }
}
