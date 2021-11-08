using System.Collections.Generic;
using Projeto.BaseData.Function;
using Projeto.BaseData.Domain;
using System.Web.Http;

namespace Projeto.Controllers
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    [RoutePrefix("api/professor")]
    public class ProfessorController : ApiController
    {
        [Route("get")]
        public Professor Get(int id)
        {
            var oProfessorData = new GenericDao<_Professor>();
            var professor = oProfessorData.Get(id);
            var prof = new Professor();
            prof.Id = professor.Id;
            prof.Nome = professor.Nome;

            return prof;
        }

        [Route("getAll")]
        public List<_Professor> Get()
        {
            var oProfessorData = new GenericDao<_Professor>();
            var prof = oProfessorData.FetchAll();

            return prof;
        }

        [Route("post")]
        public string Post([FromBody] Professor professor)
        {
            var oProfessorData = new GenericDao<_Professor>();
            var professorModel = new _Professor();
            professorModel.Nome = professor.Nome;
            oProfessorData.Insert(professorModel);

            return $"Professor(a) {professor.Nome} cadastrado com sucesso!";
        }

        [Route("update")]
        public string Put(int id, [FromBody] Professor professor)
        {
            var oProfessorData = new GenericDao<_Professor>();
            var professorModel = new _Professor();
            professorModel.Id = id;
            professorModel.Nome = professor.Nome;
            oProfessorData.Update(professorModel);

            return $"Professor(a) {professor.Nome} atualizado com sucesso!";
        }

        [Route("delete")]
        public string Delete(int id)
        {
            var oProfessorData = new GenericDao<_Professor>();
            oProfessorData.Delete(id);

            return "Professor(a) deletado(a) com sucesso!";
        }
    }
}