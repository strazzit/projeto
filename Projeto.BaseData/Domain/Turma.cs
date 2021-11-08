using NPoco;

namespace Projeto.BaseData.Domain
{
	[TableName("Turma")]
	[PrimaryKey("Id", AutoIncrement = true)]
	public class _Turma
	{
		public long Id { get; set; }
		public string Nome { get; set; }
	}
}
