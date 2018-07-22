using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoteControl remoteControl = new ConcreteRemoteControl();
            //remoteControl.TV = new SanXinTV();
            remoteControl.TV = new ChangHongTV();
            remoteControl.On();
            remoteControl.Off();
            remoteControl.SwitchChannel();
            Console.ReadKey();
        }
    }
}
