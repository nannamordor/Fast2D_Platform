using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast2D_TestGame.Scripts
{
    public class ModdableVariable<T>
    {
        public T Value;
        public T ModdedValue;
        protected List<T> Multipliers;
        protected List<T> Adders;

        public void AddAdder(T adder)
        {
            Adders.Add(adder);
            RecalculateModdedValue();
        }

        public void AddMultiplier(T adder)
        {
            Multipliers.Add(adder);
            RecalculateModdedValue();
        }

        protected virtual void RecalculateModdedValue()
        {

        }
    }

    public class ModdableFloat : ModdableVariable<float>
    {
        protected override void RecalculateModdedValue()
        {
            float val = Value;
            foreach (var mul in Multipliers)
            {
                val *= mul;
            }
            foreach (var add in Adders)
            {
                val += add;
            }
            ModdedValue = val;
        }
    }

    public class ModdableInt : ModdableVariable<int>
    {
        protected override void RecalculateModdedValue()
        {
            int val = Value;
            foreach (var mul in Multipliers)
            {
                val *= mul;
            }
            foreach (var add in Adders)
            {
                val += add;
            }
            ModdedValue = val;
        }
    }

    class GenericTests<T>
    {
        public T health;
    }

    class Foo : GenericTests<float>
    {
        public Foo()
        {
            health = 12;
        }
    }

    class Foo2 : GenericTests<string>
    {
        public Foo2()
        {
            health = "12";
        }
    }
}
