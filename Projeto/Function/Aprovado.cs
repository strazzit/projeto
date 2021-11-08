using Projeto.Controllers;

namespace Projeto.Function
{
    public class Aprovado
    {
        public bool Get(int id)
        {
            var notasAluno = new NotaController().GetNotaAluno(id);
            var aprovado = false;
            long soma = 0;
            var count = 0;

            foreach (var dado in notasAluno)
            {
                soma = soma + dado.Nota;
                count++;
            }

            if (count != 0)
            {
                var media = soma / count;
                _ = media >= 5 ? aprovado = true : aprovado = false;
            }

            return aprovado;
        }
    }
}