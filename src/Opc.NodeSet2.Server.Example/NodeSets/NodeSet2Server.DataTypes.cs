/* ========================================================================
 * Copyright (c) 2005-2024 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;

namespace NodeSet2Server
{
    #region DemoStructure Class
    #if (!OPCUA_EXCLUDE_DemoStructure)
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [DataContract(Namespace = NodeSet2Server.Namespaces.NodeSet2Server)]
    public partial class DemoStructure : IEncodeable, IJsonEncodeable
    {
        #region Constructors
        /// <remarks />
        public DemoStructure()
        {
            Initialize();
        }
            
        [OnDeserializing]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }
            
        private void Initialize()
        {
            m_id = (int)0;
            m_name = null;
        }
        #endregion

        #region Public Properties
        /// <remarks />
        [DataMember(Name = "Id", IsRequired = false, Order = 1)]
        public int Id
        {
            get { return m_id;  }
            set { m_id = value; }
        }

        /// <remarks />
        [DataMember(Name = "Name", IsRequired = false, Order = 2)]
        public string Name
        {
            get { return m_name;  }
            set { m_name = value; }
        }
        #endregion

        #region IEncodeable Members
        /// <summary cref="IEncodeable.TypeId" />
        public virtual ExpandedNodeId TypeId => DataTypeIds.DemoStructure; 

        /// <summary cref="IEncodeable.BinaryEncodingId" />
        public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DemoStructure_Encoding_DefaultBinary;

        /// <summary cref="IEncodeable.XmlEncodingId" />
        public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DemoStructure_Encoding_DefaultXml;
                    
        /// <summary cref="IJsonEncodeable.JsonEncodingId" />
        public virtual ExpandedNodeId JsonEncodingId => NodeId.Null; 

        /// <summary cref="IEncodeable.Encode(IEncoder)" />
        public virtual void Encode(IEncoder encoder)
        {
            encoder.PushNamespace(NodeSet2Server.Namespaces.NodeSet2Server);

            encoder.WriteInt32("Id", Id);
            encoder.WriteString("Name", Name);

            encoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.Decode(IDecoder)" />
        public virtual void Decode(IDecoder decoder)
        {
            decoder.PushNamespace(NodeSet2Server.Namespaces.NodeSet2Server);

            Id = decoder.ReadInt32("Id");
            Name = decoder.ReadString("Name");

            decoder.PopNamespace();
        }

        /// <summary cref="IEncodeable.IsEqual(IEncodeable)" />
        public virtual bool IsEqual(IEncodeable encodeable)
        {
            if (Object.ReferenceEquals(this, encodeable))
            {
                return true;
            }

            DemoStructure value = encodeable as DemoStructure;

            if (value == null)
            {
                return false;
            }

            if (!Utils.IsEqual(m_id, value.m_id)) return false;
            if (!Utils.IsEqual(m_name, value.m_name)) return false;

            return true;
        }

        /// <summary cref="ICloneable.Clone" />
        public virtual object Clone()
        {
            return (DemoStructure)this.MemberwiseClone();
        }

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            DemoStructure clone = (DemoStructure)base.MemberwiseClone();

            clone.m_id = (int)Utils.Clone(this.m_id);
            clone.m_name = (string)Utils.Clone(this.m_name);

            return clone;
        }
        #endregion

        #region Private Fields
        private int m_id;
        private string m_name;
        #endregion
    }

    #region DemoStructureCollection Class
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [CollectionDataContract(Name = "ListOfDemoStructure", Namespace = NodeSet2Server.Namespaces.NodeSet2Server, ItemName = "DemoStructure")]
    public partial class DemoStructureCollection : List<DemoStructure>, ICloneable
    {
        #region Constructors
        /// <remarks />
        public DemoStructureCollection() {}

        /// <remarks />
        public DemoStructureCollection(int capacity) : base(capacity) {}

        /// <remarks />
        public DemoStructureCollection(IEnumerable<DemoStructure> collection) : base(collection) {}
        #endregion

        #region Static Operators
        /// <remarks />
        public static implicit operator DemoStructureCollection(DemoStructure[] values)
        {
            if (values != null)
            {
                return new DemoStructureCollection(values);
            }

            return new DemoStructureCollection();
        }

        /// <remarks />
        public static explicit operator DemoStructure[](DemoStructureCollection values)
        {
            if (values != null)
            {
                return values.ToArray();
            }

            return null;
        }
        #endregion

        #region ICloneable Methods
        /// <remarks />
        public object Clone()
        {
            return (DemoStructureCollection)this.MemberwiseClone();
        }
        #endregion

        /// <summary cref="Object.MemberwiseClone" />
        public new object MemberwiseClone()
        {
            DemoStructureCollection clone = new DemoStructureCollection(this.Count);

            for (int ii = 0; ii < this.Count; ii++)
            {
                clone.Add((DemoStructure)Utils.Clone(this[ii]));
            }

            return clone;
        }
    }
    #endregion
    #endif
    #endregion
}