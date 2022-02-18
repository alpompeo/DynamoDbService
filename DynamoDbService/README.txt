Pacotes nuget AWS
AWSSDK.DynamoDBv2
AWSSDK.Extensions.NETCore.Setup

1- Criar Docker AWS Dynamo Local
docker run -p 8042:8000 amazon/dynamodb-local -jar DynamoDBLocal.jar -inMemory -sharedDb

2- Criar Tabela
aws dynamodb --endpoint-url http://localhost:8042 create-table --table-name TBF8059_ITGR_PLAT_ELET --attribute-definitions AttributeName=COD_IDEF_ITGR,AttributeType=S AttributeName=NOM_SIS_ITGR,AttributeType=S  --key-schema AttributeName=COD_IDEF_ITGR,KeyType=HASH AttributeName=NOM_SIS_ITGR,KeyType=RANGE --provisioned-throughput ReadCapacityUnits=5,WriteCapacityUnits=5


3- Listar Tabelas
aws dynamodb list-tables --endpoint-url http://localhost:8042


{
    "TableDescription": {
        "AttributeDefinitions": [
            {
                "AttributeName": "COD_IDEF_ITGR",
                "AttributeType": "S"
            },
            {
                "AttributeName": "NOM_SIS_ITGR",
                "AttributeType": "S"
            }
        ],
        "TableName": "TBF8059_ITGR_PLAT_ELET",
        "KeySchema": [
            {
                "AttributeName": "COD_IDEF_ITGR",
                "KeyType": "HASH"
            },
            {
                "AttributeName": "NOM_SIS_ITGR",
                "KeyType": "RANGE"
            }
        ],
        "TableStatus": "ACTIVE",
        "CreationDateTime": "2022-02-18T07:53:39.626000-03:00",
        "ProvisionedThroughput": {
            "LastIncreaseDateTime": "1969-12-31T21:00:00-03:00",
            "LastDecreaseDateTime": "1969-12-31T21:00:00-03:00",
            "NumberOfDecreasesToday": 0,
            "ReadCapacityUnits": 5,
            "WriteCapacityUnits": 5
        },
        "TableSizeBytes": 0,
        "ItemCount": 0,
        "TableArn": "arn:aws:dynamodb:ddblocal:000000000000:table/TBF8059_ITGR_PLAT_ELET"
    }