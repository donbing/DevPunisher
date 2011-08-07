using System;
using System.Collections.Generic;
using System.Text;

namespace MissileCommandService
{
    public interface IMissileLauncher
    {
         void Up();
         void Down();
         void Left();
         void Right();
         void Stop();
         void Fire();
    }

    public interface ICommand
    {
        void Execute();
    }
}
