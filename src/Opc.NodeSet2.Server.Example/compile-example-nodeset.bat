:: Ensure that the model compiler is set in the environment variables!

Opc.Ua.ModelCompiler compile ^
-version v105 ^
-d2 ./NodeSets/Example.NodeSet2.xml,NodeSet2Server,NodeSet2Server ^
-cg ./NodeSets/example.csv ^
-o2 ./NodeSets