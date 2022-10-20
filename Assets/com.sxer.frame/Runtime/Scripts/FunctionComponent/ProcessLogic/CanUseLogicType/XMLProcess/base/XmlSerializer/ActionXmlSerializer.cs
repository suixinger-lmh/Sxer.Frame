using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
namespace Sxer.Frame.Func.Process.XMLProcess
{
    [XmlRoot("ActionXmlSerializer")]
    [XmlInclude(typeof(XMLActionBase))]
    public class ActionXmlSerializer
    {
        [XmlArray("XMLActionBases")]
        [XmlArrayItem("XMLActionBase")]
        public List<XMLActionBase> action;
        
    }
}