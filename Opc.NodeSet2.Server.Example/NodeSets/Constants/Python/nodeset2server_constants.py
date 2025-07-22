from enum import Enum

class Namespaces(Enum):
     Uri = "http://OpcNodeSet2Server"

class BrowseNames(Enum):
    Create_demo_structure = "Create demo structure"
    Demo = "Demo"
    Demo_structures = "Demo structures"
    DemoStructure = "DemoStructure"
    Hello_world = "Hello world"
    http___OpcNodeSet2Server = "http://OpcNodeSet2Server"
    Latest_demo_structure = "Latest demo structure"
    Modeling_Editor = "Modeling Editor"
    Validate_demo_structure = "Validate demo structure"

class DataTypeIds(Enum):
    DemoStructure = "nsu=http://OpcNodeSet2Server;i=3000"

def get_DataTypeIds_name(value: str) -> str:
    try:
        return DataTypeIds(value).name
    except ValueError:
        return None


class ObjectIds(Enum):
    http___OpcNodeSet2Server = "nsu=http://OpcNodeSet2Server;i=5000"
    Demo = "nsu=http://OpcNodeSet2Server;i=5001"
    DemoStructure_Encoding_DefaultBinary = "nsu=http://OpcNodeSet2Server;i=5002"
    DemoStructure_Encoding_DefaultXml = "nsu=http://OpcNodeSet2Server;i=5003"

def get_ObjectIds_name(value: str) -> str:
    try:
        return ObjectIds(value).name
    except ValueError:
        return None


class VariableIds(Enum):
    http___OpcNodeSet2Server_NamespaceUri = "nsu=http://OpcNodeSet2Server;i=6002"
    http___OpcNodeSet2Server_NamespaceVersion = "nsu=http://OpcNodeSet2Server;i=6003"
    http___OpcNodeSet2Server_NamespacePublicationDate = "nsu=http://OpcNodeSet2Server;i=6001"
    http___OpcNodeSet2Server_IsNamespaceSubset = "nsu=http://OpcNodeSet2Server;i=6000"
    http___OpcNodeSet2Server_StaticNodeIdTypes = "nsu=http://OpcNodeSet2Server;i=6004"
    http___OpcNodeSet2Server_StaticNumericNodeIdRange = "nsu=http://OpcNodeSet2Server;i=6005"
    http___OpcNodeSet2Server_StaticStringNodeIdPattern = "nsu=http://OpcNodeSet2Server;i=6006"

def get_VariableIds_name(value: str) -> str:
    try:
        return VariableIds(value).name
    except ValueError:
        return None

