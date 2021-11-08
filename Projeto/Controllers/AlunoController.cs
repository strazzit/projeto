using System.Collections.Generic;
using Projeto.BaseData.Function;
using Projeto.BaseData.Domain;
using Projeto.Function;
using System.Web.Http;

namespace Projeto.Controllers
{
    public class Aluno
    {
        public int Id { get; set; }
        public long IdTurma { get; set; }
        public string Nome { get; set; }
        public bool Aprovado { get; set; }
    }

    [RoutePrefix("api/aluno")]
    public class AlunoController : ApiController
    {
        [Route("get")]
        public Aluno Get(int id)
        {
            var oAlunoData = new GenericDao<_Aluno>();
            var alunoModel = oAlunoData.Get(id);
            var aluno = new Aluno();
            aluno.Id = alunoModel.Id;
            aluno.IdTurma = alunoModel.IdTurma;
            aluno.Nome = alunoModel.Nome;
            aluno.Aprovado = new Aprovado().Get(id);

            return aluno;
        }

        [Route("getAll")]
        public List<Aluno> Get()
        {
            var oAlunoData = new GenericDao<_Aluno>();
            var aluno = oAlunoData.FetchAll();
            var alunoList = new List<Aluno>();

            foreach (var dado in aluno)
            {
                alunoList.Add(new Aluno
                {
                    Id = dado.Id,
                    IdTurma = dado.IdTurma,
                    Nome = dado.Nome,
                    Aprovado = new Aprovado().Get(dado.Id)
                });
            }

            return alunoList;
        }

        [Route("getByTurma")]
        public List<_Aluno> GetByTurma(int IdTurma)
        {
            var oAlunoData = new GenericDao<_Aluno>();
            var aluno = oAlunoData.GetByTurma(IdTurma);

            return aluno;
        }

        [Route("post")]
        public string Post([FromBody] Aluno aluno)
        {
            var oAlunoData = new GenericDao<_Aluno>();
            var alunoModel = new _Aluno();
            alunoModel.IdTurma = aluno.IdTurma;
            alunoModel.Nome = aluno.Nome;

            oAlunoData.Insert(alunoModel);

            return $"Aluno(a) {aluno.Nome} cadastrado com sucesso!";
        }

        [Route("update")]
        public string Put(int id, [FromBody] Aluno aluno)
        {
            var oAlunoData = new GenericDao<_Aluno>();
            var alunoModel = new _Aluno();
            alunoModel.Id = id;
            alunoModel.IdTurma = aluno.IdTurma;
            alunoModel.Nome = aluno.Nome;

            oAlunoData.Update(alunoModel);

            return $"Aluno(a) {aluno.Nome} atualizado com sucesso!";
        }

        [Route("delete")]
        public string Delete(int id)
        {
            var oAlunoData = new GenericDao<_Aluno>();
            oAlunoData.Delete(id);

            return "Aluno(a) deletado(a) com sucesso!";
        }
    }
}