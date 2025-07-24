export const NS = 'http://OpcNodeSet2Server';

export class BrowseNames {
   static readonly Create_demo_structure: string = 'Create demo structure'
   static readonly Demo: string = 'Demo'
   static readonly Demo_structures: string = 'Demo structures'
   static readonly DemoStructure: string = 'DemoStructure'
   static readonly Hello_world: string = 'Hello world'
   static readonly http___OpcNodeSet2Server: string = 'http://OpcNodeSet2Server'
   static readonly Latest_demo_structure: string = 'Latest demo structure'
   static readonly Modeling_Editor: string = 'Modeling Editor'
   static readonly Validate_demo_structure: string = 'Validate demo structure'
}

export class DataTypeIds {
    static readonly DemoStructure: string = 'nsu=' + NS + ';i=3000'
}

export class ObjectIds {
    static readonly http___OpcNodeSet2Server: string = 'nsu=' + NS + ';i=5000'
    static readonly Demo: string = 'nsu=' + NS + ';i=5001'
    static readonly DemoStructure_Encoding_DefaultBinary: string = 'nsu=' + NS + ';i=5002'
    static readonly DemoStructure_Encoding_DefaultXml: string = 'nsu=' + NS + ';i=5003'
}

export class VariableIds {
    static readonly http___OpcNodeSet2Server_NamespaceUri: string = 'nsu=' + NS + ';i=6002'
    static readonly http___OpcNodeSet2Server_NamespaceVersion: string = 'nsu=' + NS + ';i=6003'
    static readonly http___OpcNodeSet2Server_NamespacePublicationDate: string = 'nsu=' + NS + ';i=6001'
    static readonly http___OpcNodeSet2Server_IsNamespaceSubset: string = 'nsu=' + NS + ';i=6000'
    static readonly http___OpcNodeSet2Server_StaticNodeIdTypes: string = 'nsu=' + NS + ';i=6004'
    static readonly http___OpcNodeSet2Server_StaticNumericNodeIdRange: string = 'nsu=' + NS + ';i=6005'
    static readonly http___OpcNodeSet2Server_StaticStringNodeIdPattern: string = 'nsu=' + NS + ';i=6006'
}
