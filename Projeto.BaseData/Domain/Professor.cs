using NPoco;

namespace Projeto.BaseData.Domain
{
	[TableName("Professor")]
	[PrimaryKey("Id", AutoIncrement = true)]
	public class _Professor
	{
		public int Id { get; set; }
		public string Nome { get; set; }
	}
}
