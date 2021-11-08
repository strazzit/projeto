using System.Collections.Generic;
using Projeto.BaseData.Function;
using Projeto.BaseData.Domain;
using System.Web.Http;

namespace Projeto.Controllers
{
    public class Grade
    {
        public int Id { get; set; }
        public long IdProfessor { get; set; }
        public long IdAluno { get; set; }
        public long Nota { get; set; }
    }

    [RoutePrefix("api/nota")]
    public class NotaController : ApiController
    {
        [Route("getByAluno")]
        public List<_Nota> GetNotaAluno(int id)
        {
            var oNotaData = new GenericDao<_Nota>();
            var aluno = oNotaData.GetNotaByAluno(id);

            return aluno;
        }

        [Route("post")]
        public string Post([FromBody] Grade grade)
        {
            var oNotaData = new GenericDao<_Nota>();
            var notaModel = new _Nota();
            notaModel.IdAluno = grade.IdAluno;
            notaModel.IdProfessor = grade.IdProfessor;
            notaModel.Nota = grade.Nota;
            oNotaData.Insert(notaModel);

            var aluno = new GenericDao<_Aluno>().Get(grade.IdAluno).Nome;

            return $"Nota para aluno(a) {aluno} postada com sucesso!";
        }

        [Route("update")]
        public string Put(int id, [FromBody] Grade grade)
        {
            var oNotaData = new GenericDao<_Nota>();
            var notaModel = new _Nota();
            notaModel.Id = id;
            notaModel.IdAluno = grade.IdAluno;
            notaModel.IdProfessor = grade.IdProfessor;
            notaModel.Nota = grade.Nota;
            oNotaData.Update(notaModel);

            var aluno = new GenericDao<_Aluno>().Get(grade.IdAluno).Nome;

            return $"Nota para aluno(a) {aluno} atualizada com sucesso!";
        }

        [Route("delete")]
        public string Delete(int id)
        {
            var oNotaData = new GenericDao<_Nota>();
            oNotaData.Delete(id);

            return "Nota deletada com sucesso!";
        }
    }
}