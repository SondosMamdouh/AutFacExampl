using Autofac;
using System;

namespace AutoFacExample
{
    class Program
    {
          public interface IWeapon { void Kill(); }
    public class Bazuka : IWeapon {
        public void Kill() { Console.Write("BIG bum"); }
    }

    public class Sword : IWeapon {
        public void Kill() { Console.Write("Chik-chik"); }
    }
    public class Warrior {
        private readonly IWeapon _weapon;
        public Warrior(IWeapon weapon) { _weapon = weapon; }
        public void Kill() { _weapon.Kill(); }
    }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Bazuka>();
            builder.RegisterType<Warrior>();
            builder.RegisterType<Sword>();
            builder.Register<IWeapon>(x => x.Resolve<Bazuka>());

            var container = builder.Build();
            var warrior = container.Resolve<Warrior>();
            warrior.Kill();
        }
    }
}
