using NPoco;
using System.Collections.Generic;
using Projeto.BaseData.Domain;

namespace Projeto.BaseData.Function
{
    public class GenericDao<T>
    {
        public List<_Aluno> GetByTurma(int idTurma)
        {
            using (Database db = new NPoco.Database("Escola"))
            {
                return db.Fetch<_Aluno>("Where idTurma = idTurma", new { idTurma = idTurma });
            }
        }

        public List<_Nota> GetNotaByAluno(int Id)
        {
            using (Database db = new NPoco.Database("Escola"))
            {
                return db.Fetch<_Nota>("Where IdAluno = @IdAluno", new { IdAluno = Id });
            }
        }

        public virtual List<T> FetchAll()
        {
            using (Database db = new Database("Escola"))
            {
                return db.Fetch<T>();
            }
        }

        public T Get(long id)
        {
            using (Database db = new Database("Escola"))
            {
                return db.SingleOrDefaultById<T>(id);
            }
        }

        public T Insert(T objParam)
        {
            using (Database db = new NPoco.Database("Escola"))
            {
                db.Insert<T>(objParam);
                return objParam;
            }
        }

        public virtual T Update(T objParam)
        {
            using (Database db = new NPoco.Database("Escola"))
            {
                db.Update(objParam);
                return objParam;
            }
        }

        public void Delete(long Id)
        {
            using (Database db = new NPoco.Database("Escola"))
            {
                db.Delete<T>(Id);
            }
        }
    }
}
