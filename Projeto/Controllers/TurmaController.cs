using System.Collections.Generic;
using Projeto.BaseData.Function;
using Projeto.BaseData.Domain;
using System.Web.Http;

namespace Projeto.Controllers
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    [RoutePrefix("api/turma")]
    public class TurmaController : ApiController
    {
        [Route("get")]
        public string Get(int id)
        {
            var oTurmaData = new GenericDao<_Turma>();
            var turma = oTurmaData.Get(id);

            return turma.Nome;
        }

        [Route("getAll")]
        public List<_Turma> Get()
        {
            var oTurmaData = new GenericDao<_Turma>();
            var turma = oTurmaData.FetchAll();

            return turma;
        }

        [Route("post")]
        public string Post([FromBody] Turma turma)
        {
            var oTurmaData = new GenericDao<_Turma>();
            var turmaModel = new _Turma();
            turmaModel.Nome = turma.Nome;
            oTurmaData.Insert(turmaModel);

            return $"Turma '{turma.Nome}' adicionada com sucesso!";
        }

        [Route("update")]
        public string Put(int id, [FromBody] Turma turma)
        {
            var oTurmaData = new GenericDao<_Turma>();
            var turmaModel = new _Turma();
            turmaModel.Id = id;
            turmaModel.Nome = turma.Nome;
            oTurmaData.Update(turmaModel);

            return $"Turma '{turma.Nome}' atualizada com sucesso!";
        }

        [Route("delete")]
        public string Delete(int id)
        {
            var oTurmaData = new GenericDao<_Turma>();
            oTurmaData.Delete(id);
            return "Turma deletada com sucesso!";
        }
    }
}