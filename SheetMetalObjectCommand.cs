using Rhino;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SheetMetalObject
{
    public class SheetMetalObjectCommand : Command
    {

        public SheetMetalObjectCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
            //Getobjectdata gb = new Getobjectdata();
            //gb.Enabled = true;
            
        }

        ///<summary>The only instance of this command.</summary>
        public static SheetMetalObjectCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "SheetMetalObjectCommand";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {

            doc.Views.Redraw();
            var Panelid = SheetMetalObjectPlugIn.PanelId;
            Rhino.UI.Panels.OpenPanel(Panelid);

            return Result.Success;
        }




    }
}
