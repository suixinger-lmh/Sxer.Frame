﻿using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
namespace Sxer.Frame.Func.Process.XMLProcess
{
    [XmlRoot("OperationXmlSerializer")]
    [XmlInclude(typeof(XMLOperationBase))]
    public class OperationXmlSerializer
    {
        [XmlArray("XMLOperationBases")]
        [XmlArrayItem("XMLOperationBase")]
        public List<XMLOperationBase> operation = new List<XMLOperationBase>();
        
    }
}