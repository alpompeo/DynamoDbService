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
        [Route("integracao")]
        public async Task<IEnumerable<ResultadoIntegracaoEntity>> Get()
        {
            try
            {
                return await _repository.Listar();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("integracao/Status/{codigoIntegracao}")]
        public async Task<int?> Get(string codigoIntegracao)
        {
            try
            {
                return await _repository.GetStatusIntegracao(codigoIntegracao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("integracao/{codigoIntegracao}/{nomeSistemaIntegracao}")]
        public async Task<ResultadoIntegracaoEntity> Get(Guid codigoIntegracao, string nomeSistemaIntegracao)
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

        [HttpPost]
        [Route("integracao/add")]
        public async Task<ResultadoIntegracaoEntity> Insert()
        {
            try
            {
                var item = new ResultadoIntegracaoEntity()
                {
                    CodigoIntegracao = Guid.NewGuid(),
                    NomeSistemaIntegracao = "SISTEMA_" + new Random().Next(),
                    TextoIntegracaoResultado = "TEXTO_" + new Random().Next(),
                    CodigoStatusIntegracao = EnumResultadoIntegracao.INTEGRACAO_INICIADA
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
        public async Task<ResultadoIntegracaoEntity> Update(Guid codigoIntegracao, string nomeSistemaIntegracao)
        {
            try
            {
                var item = new ResultadoIntegracaoEntity()
                {
                    CodigoIntegracao = codigoIntegracao,
                    NomeSistemaIntegracao = nomeSistemaIntegracao,
                    TextoIntegracaoResultado = "TEXTO_" + new Random().Next()
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
        public async Task Delete(Guid codigoIntegracao, string nomeSistemaIntegracao)
        {
            try
            {
                var obj = await _repository.GetIntegracaoCodigoSistema(codigoIntegracao, nomeSistemaIntegracao);

                if (obj == null)
                    throw new Exception("Não foi encontrado a integração.");

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