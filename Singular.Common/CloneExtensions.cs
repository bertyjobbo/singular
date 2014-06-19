using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singular.Common
{
    public static class CloneExtensions
    {
        public static T SlowParameterlessConstructorClone<T>(this T original)
        {
            // get type
            var type = typeof (T);

            // new
            var output = Activator.CreateInstance<T>();

            // clone
            foreach (var prop in type.GetProperties())
            {
                var existingVal = prop.GetValue(original);
                prop.SetValue(output,existingVal);
            }

            return output;
        }
    }
}
