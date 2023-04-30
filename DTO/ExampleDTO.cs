using System.Xml;
using System.Xml.Serialization;

namespace ValidationTool
{
    [XmlRoot("Example")]
    public class ExampleDTO
    {
        public ExampleDTO()
        {
            this.InputExample = new Input();
        }
        [XmlElement("Input")]
        public Input InputExample { get; set; }

        public class Input
        {
            public Input()
            {
                this.inputContent = "";
                this.inputList = new List<string>(); 
                this.inputElement = new InputElement();
            }

            [ValidationAttributes.NotNullOrEmpty("InputContent is Null or Empty!")]
            public string inputContent { get; set; }
            public List<string> inputList { get; set; }
            public InputElement inputElement { get; set; }
        }

        public class InputElement
        {
            public InputElement()
            {
                this.inputElementContent = "";
            }

            [ValidationAttributes.NotNullOrEmpty("InputElementCointent is Null or Empty!")]
            public string inputElementContent { get; set; }
        }
    }
}