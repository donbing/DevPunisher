using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissileLauncher.Interfaces;
using StructureMap;
using LittleNet.UsbMissile;

namespace Tests
{
    [TestClass]
    public class anthropomorphTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            ObjectFactory.Inject(new MissileDevice());
            ObjectFactory.Initialize(x => x.Scan(s => { s.AssembliesFromApplicationBaseDirectory(); s.WithDefaultConventions(); }));
            var launcher = ObjectFactory.GetInstance<IMissileLauncher>();

            Shake(launcher);
            Nod(launcher);
        }

        private void Nod(IMissileLauncher launcher)
        {
            launcher.Down();
            System.Threading.Thread.Sleep(700);
            launcher.Stop();
            launcher.Up();
            System.Threading.Thread.Sleep(500);
            launcher.Stop();
            launcher.Down();
            System.Threading.Thread.Sleep(300);
            launcher.Stop();
            launcher.Up();
            System.Threading.Thread.Sleep(200);
            launcher.Stop();
        }

        private void Shake(IMissileLauncher launcher)
        {
            launcher.Right();
            System.Threading.Thread.Sleep(800);
            launcher.Stop();
            launcher.Left();
            System.Threading.Thread.Sleep(800);
            launcher.Stop();
            launcher.Right();
            System.Threading.Thread.Sleep(800);
            launcher.Stop();
            launcher.Left();
            System.Threading.Thread.Sleep(800);
            launcher.Stop();
            launcher.Right();
            System.Threading.Thread.Sleep(800);
            launcher.Stop();
        }
    }
}
