using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ExportDto
{
    [XmlType("Customer ")]
    public class CustomerExportDto
    {
        [XmlAttribute("FirstName")]
        public string FirstName { get; set; }

        [XmlAttribute("LastName")]
        public string LastName { get; set; }

        public decimal SpentMoney { get; set; }

        public DateTime SpentTime { get; set; }
    }
}
