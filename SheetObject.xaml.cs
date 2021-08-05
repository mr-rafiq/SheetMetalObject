using Rhino.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SheetMetalObject
{
    /// <summary>
    /// Interaction logic for SheetObject.xaml
    /// </summary>

    [Guid("513E4328-CA66-43C0-AC6A-EB8F3468552E")]
    [CommandStyle(Rhino.Commands.Style.ScriptRunner)]
    public partial class SheetObject : Window
    {
        public SheetObject()
        {
            InitializeComponent();
            
        }

        private void Poly_Click(object sender, RoutedEventArgs e)
        {
            Poly p = new Poly();
            _ = p.Polymaker(Rhino.RhinoDoc.ActiveDoc);
        }

 

    }
}
