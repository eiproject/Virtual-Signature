using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualSign.Main
{
  class Program
  {
    [DllImport(@"C:\Lab-Formulatrix\VirtualSign\VirtualSign.Main\bin\x64\Debug\CV\test.dll")]
    public static extern int CallNumber();
    // public static extern void OpticalFlowDetection(object a, object b, ref object c, ref object d);

    [DllImport(@"C:\Lab-Formulatrix\VirtualSign\VirtualSign.Main\bin\x64\Debug\CV\test.dll")]
    public static extern string SayHi();

    static void Main(string[] args)
    {
      // object a = new object();
      // object b = new object();
      // OpticalFlowDetection(new object(), new object(), ref a, ref b);

      object res1 = SayHi();
      int res2 = CallNumber();

      Console.WriteLine(res1);
      Console.WriteLine(res2);
      
      /*Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new UI());*/

      Console.ReadKey();
    }
  }
}
