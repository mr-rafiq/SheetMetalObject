using Rhino;
using Rhino.Collections;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.DocObjects.Custom;
using Rhino.Geometry;
using Rhino.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SheetMetalObject
{
    public static class Databank
    {
        public static RhinoList<Guid> polyid = new RhinoList<Guid>();
        
    }

    public class Diction : UserDictionary 
    {

        public AttributeIds userdata;
        
        private void test() { }

    }

    public class AttributeIds: UserData
    {
        public double thickness;
        public string materialName;
        public double lengthofline;
        
        
        public System.Drawing.Color Objcolor;
        public Curve Curv { get; set; }
        
        public AttributeIds()
        { }
        public AttributeIds(string materialName, double thickness, double lengthofline, System.Drawing.Color Objcolor, Curve cur)
        {
            
            this.materialName = materialName;
            this.thickness = thickness;
            this.lengthofline = lengthofline;
           
            this.Objcolor = Objcolor;
            this.Curv= cur;
        }
        protected override void OnTransform(Transform transformation)
        {

            
            base.OnTransform(transformation);
            
            RhinoApp.WriteLine("OntransformOntransformOntransform");

                //Curv.Transform(transformation);
                MainPanel.PassCurve.Transform(transformation);
           
            //this.cur.Transform(transformation);           
           
        }


        public Rhino.DocObjects.ObjectAttributes defaultribute()
        {
            var dc = Rhino.RhinoDoc.ActiveDoc.CreateDefaultAttributes();
            dc.ObjectColor = Rhino.RhinoDoc.ActiveDoc.Layers.CurrentLayer.Color;
            dc.Name = materialName;
            dc.UserDictionary.Set("thickness", thickness);
            dc.UserDictionary.Set("lengthofline", lengthofline);
            //dc.ColorSource = Rhino.DocObjects.ObjectColorSource.ColorFromObject;
            dc.ObjectColor = Objcolor;
            dc.PlotColor = System.Drawing.Color.Black;
            dc.UserDictionary.Set("Curve",this.Curv);
            
            ObjectLayers layer = new ObjectLayers(materialName, Objcolor);
            dc.LayerIndex = layer.Check_AddLayer();
            return dc;
        }

    }


    public class ObjectLayers
    {
        private RhinoDoc doc = RhinoDoc.ActiveDoc;

        public string Layername;
        public System.Drawing.Color Layercolor;
        public ObjectLayers(string Layername, System.Drawing.Color Layercolor )
        {
            this.Layername = Layername;
            this.Layercolor = Layercolor;

        }
       
        public int Check_AddLayer()
        {
            //layer name
            string layer_name = Layername;

            // Does a layer with the same name already exist?
            int layer_index = doc.Layers.Find(layer_name, true);
            if (layer_index >= 0)
            {
                return layer_index;
            }
            else
            {
                layer_index = doc.Layers.Add(layer_name, Layercolor);
                return layer_index;
            }            
        }
    }


    //public class Getobjectdata : MouseCallback
    //{
    //    protected override void OnMouseDoubleClick(Rhino.UI.MouseCallbackEventArgs e)
    //    {
    //        //if (e.Button == MouseButtons.Left)
    //        //{
    //        //    if(Rhino.Input.RhinoGet)
    //        //    var Panelid = SheetMetalObjectPlugIn.PanelId;
    //        //    Rhino.UI.Panels.OpenPanel(Panelid);
    //        //    MessageBox.Show("you double clicked left mouse button !!");
    //        //}
    //        //base.OnMouseDoubleClick(e);
    //    }
    //}

    //public class RhinoGetobject : EventArgs
    //{
    //    public RhinoGetobject()
    //    {
    //        // simple example of handling the BeforeTransformObjects event
    //        var Panelid = SheetMetalObjectPlugIn.PanelId;
    //        //RhinoDoc.SelectObjects += this.fun;
    //    }


    //    private void RhinoGetobjectselection(object sender, EventArgs ea)
    //    {
    //        RhinoObjectSelectionEventArgs e = (RhinoObjectSelectionEventArgs)ea;
    //        RhinoApp.WriteLine("Transform Objects Count: {0}", e.RhinoObjects.ToString());
    //    }
    //}
}
