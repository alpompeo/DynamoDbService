using Amazon.DynamoDBv2.DataModel;

namespace DynamoDbService.Entity
{
    [DynamoDBTable("TBF8059_ITGR_PLAT_ELET")]
    public class ResultadoIntegracaoEntity
    {
        [DynamoDBHashKey("COD_IDEF_ITGR")]//, typeof(GuidTypeConverter))]
        public string CodigoIntegracao { get; set; }

        [DynamoDBProperty("NOM_SIS_ITGR")]
        public string NomeSistemaIntegracao { get; set; }

        [DynamoDBProperty("TXT_ITGR_RESU")]
        public string TestoIntegracaoResultado { get; set; }

    }
}