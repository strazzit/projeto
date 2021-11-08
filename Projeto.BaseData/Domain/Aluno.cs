using NPoco;

namespace Projeto.BaseData.Domain
{
	[TableName("Aluno")]
	[PrimaryKey("Id", AutoIncrement = true)]
	public class _Aluno
	{
		public int Id { get; set; }
		public long IdTurma { get; set; }
		public string Nome { get; set; }
	}
}
