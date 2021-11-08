using NPoco;

namespace Projeto.BaseData.Domain
{
	[TableName("Nota")]
	[PrimaryKey("Id", AutoIncrement = true)]
	public class _Nota
	{
		public long Id { get; set; }
		public long IdProfessor { get; set; }
		public long IdAluno { get; set; }
		public long Nota { get; set; }
	}
}
