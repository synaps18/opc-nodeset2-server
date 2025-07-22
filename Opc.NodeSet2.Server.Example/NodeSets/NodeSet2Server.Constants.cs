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
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;

namespace NodeSet2Server
{
    #region DataType Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypes
    {
        /// <remarks />
        public const uint DemoStructure = 3000;
    }
    #endregion

    #region Object Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <remarks />
        public const uint http___OpcNodeSet2Server = 5000;

        /// <remarks />
        public const uint Demo = 5001;

        /// <remarks />
        public const uint DemoStructure_Encoding_DefaultBinary = 5002;

        /// <remarks />
        public const uint DemoStructure_Encoding_DefaultXml = 5003;
    }
    #endregion

    #region Variable Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <remarks />
        public const uint http___OpcNodeSet2Server_NamespaceUri = 6002;

        /// <remarks />
        public const uint http___OpcNodeSet2Server_NamespaceVersion = 6003;

        /// <remarks />
        public const uint http___OpcNodeSet2Server_NamespacePublicationDate = 6001;

        /// <remarks />
        public const uint http___OpcNodeSet2Server_IsNamespaceSubset = 6000;

        /// <remarks />
        public const uint http___OpcNodeSet2Server_StaticNodeIdTypes = 6004;

        /// <remarks />
        public const uint http___OpcNodeSet2Server_StaticNumericNodeIdRange = 6005;

        /// <remarks />
        public const uint http___OpcNodeSet2Server_StaticStringNodeIdPattern = 6006;
    }
    #endregion

    #region DataType Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypeIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId DemoStructure = new ExpandedNodeId(NodeSet2Server.DataTypes.DemoStructure, NodeSet2Server.Namespaces.NodeSet2Server);
    }
    #endregion

    #region Object Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId http___OpcNodeSet2Server = new ExpandedNodeId(NodeSet2Server.Objects.http___OpcNodeSet2Server, NodeSet2Server.Namespaces.NodeSet2Server);

        /// <remarks />
        public static readonly ExpandedNodeId Demo = new ExpandedNodeId(NodeSet2Server.Objects.Demo, NodeSet2Server.Namespaces.NodeSet2Server);

        /// <remarks />
        public static readonly ExpandedNodeId DemoStructure_Encoding_DefaultBinary = new ExpandedNodeId(NodeSet2Server.Objects.DemoStructure_Encoding_DefaultBinary, NodeSet2Server.Namespaces.NodeSet2Server);

        /// <remarks />
        public static readonly ExpandedNodeId DemoStructure_Encoding_DefaultXml = new ExpandedNodeId(NodeSet2Server.Objects.DemoStructure_Encoding_DefaultXml, NodeSet2Server.Namespaces.NodeSet2Server);
    }
    #endregion

    #region Variable Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId http___OpcNodeSet2Server_NamespaceUri = new ExpandedNodeId(NodeSet2Server.Variables.http___OpcNodeSet2Server_NamespaceUri, NodeSet2Server.Namespaces.NodeSet2Server);

        /// <remarks />
        public static readonly ExpandedNodeId http___OpcNodeSet2Server_NamespaceVersion = new ExpandedNodeId(NodeSet2Server.Variables.http___OpcNodeSet2Server_NamespaceVersion, NodeSet2Server.Namespaces.NodeSet2Server);

        /// <remarks />
        public static readonly ExpandedNodeId http___OpcNodeSet2Server_NamespacePublicationDate = new ExpandedNodeId(NodeSet2Server.Variables.http___OpcNodeSet2Server_NamespacePublicationDate, NodeSet2Server.Namespaces.NodeSet2Server);

        /// <remarks />
        public static readonly ExpandedNodeId http___OpcNodeSet2Server_IsNamespaceSubset = new ExpandedNodeId(NodeSet2Server.Variables.http___OpcNodeSet2Server_IsNamespaceSubset, NodeSet2Server.Namespaces.NodeSet2Server);

        /// <remarks />
        public static readonly ExpandedNodeId http___OpcNodeSet2Server_StaticNodeIdTypes = new ExpandedNodeId(NodeSet2Server.Variables.http___OpcNodeSet2Server_StaticNodeIdTypes, NodeSet2Server.Namespaces.NodeSet2Server);

        /// <remarks />
        public static readonly ExpandedNodeId http___OpcNodeSet2Server_StaticNumericNodeIdRange = new ExpandedNodeId(NodeSet2Server.Variables.http___OpcNodeSet2Server_StaticNumericNodeIdRange, NodeSet2Server.Namespaces.NodeSet2Server);

        /// <remarks />
        public static readonly ExpandedNodeId http___OpcNodeSet2Server_StaticStringNodeIdPattern = new ExpandedNodeId(NodeSet2Server.Variables.http___OpcNodeSet2Server_StaticStringNodeIdPattern, NodeSet2Server.Namespaces.NodeSet2Server);
    }
    #endregion

    #region BrowseName Declarations
    /// <remarks />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class BrowseNames
    {
        /// <remarks />
        public const string CallMe = "CallMe";

        /// <remarks />
        public const string CallMe2 = "CallMe2";

        /// <remarks />
        public const string Demo = "Demo";

        /// <remarks />
        public const string Demo_Structure = "Demo Structure";

        /// <remarks />
        public const string DemoStructure = "DemoStructure";

        /// <remarks />
        public const string http___OpcNodeSet2Server = "http://OpcNodeSet2Server";

        /// <remarks />
        public const string Modeling_Editor = "Modeling Editor";
    }
    #endregion

    #region Namespace Declarations
    /// <remarks />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the NodeSet2Server namespace (.NET code namespace is 'NodeSet2Server').
        /// </summary>
        public const string NodeSet2Server = "http://OpcNodeSet2Server";

        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";
    }
    #endregion
}