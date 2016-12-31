namespace Model
{
    public class Position
    {
        public int Id { get; set; }
        public int RowNum { get; set; }
        public int ColNum { get; set; }
        public byte PositionTypeId { get; set; }
        public bool UseAble { get; set; }
        public int LayoutId { get; set; }
        public string PositionTypeName { get; set; }
        public string LayoutStyle { get; set; }
    }
}
