using Rhino;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.Geometry;
using Rhino.Input;
using System;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Forms;

namespace SheetMetalObject
{
    [Guid("CE6E3C5B-439E-462E-9133-E4A800125FE1")]
    [CommandStyle(Rhino.Commands.Style.ScriptRunner)]
    public partial class MainPanel : System.Windows.Forms.UserControl
    {
        public MainPanel()
        {
            InitializeComponent();
            //this.sheetObject = new SheetMetalObject.SheetObject();
            //this.elementHost.Child = this.sheetObject;
            //Command.BeginCommand += Onresetcommand;
            //RhinoDoc.SelectObjects += fun;        
           
        }
        public static Curve PassCurve { get; set; }
        #region Check selection Get Details from selected object to Panel
        //public void fun(object sender, RhinoObjectSelectionEventArgs ea)
        //{
        //    RhinoDoc.ActiveDoc.Views.Redraw();
        //    var dc = Rhino.RhinoDoc.ActiveDoc;
        //    var selectedobj = dc.Objects.GetSelectedObjects(false, false).ToList();
        //    if (selectedobj.Count == 1)
        //    {
        //        var selectdid = selectedobj[0].Id;
        //        if (selectedobj[0].Attributes.Name == "SheetMetalPoly")
        //        {
        //            TestWPF test = new TestWPF();
        //            IEnumerator foi = test.Panel1.Children.GetEnumerator();
        //            foi.Reset();
        //            foi.MoveNext();
        //            Foiler ff = (Foiler)foi.Current;                    
        //            ff.MaterialName.Text = selectedobj[0].Attributes.Name;
        //            ff.Thicknes.Text = selectedobj[0].Attributes.UserDictionary.Values[0].ToString();
        //            Curve ud = (Curve)selectedobj[0].Attributes.UserDictionary.Values[2];
        //            var uds = selectedobj[0].Attributes.UserData[0];
        //            AttributeIds atid = new AttributeIds(selectedobj[0].Attributes.Name, (double)selectedobj[0].Attributes.UserDictionary.Values[0], (double)selectedobj[0].Attributes.UserDictionary.Values[1], System.Drawing.Color.Red, (Curve)selectedobj[0].Attributes.UserDictionary.Values[2]);
        //            PassCurve = atid.Curv;
        //            selectedobj[0].UserData.Add(atid);
        //            //GlobalStatic.transcurve = ud;
        //            ff.Length.Text = ud.PointAtStart.ToString();
        //            //test.Panel2.Children.Add(foil1);
        //            IEnumerator a = test.Panel2.Children.GetEnumerator();
        //            a.Reset();
        //            a.MoveNext();
        //            SheetObject b = (SheetObject)a.Current;
        //            b.Thickness.Text = "2";
        //            //test.Panel2.Children[0] = foil1;
        //            this.elementHost.Child = test;   
        //            Guid Panelid = SheetMetalObjectPlugIn.PanelId;
        //            Rhino.UI.Panels.OpenPanel(Panelid);
        //            RhinoApp.WriteLine(selectedobj[0].Name, selectedobj[0].Attributes.UserDictionary.Values[1].ToString());
        //        }
        //    }
        //    else { }

        //}
        #endregion

        #region Switch Between the Panel
        public void Onresetcommand(object sender, CommandEventArgs e)
        {
            if (e.CommandEnglishName == "SheetMetalObjectCommand")
            { resetpaneltype(); }
        }

       
        public void resetpaneltype()
        {
            var dc = Rhino.RhinoDoc.ActiveDoc;
            string str = String.Empty;
            RhinoGet.GetString("PanelName", true, ref str);
            
            switch(str)
            {
                case "SheetMetal":
                    var selectedobj = dc.Objects.UnselectAll();
                    SheetObject sh = new SheetObject();
                    //panelContainer.Controls.Clear();
                    this.elementHost.Child = sh;
                    //this.elementHost.ch
                    break;

                case "Foiler":
                    var unslt = dc.Objects.UnselectAll();
                    TestWPF fl = new TestWPF();
                    //panelContainer.Controls.Clear();
                    this.elementHost.Child = fl;
                    //this.elementHost.ch
                    break;

            }

        }
        #endregion
    }
}