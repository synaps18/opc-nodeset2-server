export const NS = 'http://OpcNodeSet2Server';

export const BrowseNames = Object.freeze({
   CallMe: 'CallMe',
   CallMe2: 'CallMe2',
   Demo: 'Demo',
   Demo_Structure: 'Demo Structure',
   DemoStructure: 'DemoStructure',
   http___OpcNodeSet2Server: 'http://OpcNodeSet2Server',
   Modeling_Editor: 'Modeling Editor',
});

export const DataTypeIds = Object.freeze({
   DemoStructure: 'nsu=' + NS + ';i=3000',
});

export const ObjectIds = Object.freeze({
   http___OpcNodeSet2Server: 'nsu=' + NS + ';i=5000',
   Demo: 'nsu=' + NS + ';i=5001',
   DemoStructure_Encoding_DefaultBinary: 'nsu=' + NS + ';i=5002',
   DemoStructure_Encoding_DefaultXml: 'nsu=' + NS + ';i=5003',
});

export const VariableIds = Object.freeze({
   http___OpcNodeSet2Server_NamespaceUri: 'nsu=' + NS + ';i=6002',
   http___OpcNodeSet2Server_NamespaceVersion: 'nsu=' + NS + ';i=6003',
   http___OpcNodeSet2Server_NamespacePublicationDate: 'nsu=' + NS + ';i=6001',
   http___OpcNodeSet2Server_IsNamespaceSubset: 'nsu=' + NS + ';i=6000',
   http___OpcNodeSet2Server_StaticNodeIdTypes: 'nsu=' + NS + ';i=6004',
   http___OpcNodeSet2Server_StaticNumericNodeIdRange: 'nsu=' + NS + ';i=6005',
   http___OpcNodeSet2Server_StaticStringNodeIdPattern: 'nsu=' + NS + ';i=6006',
});
