using Rhino.DocObjects.Custom;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetMetalObject
{
    public class TestUserData : UserData
    {
        public Rhino.Geometry.Curve Crv { get; set; }
        public TestUserData() { }
        public TestUserData(Rhino.Geometry.Curve curv)
        {
            Crv = curv;
        }
        public override string Description
        {
            get { return "Test Properties"; }
        }



        public Curve setcurve()
        {
            return Crv;
        }
    }
}
