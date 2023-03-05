using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
  public class DemoOne
  {
    public static void Foo1()
    {
      Console.WriteLine(DemoTwo.Foo2());
    }
  }
}