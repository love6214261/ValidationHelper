using System.Collections.Generic;
using System.Xml;
using System.XMl.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ValidationTool
{
    [XmlRoot("Example")]
    public class ExampleDTO
    {
        public ExampleDTO()
        {
            this.Input = new Input();
        }
        [XmlElement("Input")]
        public Input Input { get; set; }

        public class Input
        {
            public Input()
            {
                this.inputContent = "";
                this.inputList = new List<string>(); 
                this.inputElement = new inputElement();
            }

            [ValidationAttributes.ValidateDTOIsNullOrEmpty("InputCointent is Null or Empty!")]
            public string inputContent;
            public List<string> inputList;
            public InputElement inputElement;
        }

        public class InputElement
        {
            public InputElement()
            {
                this.inputElementContent = "";
            }

            [ValidationAttributes.ValidateDTOIsNullOrEmpty("InputElementCointent is Null or Empty!")]
            public string inputElementContent;
        }
    }
}