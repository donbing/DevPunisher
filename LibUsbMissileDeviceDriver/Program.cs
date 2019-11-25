using System;
using System.Linq;
using LibUsbDotNet;
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;

namespace LibUsbMissileDeviceDriver
{
    class Program
    {
        const int ProductId = 0x0202, VendorId = 0x1130;

        static readonly byte[] SetupMessage1 = { (byte)'U', (byte)'S', (byte)'B', (byte)'C', 0, 0, 4, 0 };
        static readonly byte[] SetupMessage2 = { (byte)'U', (byte)'S', (byte)'B', (byte)'C', 0, 0x40, 2, 0 };

        static byte[] _FILL = {
             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
         };
        static byte[] _STOP = {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x08};
        static byte[] _LEFT = {0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x08, 0x08 };
        static byte[] _RIGHT = {0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x08, 0x08};
        static byte[] _UP = {0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x08, 0x08 };
        static byte[] _DOWN = {0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x08, 0x08 };
        static byte[] _UPLEFT = {0x00, 0x01, 0x00, 0x01, 0x00, 0x00, 0x08, 0x08 };
        static byte[] _UPRIGHT = {0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x08, 0x08 };
        static byte[] _DOWNLEFT = {0x00, 0x01, 0x00, 0x00, 0x01, 0x00, 0x08, 0x08 };
        static byte[] _DOWNRIGHT = {0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x08, 0x08 };
        static byte[] _FIRE = {0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x08, 0x08 };        
        
        public static void Main(string[] args)
        {
            using var context = new UsbContext();
            context.SetDebugLevel(LogLevel.Debug);
            //context.SetDebugLevel(LogLevel.Info);

            //Get a list of all connected devices
            var usbDeviceCollection = context.List();

            //Narrow down the device by vendor and pid
            var selectedDevice = usbDeviceCollection.FirstOrDefault(d => d.ProductId == ProductId && d.VendorId == VendorId);

            //Open the device
            selectedDevice.Open();
            selectedDevice.ResetDevice();
            selectedDevice.SetConfiguration(1);

            //Get the first config number of the interface
            selectedDevice.ClaimInterface(selectedDevice.Configs[0].Interfaces[0].Number);
            selectedDevice.ClaimInterface(selectedDevice.Configs[0].Interfaces[1].Number);

            var usbSetupPacket = new UsbSetupPacket(0x21, 0x09, 0x2, 0x01, 1);

            selectedDevice.ControlTransfer(usbSetupPacket, SetupMessage1, 1, SetupMessage1.Length);

            selectedDevice.ControlTransfer(usbSetupPacket, SetupMessage2, 1, SetupMessage2.Length);


            var command = _DOWNRIGHT.Concat(_FILL).ToArray();
            var usbCommandSetup = new UsbSetupPacket(0x21, 0x09, 0x2, 0x01, command.Length);
            selectedDevice.ControlTransfer(usbCommandSetup, command, 0, command.Length);




            ////Open up the endpoints
            var writeEndpoint = selectedDevice.OpenEndpointWriter(WriteEndpointID.Ep01);
            //var readEnpoint = selectedDevice.OpenEndpointReader(ReadEndpointID.Ep01);

            writeEndpoint.Write(command, 3000, out var bytesWritten);

            //var readBuffer = new byte[64];

            ////Read some data
            //readEnpoint.Read(readBuffer, 3000, out var readBytes);
        }
    }
}
