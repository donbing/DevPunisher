using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Missile_Launcher
{
    public class MissileDevice : IDisposable
    {
        public MissileDevice()
        {
            var hidGuid = Guid.Empty;

            NativeMethods.HidD_GetHidGuid(ref hidGuid);

            var devicePathNames = GetHIDDevices(hidGuid);

            OpenDevices(devicePathNames, VendorId, ProductId);
        }


        #region IDisposable Members

        public void Dispose()
        {            
            _controlHandle?.Close();
            _controlHandle = null;

            _setupHandle?.Close();
            _setupHandle = null;
        }

        #endregion

        void OpenDevices(List<string> devicePathNames, int vendorId, int productId)
        {
            var deviceAttributes = new NativeMethods.HIDD_ATTRIBUTES
            {
                Size = Marshal.SizeOf(typeof(NativeMethods.HIDD_ATTRIBUTES))
            };

            var security = new NativeMethods.SECURITY_ATTRIBUTES
            {
                SecurityDescriptor = 0,
                InheritHandle = 1,
                Length = Marshal.SizeOf(typeof(NativeMethods.SECURITY_ATTRIBUTES))
            };

            foreach (var devicePath in devicePathNames)
            {
                var handle = NativeMethods.CreateFile(devicePath, 0,
                    NativeMethods.FILE_SHARE_READ | NativeMethods.FILE_SHARE_WRITE, ref security,
                    NativeMethods.OPEN_EXISTING, 0, 0);

                if (handle.IsInvalid || !NativeMethods.HidD_GetAttributes(handle, ref deviceAttributes))
                {
                    continue;
                }

                if (deviceAttributes.VendorID == vendorId && deviceAttributes.ProductID == productId)
                {
                    var deviceCapabilities = GetDeviceCapabilities(handle);

                    // Finally open the device
                    if (deviceCapabilities.OutputReportByteLength == 65)
                    {
                        _controlHandle = NativeMethods.CreateFile(devicePath,
                            NativeMethods.GENERIC_WRITE,
                            NativeMethods.FILE_SHARE_READ | NativeMethods.FILE_SHARE_WRITE, ref security,
                            NativeMethods.OPEN_EXISTING, 0, 0);
                    }
                    else
                    {
                        _setupHandle = NativeMethods.CreateFile(devicePath, NativeMethods.GENERIC_WRITE,
                            NativeMethods.FILE_SHARE_READ | NativeMethods.FILE_SHARE_WRITE, ref security,
                            NativeMethods.OPEN_EXISTING, 0, 0);
                    }
                }

                handle.Close();
            }
        }

        static NativeMethods.HIDP_CAPS GetDeviceCapabilities(SafeFileHandle hidHandle)
        {
            var capabilities = new NativeMethods.HIDP_CAPS();

            var preparsedDataPointer = new IntPtr();
            NativeMethods.HidD_GetPreparsedData(hidHandle, ref preparsedDataPointer);
            try
            {
                NativeMethods.HidP_GetCaps(preparsedDataPointer, ref capabilities);
            }
            finally
            {
                NativeMethods.HidD_FreePreparsedData(ref preparsedDataPointer);
            }

            return capabilities;
        }

        List<string> GetHIDDevices(Guid hidGuid)
        {
            var deviceInfoSet = NativeMethods.SetupDiGetClassDevs(ref hidGuid, null, IntPtr.Zero, NativeMethods.DIGCF_PRESENT | NativeMethods.DIGCF_DEVICEINTERFACE);
            try
            {
                var memberIndex = 0;
                var bufferSize = 0;
                var devicePathNames = new List<string>();
                var lastDevice = false;
                do
                {
                    var deviceInterfaceData = new NativeMethods.SP_DEVICE_INTERFACE_DATA
                    {
                        Size = Marshal.SizeOf(typeof(NativeMethods.SP_DEVICE_INTERFACE_DATA))
                    };

                    var success = NativeMethods.SetupDiEnumDeviceInterfaces(deviceInfoSet, 0, ref hidGuid, memberIndex, ref deviceInterfaceData);

                    if (!success)
                    {
                        lastDevice = true;
                    }
                    else
                    {
                        NativeMethods.SetupDiGetDeviceInterfaceDetail(deviceInfoSet, ref deviceInterfaceData, IntPtr.Zero, 0, ref bufferSize, IntPtr.Zero);

                        var detailDataBuffer = Marshal.AllocHGlobal(bufferSize);
                        try
                        {
                            Marshal.WriteInt32(detailDataBuffer, 4 + Marshal.SystemDefaultCharSize);

                            NativeMethods.SetupDiGetDeviceInterfaceDetail(deviceInfoSet, ref deviceInterfaceData, detailDataBuffer, bufferSize, ref bufferSize, IntPtr.Zero);

                            var devicePathName = new IntPtr(detailDataBuffer.ToInt32() + 4);

                            devicePathNames.Add(Marshal.PtrToStringAuto(devicePathName));
                        }
                        finally
                        {
                            Marshal.FreeHGlobal(detailDataBuffer);
                        }
                    }

                    memberIndex++;
                } while (!lastDevice);

                return devicePathNames;
            }
            finally
            {
                NativeMethods.SetupDiDestroyDeviceInfoList(deviceInfoSet);
            }
        }

        public void Execute(DeviceCommand command)
        {
            if (_setupHandle == null || _controlHandle == null)
                throw new ApplicationException("Unable to find a USB Missile Launcher device.");

            WriteBytes(_setupHandle, SetupMessage1);
            WriteBytes(_setupHandle, SetupMessage2);

            var bytes = new byte[65];

            switch (command)
            {
                case DeviceCommand.Left:
                    bytes[2] = 1;
                    break;

                case DeviceCommand.Right:
                    bytes[3] = 1;
                    break;

                case DeviceCommand.Up:
                    bytes[4] = 1;
                    break;

                case DeviceCommand.Down:
                    bytes[5] = 1;
                    break;

                case DeviceCommand.Fire:
                    bytes[6] = 1;
                    break;
            }

            bytes[7] = 8;
            bytes[8] = 8;

            WriteBytes(_controlHandle, bytes);
        }

        void WriteBytes(SafeFileHandle handle, byte[] bytes)
        {
            var numWritten = 0;
            if (!NativeMethods.WriteFile(handle, bytes, bytes.Length, ref numWritten, 0) || numWritten != bytes.Length)
                throw new ApplicationException("Could not write data to device.");
        }

        #region Fields

        static readonly byte[] SetupMessage1 = {0, (byte) 'U', (byte) 'S', (byte) 'B', (byte) 'C', 0, 0, 4, 0};
        static readonly byte[] SetupMessage2 = {0, (byte) 'U', (byte) 'S', (byte) 'B', (byte) 'C', 0, 0x40, 2, 0};

        static readonly int VendorId = 0x1130;
        static readonly int ProductId = 0x0202;

        SafeFileHandle _setupHandle;
        SafeFileHandle _controlHandle;

        #endregion
    }
}