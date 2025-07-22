export const NS = 'http://OpcNodeSet2Server';

export class BrowseNames {
   static readonly CallMe: string = 'CallMe'
   static readonly CallMe2: string = 'CallMe2'
   static readonly Demo: string = 'Demo'
   static readonly Demo_Structure: string = 'Demo Structure'
   static readonly DemoStructure: string = 'DemoStructure'
   static readonly http___OpcNodeSet2Server: string = 'http://OpcNodeSet2Server'
   static readonly Modeling_Editor: string = 'Modeling Editor'
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
