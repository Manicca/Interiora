namespace Models
{
    public class Furniture
    {
        public int FurnitureId { get; set; }
        public string Type { get; set; }
        public string Article { get; set; }
        public string Cost { get; set; }
        public string Params { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public Furniture() { }
        public Furniture(string type, string article, string cost, string Params, int supplierId)
        {
            Article = article;
            Cost = cost;
            this.Params = Params;
            SupplierId = supplierId;
        }
    }
}
