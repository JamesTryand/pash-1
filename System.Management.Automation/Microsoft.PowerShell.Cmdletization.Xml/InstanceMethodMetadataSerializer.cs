namespace Microsoft.PowerShell.Cmdletization.Xml
{
    using System;
    using System.CodeDom.Compiler;
    using System.Xml;
    using System.Xml.Serialization;

    [GeneratedCode("sgen", "4.0")]
    internal sealed class InstanceMethodMetadataSerializer : XmlSerializer1
    {
        public override bool CanDeserialize(XmlReader xmlReader)
        {
            return xmlReader.IsStartElement("InstanceMethodMetadata", "");
        }

        protected override object Deserialize(XmlSerializationReader reader)
        {
            return ((XmlSerializationReader1) reader).Read78_InstanceMethodMetadata();
        }

        protected override void Serialize(object objectToSerialize, XmlSerializationWriter writer)
        {
            ((XmlSerializationWriter1) writer).Write78_InstanceMethodMetadata(objectToSerialize);
        }
    }
}
