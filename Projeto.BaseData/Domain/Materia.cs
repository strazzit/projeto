using NPoco;

namespace Projeto.BaseData.Domain
{
	[TableName("Materia")]
	[PrimaryKey("Id", AutoIncrement = true)]
	public class _Materia
	{
		public long Id { get; set; }
		public long IdProfessor { get; set; }
		public long IdTurma { get; set; }
		public string Nome { get; set; }
	}
}
