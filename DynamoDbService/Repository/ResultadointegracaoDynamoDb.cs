using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using DynamoDbService.Entity;
using DynamoDbService.Interfaces;

namespace DynamoDbService.Repositories
{
    public class ResultadointegracaoDynamoDb : IResultadointegracaoDynamoDb
    {
        private IDynamoDbContext<ResultadoIntegracaoEntity> _context;

        public ResultadointegracaoDynamoDb(IDynamoDbContext<ResultadoIntegracaoEntity> context)
        {
            _context = context;
        }

        public async Task<ResultadoIntegracaoEntity> GetIntegracaoCodigoSistema(Guid codigoIntegracao, string nomeSistemaIntegracao)
        {
            //TODO: Exemplo utilizando Scan, mas não é performatico.
            //Utilzar somente quando não há um indice deficnido na tabela.
            //List<ScanCondition> conditions = new List<ScanCondition>();
            //conditions.Add(new ScanCondition("CodigoIntegracao", ScanOperator.Equal, codigoIntegracao));
            //conditions.Add(new ScanCondition("NomeSistemaIntegracao", ScanOperator.Equal, nomeSistemaIntegracao));
            //var result = await _context.ScanAsync(conditions);

            return (await _context.QueryAsync(codigoIntegracao.ToString(), QueryOperator.Equal, new object[] { nomeSistemaIntegracao })).SingleOrDefault();
        }

        public async Task<IEnumerable<ResultadoIntegracaoEntity>> Listar()
        {
            return (await _context.ScanAsync(new List<ScanCondition>())).ToList();
        }

        public async Task SaveIntegracaoCodigoSistema(ResultadoIntegracaoEntity resultadoIntegracao)
        {
            await _context.Save(resultadoIntegracao);
        }

        public async Task DeleteIntegracao(ResultadoIntegracaoEntity resultadoIntegracao)
        {
            await _context.DeleteByIdAsync(resultadoIntegracao);
        }

        public async Task<int?> GetStatusIntegracao(string codigoIntegracao)
        {
            var result = (await _context.QueryAsync(codigoIntegracao.ToString())).FirstOrDefault();

            return (int?)result?.CodigoStatusIntegracao;
        }
    }
}
