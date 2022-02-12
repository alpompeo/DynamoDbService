//Pacotes nuget AWS
//AWSSDK.DynamoDBv2
//AWSSDK.Extensions.NETCore.Setup

//1- Criar Docker AWS Dynamo Local
//docker run -p 8042:8000 amazon/dynamodb-local -jar DynamoDBLocal.jar -inMemory -sharedDb

//2- Criar Tabela
//aws dynamodb --endpoint-url http://localhost:8042 create-table --table-name TBF8059_ITGR_PLAT_ELET --attribute-definitions AttributeName=COD_IDEF_ITGR,AttributeType=S --key-schema AttributeName=COD_IDEF_ITGR,KeyType=HASH --provisioned-throughput ReadCapacityUnits=5,WriteCapacityUnits=5

//3- Listar Tabelas
//aws dynamodb list-tables --endpoint-url http://localhost:8042
