using Application.GraphQL;
using Application.UseCases;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly GraphQlSchema _schema;

        public GraphQLController(GraphQlSchema schema) 
        {
            _schema = schema;
        }
           
        [HttpPost()]
        public async Task<IActionResult> PostTransaction([FromBody] GraphQLQuery query)
        {
            var schema = _schema;

            var result = await new DocumentExecuter().ExecuteAsync(execute =>
            {
                execute.Schema = schema;
                execute.Query = query.Query;
                execute.OperationName = query.OperationName;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
