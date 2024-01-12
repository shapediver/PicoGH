using System;

using Grasshopper.Kernel;
using R = Rhino.Geometry;
using P = PicoGK;

namespace PicoGH
{
    public class PicoGH_MeshUnionComponent : PicoGH_BaseComponent
    {
        /// <summary>
        /// How to expose this component 
        /// </summary>
        /// <returns>How to expose this component</returns>
        public override GH_Exposure Exposure { get { return GH_Exposure.primary; } }

        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public PicoGH_MeshUnionComponent()
          : base("PicoGH Mesh union", "Mesh union", "Boolean union of meshes", PicoGH_Constants.SubCategoryOperations)
        {
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("{8BF125E5-FAA7-4322-B696-5C5A037C64D0}"); }
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddMeshParameter("Mesh 1", "M1", "First mesh", GH_ParamAccess.item);
            pManager.AddMeshParameter("Mesh 2", "M2", "First mesh", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddMeshParameter("Mesh", "M", "Resulting mesh", GH_ParamAccess.item);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            R.Mesh rm1 = null, rm2 = null;
            if (!DA.GetData<R.Mesh>(0, ref rm1))
                return;
            if (!DA.GetData<R.Mesh>(1, ref rm2))
                return;

            P.Mesh pm1 = this.Conversion.ToPicoMesh(rm1);
            P.Mesh pm2 = this.Conversion.ToPicoMesh(rm2);

            P.Voxels pv = new P.Voxels(pm1);
            pv.RenderMesh(pm2);

            P.Mesh pmres = pv.mshAsMesh();
            R.Mesh rmres = this.Conversion.ToRhinoMesh(pmres);

            DA.SetData(0, rmres);
        }

    }
}
