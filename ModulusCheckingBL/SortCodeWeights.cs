using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Web;

namespace ModulusCheckingBL
{
    public class SortCodeWeight
    {
        public string StartCode { get; set; }
        public string EndCode { get; set; }
        public string Method { get; set; }
        public short[] Weights { get; } = new short[14];
        public short Exception { get; set; }
    }

    public class SortCodeWeights
    {
        static private List<SortCodeWeight> _sortCodeWeights = new List<SortCodeWeight>();
        static private SortCodeWeight _default = new SortCodeWeight(){ Method="MOD01"};

        static SortCodeWeights()
        {
            var filePath = HttpContext.Current == null ?
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\",""), "Data") :
                AppDomain.CurrentDomain.GetData("DataDirectory").ToString(); 
            
            filePath = Path.Combine(filePath, "valacdos.txt"); // We might want to define this in an App/Web.Config

            var reader = new StreamReader(filePath); // We might want to define this in an App.Config
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                while (line.Contains(@"  ")) line = line.Replace(@"  ", " ");
                var fields = line.Split(' ');

                var sortCodeWeight = new SortCodeWeight()
                {
                    StartCode = fields[0],
                    EndCode = fields[1],
                    Method = fields[2]
                };

                for (int i=0; i< 14; i++) sortCodeWeight.Weights[i] = fields[i+3].ToShort();

                if (fields.Length > 17) sortCodeWeight.Exception = fields[17].ToShort();

                _sortCodeWeights.Add(sortCodeWeight);
            }


        }

        public static SortCodeWeight Default() => _default;
        public static IEnumerable<SortCodeWeight> Get(string sortCode) { return _sortCodeWeights.Where(scw => string.Compare(sortCode, scw.StartCode) >= 0 && string.Compare(sortCode, scw.EndCode) <= 0); }
    }

    /// <summary>
    /// String conversion helper
    /// </summary>
    internal static class EString
    {

        public static short ToShort(this string value)
        {
            short returnVal;
            if (!short.TryParse(value, out returnVal)) return 0;
            return returnVal;
        }

        public static short ToShort(this char value) => value.ToString().ToShort();
      
        public static string ToNumericOnly(this string value)
        {
            const string pattern = @"[^\d]";
            return string.Join("", Regex.Split(value, pattern));
        }
    }
}