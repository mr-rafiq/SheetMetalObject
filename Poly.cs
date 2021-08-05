using Rhino;
using Rhino.Collections;
using Rhino.Commands;
using Rhino.Display;
using Rhino.DocObjects;
using Rhino.DocObjects.Custom;
using Rhino.Geometry;
using Rhino.Input.Custom;
using System;
using System.Windows;

namespace SheetMetalObject
{
    public class Poly : Command
    {


        public override string EnglishName => "Poly";

       protected override Result RunCommand(Rhino.RhinoDoc doc, RunMode mode)
       {               
         return Polymaker(doc);
       }
                    
        public  Result Polymaker(RhinoDoc doc)
        {
            RhinoList<Point3d> plin = new RhinoList<Point3d>();
            var gp = new GetPolylineCurve(plin);
            RhinoList<Guid> ids = new RhinoList<Guid>();
            Guid addedplId = Guid.Empty;


            RhinoList<Point3d> sides = new RhinoList<Point3d>();
            while (true)
            {
                gp.SetCommandPrompt("click location to create point. (<ESC> exit)");
                gp.Get();
                if (gp.CommandResult() != Rhino.Commands.Result.Success)
                    break;
                Point3d pt = gp.Point();
                plin.Add(pt);                
                PolylineCurve curv = new PolylineCurve(plin);
                var respolycrv = CreatePolyLineFromPoint(pt, curv);
                ids.Add(doc.Objects.AddCurve(respolycrv));                
                doc.Views.Redraw();
            }
            doc.Objects.Delete(ids, true);
            PolylineCurve newcrv = new PolylineCurve(plin);
      
            AttributeIds atid = new AttributeIds("SheetMetalPoly",1,newcrv.GetLength(), System.Drawing.Color.Red,newcrv.ToNurbsCurve());
            newcrv.UserData.Add(atid);


            //ud.Crv = newcrv;
            //var att = atid.defaultribute();
            //att.UserData.Add(ud);
            //newcrv.UserDictionary.
            Databank.polyid.Add(doc.Objects.AddCurve(newcrv, atid.defaultribute()));
            MessageBox.Show(Databank.polyid.Count.ToString());
            return Result.Success;
        }

        public static PolylineCurve CreatePolyLineFromPoint(Point3d pt, PolylineCurve curv)
        {

            RhinoList<Point3d> plin = new RhinoList<Point3d>();
            var seg = curv.DuplicateSegments();
            foreach (var crv in seg) { plin.Add(crv.PointAtStart); }
            plin.Add(pt);
            PolylineCurve newcrv = new PolylineCurve(plin);
            return newcrv;

        }
        public class GetPolylineCurve : GetPoint
        {
            private RhinoList<Point3d> pl_point { get; set; }
            public GetPolylineCurve(RhinoList<Point3d> ppoint)
            {
                pl_point = ppoint;
            }
            protected override void OnDynamicDraw(GetPointDrawEventArgs e)
            {
                float f = 2F;
                RhinoList<Point3d> fn_point = new RhinoList<Point3d>();
                fn_point.AddRange(pl_point);
                fn_point.Add(e.CurrentPoint);
                e.Display.DrawPolyline(fn_point, Rhino.RhinoDoc.ActiveDoc.Layers.CurrentLayer.Color);
                e.Display.DrawPoints(fn_point, PointStyle.RoundSimple, f, System.Drawing.Color.Red);
                base.OnDynamicDraw(e);
            }

        }

    }
}