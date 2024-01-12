using System;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace PicoGH
{
    public abstract class PicoGH_BaseComponent : GH_Component
    {
        public PicoGH_BaseComponent(string name, string nickname, string description, string subcategory)
          : base(name, nickname, description, PicoGH_Constants.Category, subcategory)
        {
        }

        private static IPicoGH_Conversion _Conversion = new PicoGH_Conversion();

        protected IPicoGH_Conversion Conversion => _Conversion;

    }
}
