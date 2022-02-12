using DynamoDbService.Entity;
using DynamoDbService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DynamoDbService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DynamoDbController : ControllerBase
    {
        private IResultadointegracaoDynamoDb _repository;
        private readonly ILogger<DynamoDbController> _logger;

        public DynamoDbController(ILogger<DynamoDbController> logger,
                                  IResultadointegracaoDynamoDb repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("integracao/{codigoIntegracao}/{nomeSistemaIntegracao}")]
        public async Task<ResultadoIntegracaoEntity> Get(string codigoIntegracao, string nomeSistemaIntegracao)
        {
            try
            {
                return await _repository.GetIntegracaoCodigoSistema(codigoIntegracao, nomeSistemaIntegracao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("integracao/Exists/{codigoIntegracao}")]
        public async Task<int> Exists(string codigoIntegracao)
        {
            try
            {
                return await _repository.VerificaExisteIntegracao(codigoIntegracao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("integracao/add")]
        public async Task<ResultadoIntegracaoEntity> Add()
        {
            try
            {
                var item = new ResultadoIntegracaoEntity()
                {
                    CodigoIntegracao = Guid.NewGuid().ToString(),
                    NomeSistemaIntegracao = "SISTEMA_" + new Random().Next(),
                    TestoIntegracaoResultado = "TEXTO_" + new Random().Next()
                };

                await _repository.SaveIntegracaoCodigoSistema(item);

                return await _repository.GetIntegracaoCodigoSistema(item.CodigoIntegracao, item.NomeSistemaIntegracao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPut]
        [Route("integracao/update/{codigoIntegracao}/{nomeSistemaIntegracao}")]
        public async Task<ResultadoIntegracaoEntity> Update(string codigoIntegracao, string nomeSistemaIntegracao)
        {
            try
            {
                var item = new ResultadoIntegracaoEntity()
                {
                    CodigoIntegracao = codigoIntegracao,
                    NomeSistemaIntegracao = nomeSistemaIntegracao,
                    TestoIntegracaoResultado = "TEXTO_" + new Random().Next()
                };

                await _repository.SaveIntegracaoCodigoSistema(item);

                return await _repository.GetIntegracaoCodigoSistema(item.CodigoIntegracao, item.NomeSistemaIntegracao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpDelete]
        [Route("integracao/delete/{codigoIntegracao}/{nomeSistemaIntegracao}")]
        public async Task Delete(string codigoIntegracao, string nomeSistemaIntegracao)
        {
            try
            {
                var obj = await _repository.GetIntegracaoCodigoSistema(codigoIntegracao, nomeSistemaIntegracao);

                if (obj == null)
                    throw new Exception("Ñão foi encontrado o codigo de integração.");

                await _repository.DeleteIntegracao(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}