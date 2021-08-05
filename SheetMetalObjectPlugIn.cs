
using Rhino;
using Rhino.Collections;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.Geometry;
using Rhino.PlugIns;
using Rhino.UI;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SheetMetalObject
{
    ///<summary>
    /// <para>Every RhinoCommon .rhp assembly must have one and only one PlugIn-derived
    /// class. DO NOT create instances of this class yourself. It is the
    /// responsibility of Rhino to create an instance of this class.</para>
    /// <para>To complete plug-in information, please also see all PlugInDescription
    /// attributes in AssemblyInfo.cs (you might need to click "Project" ->
    /// "Show All Files" to see it in the "Solution Explorer" window).</para>
    ///</summary>

    [Guid("413E4328-CA66-43C0-AC6A-EB8F3468552A")]
    [CommandStyle(Style.ScriptRunner)]
    public class SheetMetalObjectPlugIn : PlugIn
    {
        
  
        
        public static Guid PanelId => typeof(SheetObject).GUID;
        
        public SheetMetalObjectPlugIn()
        {
            Instance = this;

        }


        ///<summary>Gets the only instance of the SheetMetalObjectPlugIn plug-in.</summary>
        public static SheetMetalObjectPlugIn Instance
        {
            get; private set;
        }
        protected override LoadReturnCode OnLoad(ref string errorMessage)
        {
            Type panelType = typeof(SheetObject);
            Panels.RegisterPanel(this, panelType, "SheetMetal", Properties.Resources.SheetMetalCrossSection);
            return LoadReturnCode.Success;
        }

        // You can override methods here to change the plug-in behavior on
        // loading and shut down, add options pages to the Rhino _Option command
        // and maintain plug-in wide options in a document.\               
    }
}