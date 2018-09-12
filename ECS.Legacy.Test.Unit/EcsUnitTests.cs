using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Legacy;

namespace ECS.Legacy.Test.Unit
{
    [TestFixture]
    public class ECS_UnitTest
    {
        // member variables to hold uut and fakes
        private FakeTempSensor _fakeTempSensor;
        private FakeHeater _fakeHeater;
        private ECS _uut;

        [SetUp]
        public void Setup()
        {
            // Create the fake stubs and mocks
            _fakeHeater = new FakeHeater();
            _fakeTempSensor = new FakeTempSensor();
            // Inject them into the uut via the constructor
            _uut = new ECS(_fakeTempSensor, _fakeHeater, 25, 28);
        }

        #region Thresholds
        [Test]
        public void Thresholds_SetValidUpperThreshold_ThrowsNothing()
        {
            Assert.That(() => { _uut.SetUpperThreshold(29); }, Throws.Nothing);
        }

        [Test]
        public void Thrseholds_SetValidLowerThreshold_ThrowsNothing()
        {
            Assert.That(() => { _uut.SetLowerThreshold(24); }, Throws.Nothing);
        }

        [Test]
        public void Thresholds_SetInvalidUpperThreshold_ThrowsArgumentException()
        {
            Assert.That(() => { _uut.SetUpperThreshold(10); }, Throws.ArgumentException);
        }

        [Test]
        public void Thresholds_SetInvalidLowerThreshold_ThrowsArgumentException()
        {
            Assert.That(() => { _uut.SetLowerThreshold(30); }, Throws.ArgumentException);
        }

        [Test]
        public void Thresholds_SetLowerToUpper_ThrowsNothing()
        {
            Assert.That(() => { _uut.SetLowerThreshold(_uut.GetUpperThreshold()); }, Throws.Nothing);
        }

        [Test]
        public void Thresholds_SetUpperToLower_ThrowsNothing()
        {
            Assert.That(() => { _uut.SetUpperThreshold(_uut.GetLowerThreshold()); }, Throws.Nothing);
        }

        #endregion

        #region Regulation Tests

        #region Temperature Too Low
        [Test]
        public void Regulation_TemperatureTooLow_HeaterIsTurnedOn()
        {
            _fakeTempSensor.SetTemp(24);
            _uut.Regulate();
            Assert.That(_fakeHeater.timesTurnedOn, Is.EqualTo(1));
        }
        #endregion

        #region Temperature Too High
        [Test]
        public void Regulation_TemperatureTooLow_HeaterIsTurnedOff()
        {
            _fakeTempSensor.SetTemp(29);
            _uut.Regulate();
            Assert.That(_fakeHeater.timesTurnedOff, Is.EqualTo(1));
        }
        #endregion

        #region Temperature=HiThreshold
        [Test]
        public void Regulation_TemperatureEqualsHighThreshold_HeaterIsTurnedOff()
        {
            _fakeTempSensor.SetTemp(28);
            _uut.Regulate();
            Assert.That(_fakeHeater.timesTurnedOff, Is.EqualTo(1));
        }
        #endregion

        #region Temperature=LoThreshold
        [Test]
        public void Regulation_TemperatureEqualsLowThreshold_HeaterIsTurnedOn()
        {
            _fakeTempSensor.SetTemp(25);
            _uut.Regulate();
            Assert.That(_fakeHeater.timesTurnedOff, Is.EqualTo(1));
        }
        #endregion

        #region Temperature is between thresholds
        [Test]
        public void Regulation_TemperatureEqualsLowThreshold_HeaterIsUntouched()
        {
            _fakeTempSensor.SetTemp(26);
            _uut.Regulate();
            Assert.That(_fakeHeater.timesTurnedOn, Is.EqualTo(0));
        }
        #endregion


        #endregion
    }
}
