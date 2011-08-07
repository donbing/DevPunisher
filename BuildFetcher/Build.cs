﻿using System;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace BuildFetcher.AutoGeneratedClasses
{
    [XmlRoot("freeStyleBuild", IsNullable = false)]
    public class Build
    {

        [XmlElement("culprit", Form = XmlSchemaForm.Unqualified)]
        public User[] culprit
        {
            get;
            set;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public bool building
        {
            get;
            set;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public int number
        {
            get;
            set;
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string result
        {
            get;
            set;
        }
    }

    [Serializable]
    [XmlType(TypeName = "hudson.model.User")]
    public partial class User
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string fullName
        {
            get;
            set;
        }
    }

}
