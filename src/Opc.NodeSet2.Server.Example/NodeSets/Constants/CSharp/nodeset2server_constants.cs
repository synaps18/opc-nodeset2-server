namespace NodeSet2Server.WebApi
{
    /// <summary>
    /// The namespaces used in the model.
    /// </summary>
    public static class Namespaces
    {
        /// <remarks />
        public const string Uri = "http://OpcNodeSet2Server";
    }

    /// <summary>
    /// The browse names defined in the model.
    /// </summary>
    public static class BrowseNames
    {
        /// <remarks />
        public const string Create_demo_structure = "Create demo structure";
        /// <remarks />
        public const string Demo = "Demo";
        /// <remarks />
        public const string Demo_structures = "Demo structures";
        /// <remarks />
        public const string DemoStructure = "DemoStructure";
        /// <remarks />
        public const string Hello_world = "Hello world";
        /// <remarks />
        public const string http___OpcNodeSet2Server = "http://OpcNodeSet2Server";
        /// <remarks />
        public const string Latest_demo_structure = "Latest demo structure";
        /// <remarks />
        public const string Modeling_Editor = "Modeling Editor";
        /// <remarks />
        public const string Validate_demo_structure = "Validate demo structure";
    }

    /// <summary>
    /// The well known identifiers for DataType nodes.
    /// </summary>
    public static class DataTypeIds {
        /// <remarks />
        public const string DemoStructure = "nsu=" + Namespaces.Uri + ";i=3000";

        /// <summary>
        /// Converts a value to a name for display.
        /// </summary>
        public static string ToName(string value)
        {
            foreach (var field in typeof(DataTypeIds).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                if (field.GetValue(null).Equals(value))
                {
                    return field.Name;
                }
            }

            return value.ToString();
        }
    }

    /// <summary>
    /// The well known identifiers for Object nodes.
    /// </summary>
    public static class ObjectIds {
        /// <remarks />
        public const string http___OpcNodeSet2Server = "nsu=" + Namespaces.Uri + ";i=5000";
        /// <remarks />
        public const string Demo = "nsu=" + Namespaces.Uri + ";i=5001";
        /// <remarks />
        public const string DemoStructure_Encoding_DefaultBinary = "nsu=" + Namespaces.Uri + ";i=5002";
        /// <remarks />
        public const string DemoStructure_Encoding_DefaultXml = "nsu=" + Namespaces.Uri + ";i=5003";

        /// <summary>
        /// Converts a value to a name for display.
        /// </summary>
        public static string ToName(string value)
        {
            foreach (var field in typeof(ObjectIds).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                if (field.GetValue(null).Equals(value))
                {
                    return field.Name;
                }
            }

            return value.ToString();
        }
    }

    /// <summary>
    /// The well known identifiers for Variable nodes.
    /// </summary>
    public static class VariableIds {
        /// <remarks />
        public const string http___OpcNodeSet2Server_NamespaceUri = "nsu=" + Namespaces.Uri + ";i=6002";
        /// <remarks />
        public const string http___OpcNodeSet2Server_NamespaceVersion = "nsu=" + Namespaces.Uri + ";i=6003";
        /// <remarks />
        public const string http___OpcNodeSet2Server_NamespacePublicationDate = "nsu=" + Namespaces.Uri + ";i=6001";
        /// <remarks />
        public const string http___OpcNodeSet2Server_IsNamespaceSubset = "nsu=" + Namespaces.Uri + ";i=6000";
        /// <remarks />
        public const string http___OpcNodeSet2Server_StaticNodeIdTypes = "nsu=" + Namespaces.Uri + ";i=6004";
        /// <remarks />
        public const string http___OpcNodeSet2Server_StaticNumericNodeIdRange = "nsu=" + Namespaces.Uri + ";i=6005";
        /// <remarks />
        public const string http___OpcNodeSet2Server_StaticStringNodeIdPattern = "nsu=" + Namespaces.Uri + ";i=6006";

        /// <summary>
        /// Converts a value to a name for display.
        /// </summary>
        public static string ToName(string value)
        {
            foreach (var field in typeof(VariableIds).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                if (field.GetValue(null).Equals(value))
                {
                    return field.Name;
                }
            }

            return value.ToString();
        }
    }
    
}