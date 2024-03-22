using System;
using Grasshopper.Kernel;

namespace PicoGH
{
    public interface IPicoGHPlugin 
    {
        
    }
  
    public class PicoGHPlugin : GH_AssemblyPriority, IPicoGHPlugin
    {
        public PicoGHPlugin()
        {
       
        }

        /// <summary>
        ///  This function will be invoked by Grasshopper before any of our components is loaded for the first time.
        /// </summary>
        public override GH_LoadingInstruction PriorityLoad()
        {
            //Instances.ComponentServer.AddCategoryIcon("PluginTemplate", ResourceLoader.LoadBitmap("PluginGrasshopper_16.png"));
            //Instances.ComponentServer.AddCategorySymbolName("PluginTemplate", 'P');
            
            try
            {
                PicoGK.Library.Go(0.5f);
            }

            catch (Exception e)
            {
                // Apparently something went wrong, output here
                DisplayError(e);
            }


            return GH_LoadingInstruction.Proceed;
        }

        private void DisplayError(Exception e)
        {
            Rhino.UI.Dialogs.ShowMessage(e.ToString(), "PicoGH error",
                Rhino.UI.ShowMessageButton.OK,
                Rhino.UI.ShowMessageIcon.Error);
        }

      
    }
}
