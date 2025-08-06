namespace ApiProjeKampUI.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }//? boş geçilebilir demek, nullable

        public string CategoryName { get; set; }

    }
}
