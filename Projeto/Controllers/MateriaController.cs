using System.Collections.Generic;
using Projeto.BaseData.Function;
using Projeto.BaseData.Domain;
using System.Web.Http;

namespace Projeto.Controllers
{
    public class Materia
    {
        public long IdProfessor { get; set; }
        public long IdTurma { get; set; }
        public string Nome { get; set; }
    }

    [RoutePrefix("api/materia")]
    public class MateriaController : ApiController
    {
        [Route("get")]
        public string Get(int id)
        {
            var oMateriaData = new GenericDao<_Materia>();
            var materia = oMateriaData.Get(id);

            return materia.Nome;
        }

        [Route("getAll")]
        public List<_Materia> Get()
        {
            var oMateriaData = new GenericDao<_Materia>();
            var materia = oMateriaData.FetchAll();

            return materia;
        }

        [Route("post")]
        public string Post([FromBody] Materia materia)
        {
            var oMateriaData = new GenericDao<_Materia>();
            var materiaModel = new _Materia();
            materiaModel.IdProfessor = materia.IdProfessor;
            materiaModel.IdTurma = materia.IdTurma;
            materiaModel.Nome = materia.Nome;

            oMateriaData.Insert(materiaModel);

            return $"Matéria {materia.Nome} cadastrada com sucesso!";
        }

        [Route("update")]
        public string Put(int id, [FromBody] Materia materia)
        {
            var oMateriaData = new GenericDao<_Materia>();
            var materiaModel = new _Materia();
            materiaModel.Id = id;
            materiaModel.IdProfessor = materia.IdProfessor;
            materiaModel.IdTurma = materia.IdTurma;
            materiaModel.Nome = materia.Nome;

            oMateriaData.Update(materiaModel);

            return $"Matéria {materia.Nome} atualizada com sucesso!";
        }

        [Route("delete")]
        public string Delete(int id)
        {
            var oMateriaData = new GenericDao<_Materia>();
            oMateriaData.Delete(id);

            return "Matéria deletada com sucesso!";
        }
    }
}