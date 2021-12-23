using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestProject3.Helpers
{
    public class ReadData
    {
        public static IEnumerable TestDataIterator
        {
            get { return GetTestDataIterator(); }
        }
        private static IEnumerable GetTestDataIterator()
        {
            // read data from xml file
            var doc = XDocument.Load
                (@"C:\Users\wirta\source\repos\TestProject3\TestProject3\TestingData.xml");
            return
                from vars in doc.Descendants("vars")
                let input = vars.Attribute("stringInput").Value
                let sum = vars.Attribute("sumToCompare").Value
                select new object[] { input, sum };
        }
    }
}
