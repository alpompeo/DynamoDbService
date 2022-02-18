using DynamoDbService.Entity;

namespace DynamoDbService.Interfaces
{
    public interface IResultadointegracaoDynamoDb
    {
        Task<ResultadoIntegracaoEntity> GetIntegracaoCodigoSistema(Guid codigoIntegracao, string nomeSistemaIntegracao);
        Task<int?> GetStatusIntegracao(string codigoIntegracao, string nomeSistemaIntegracao);
        Task SaveIntegracaoCodigoSistema(ResultadoIntegracaoEntity resultadoIntegracao);
        Task DeleteIntegracao(ResultadoIntegracaoEntity resultadoIntegracao);
        Task<IEnumerable<ResultadoIntegracaoEntity>> Listar();
    }
}