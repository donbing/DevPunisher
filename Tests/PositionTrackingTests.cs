using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LittleNet.UsbMissile;
using PositionTrackingMissileLauncher;

namespace Tests
{
    public class fakeDevice : IMissileDevice
    {
        public void Command(DeviceCommand command)
        {
            // faky faky
        }
    }

    [TestClass]
    public class WhenLauncherMovesLeftFor5SecondsFromZeroDegrees
    {
        [TestMethod]
        public void ShouldReach90Degrees()
        {
            var launcher = new TrackingMissileLauncher();
            launcher.HorizAxisPos = 0;
            launcher.Left();
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual(100, launcher.HorizAxisPos);
        }
    }

    [TestClass]
    public class WhenLauncherMovesLeftFor1SecondFromZeroDegrees
    {
        [TestMethod]
        public void ShouldReach20Degrees()
        {
            var launcher = new TrackingMissileLauncher();
            launcher.HorizAxisPos = 0;
            launcher.Left();
            System.Threading.Thread.Sleep(1000);
            Assert.AreEqual(20, launcher.HorizAxisPos);
        }
    }

    [TestClass]
    public class WhenLauncherMovesLeftFor9SecondsFromZeroDegrees
    {
        [TestMethod]
        public void ShouldReach180Degrees()
        {
            var launcher = new TrackingMissileLauncher();
            launcher.HorizAxisPos = 0;
            launcher.Left();
            System.Threading.Thread.Sleep(9000);
            Assert.AreEqual(180, launcher.HorizAxisPos);
        }
    }

    [TestClass]
    public class WhenLauncherMovesRightFor9SecondsFrom180Degrees
    {
        [TestMethod]
        public void ShouldReach0Degrees()
        {
            var launcher = new TrackingMissileLauncher();
            launcher.HorizAxisPos = 180;
            launcher.Right();
            System.Threading.Thread.Sleep(9000);
            Assert.AreEqual(0, launcher.HorizAxisPos);
        }
    }

    [TestClass]
    public class WhenLauncherStopsMoving
    {
        [TestMethod]
        public void PositionshouldNotchange()
        {
            TrackingMissileLauncher launcher = new TrackingMissileLauncher();
            
            launcher.HorizAxisPos = 0;
            launcher.Left();

            System.Threading.Thread.Sleep(1000);

            launcher.Stop();
            Assert.AreEqual(20, launcher.HorizAxisPos);

            System.Threading.Thread.Sleep(1000);
            Assert.AreEqual(20, launcher.HorizAxisPos);
        }
    }

    [TestClass]
    public class WhenLauncherFires
    {
        [TestMethod]
        public void PositionshouldNotchange()
        {
            TrackingMissileLauncher launcher = new TrackingMissileLauncher();

            launcher.HorizAxisPos = 0;
            launcher.Left();

            System.Threading.Thread.Sleep(1000);

            launcher.Fire();
            Assert.AreEqual(20, launcher.HorizAxisPos);

            System.Threading.Thread.Sleep(1000);
            Assert.AreEqual(20, launcher.HorizAxisPos);
        }
    }

    [TestClass]
    public class WhenLauncherIsStoppedAndThenFires
    {
        [TestMethod]
        public void PositionshouldNotchange()
        {
            TrackingMissileLauncher launcher = new TrackingMissileLauncher();

            launcher.HorizAxisPos = 0;
            launcher.Stop();
            launcher.Fire();
            Assert.AreEqual(0, launcher.HorizAxisPos);
        }
    }

    [TestClass]
    public class WhenLauncherMovesUpFor5SecondFrom0degrees
    {
        [TestMethod]
        public void ShouldReach45Degrees()
        {
            TrackingMissileLauncher launcher = new TrackingMissileLauncher();
            launcher.VertAxisPos = 0;
            launcher.Up();
            System.Threading.Thread.Sleep(5000);
            launcher.Stop();
            Assert.AreEqual(45, launcher.VertAxisPos);
        }
    }

    [TestClass]
    public class WhenLauncherMovesUpFor1SecondFrom0degrees
    {
        [TestMethod]
        public void ShouldReach9Degrees()
        {
            TrackingMissileLauncher launcher = new TrackingMissileLauncher();
            launcher.VertAxisPos = 0;
            launcher.Up();
            System.Threading.Thread.Sleep(1000);
            launcher.Stop();
            Assert.AreEqual(9, launcher.VertAxisPos);
        }
    }

    [TestClass]
    public class WhenLauncherMovesDownFor1SecondFrom45degrees
    {
        [TestMethod]
        public void ShouldReach36Degrees()
        {
            TrackingMissileLauncher launcher = new TrackingMissileLauncher();
            launcher.VertAxisPos = 45;
            launcher.Down();
            System.Threading.Thread.Sleep(1000);
            launcher.Stop();
            Assert.AreEqual(36, launcher.VertAxisPos);
        }
    }

    [TestClass]
    public class WhenLauncherMovesPastHorizontalLimitOf180Degrees
    {
        [TestMethod]
        public void ShouldStop()
        {
            TrackingMissileLauncher launcher = new TrackingMissileLauncher();
            launcher.HorizAxisPos = 160;
            launcher.Left();
            System.Threading.Thread.Sleep(3000);
            
            Assert.AreEqual(180, launcher.HorizAxisPos);
        }
    }

    [TestClass]
    public class WhenLauncherMovesPastHorizontalLimitOf0Degrees
    {
        [TestMethod]
        public void ShouldStop()
        {
            TrackingMissileLauncher launcher = new TrackingMissileLauncher();
            launcher.HorizAxisPos = 20;
            launcher.Right();
            System.Threading.Thread.Sleep(3000);

            Assert.AreEqual(0, launcher.HorizAxisPos);
        }
    }

    [TestClass]
    public class WhenLauncherMovesPastVerticalLimitOf45Degrees
    {
        [TestMethod]
        public void ShouldStop()
        {
            TrackingMissileLauncher launcher = new TrackingMissileLauncher();
            launcher.VertAxisPos = 40;
            launcher.Up();
            System.Threading.Thread.Sleep(3000);

            Assert.AreEqual(45, launcher.VertAxisPos);
        }
    }

    [TestClass]
    public class WhenLauncherMovesPastVerticalLimitOf0Degrees
    {
        [TestMethod]
        public void ShouldStop()
        {
            TrackingMissileLauncher launcher = new TrackingMissileLauncher();
            launcher.VertAxisPos = 5;
            launcher.Down();
            System.Threading.Thread.Sleep(3000);

            Assert.AreEqual(0, launcher.VertAxisPos);
        }
    }
}
