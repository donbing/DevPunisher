using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LittleNet.UsbMissile;
using Rhino.Mocks;
using MissileLauncher.Interfaces;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class MissileDeviceShouldMove
    {
        private Action<IMissileDevice, DeviceCommand> ExecuteCommand 
            = (dvc,cmd) => dvc.Command(cmd) ;

        private Action Wait
            = () => System.Threading.Thread.Sleep(1000);

        [TestMethod]
        public void Should_Go_Up_Left_Right_Down_Fire()
        {
            IMissileDevice dvc =  new MissileDevice();

            ExecuteCommand(dvc, DeviceCommand.Up);
            Wait();
            ExecuteCommand(dvc, DeviceCommand.Stop);
            ExecuteCommand(dvc, DeviceCommand.Left);
            Wait();
            ExecuteCommand(dvc, DeviceCommand.Stop);
            ExecuteCommand(dvc, DeviceCommand.Right);
            Wait();
            ExecuteCommand(dvc, DeviceCommand.Stop);
            ExecuteCommand(dvc, DeviceCommand.Down);
            Wait();
            ExecuteCommand(dvc, DeviceCommand.Stop);
            ExecuteCommand(dvc, DeviceCommand.Fire);
        }
    }

    [TestClass]
    public class MissileLauncherControlsDevice
    {
        private IMissileLauncher testLauncher;
        private IMissileDevice fakeDevice;

        public void CheckCall(Action<IMissileLauncher> action, DeviceCommand cmd)
        {
            action(testLauncher);
            fakeDevice.AssertWasCalled(d=>d.Command(cmd));
        }

        [TestMethod]
        public void MissileLauncher_Commands_MissileDevice()
        {
            fakeDevice = MockRepository.GenerateMock<IMissileDevice>();
            testLauncher = new LittleNet.UsbMissile.MissileLauncher(fakeDevice);

            CheckCall(l => l.Up(), DeviceCommand.Up);
            CheckCall(l => l.Left(), DeviceCommand.Left);
            CheckCall(l => l.Right(), DeviceCommand.Right);
            CheckCall(l => l.Down(), DeviceCommand.Down);
            CheckCall(l => l.Stop(), DeviceCommand.Stop);
            CheckCall(l => l.Fire(), DeviceCommand.Fire);
        }
    }
}
