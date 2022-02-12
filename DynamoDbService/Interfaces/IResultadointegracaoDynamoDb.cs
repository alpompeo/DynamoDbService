using DynamoDbService.Entity;

namespace DynamoDbService.Interfaces
{
    public interface IResultadointegracaoDynamoDb
    {
        Task<ResultadoIntegracaoEntity> GetIntegracaoCodigoSistema(string codigoIntegracao, string nomeSistemaIntegracao);

        Task<int> VerificaExisteIntegracao(string codigoIntegracao);

        Task SaveIntegracaoCodigoSistema(ResultadoIntegracaoEntity resultadoIntegracao);

        Task DeleteIntegracao(ResultadoIntegracaoEntity resultadoIntegracao);
    }
}