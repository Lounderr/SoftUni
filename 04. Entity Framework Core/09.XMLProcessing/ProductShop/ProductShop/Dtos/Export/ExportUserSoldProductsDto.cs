using ProductShop.Dtos.Export;
using ProductShop.Models;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class ExportUserSoldProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName;

        [XmlElement("lastName")]
        public string LastName;

        [XmlElement("soldProducts")]
        public ExportSoldProductsDto[] SoldProducts;
    }
}