using System.Xml;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class ExportProductDto
    {
        [XmlElement("name")]
        public string Name;
        [XmlElement("price")]
        public decimal Price;
        [XmlElement("buyer")]
        public string BuyerFullName;
    }
}