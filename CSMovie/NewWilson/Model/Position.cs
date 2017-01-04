namespace Model
{
    public class Position
    {
        public Position()
        {
        }
        public Position(int r, int c)
        {
            this.RowNum = r;
            this.ColNum = c;
        }
        public int Id { get; set; }
        public int RowNum { get; set; }
        public int ColNum { get; set; }
        public byte PositionTypeId { get; set; }
        public bool UseAble { get; set; }
        public int LayoutId { get; set; }
        public string PositionTypeName { get; set; }
        public string LayoutStyle { get; set; }

        public string GetMessagePoint()
        {
            return this.RowNum + "排" + ColNum + "座";
        }

        public override string ToString()
        {
            if (UseAble)
                return PositionTypeName;
            else
            {
                return "不可用";
            }
        }
    }
}
