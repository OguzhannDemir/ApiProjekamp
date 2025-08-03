using ApiProjeKamp.WebApi.Entities;
using FluentValidation;

namespace ApiProjeKamp.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {

        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün Adı Boş Geçilemez.");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ürün Adı En Az 2 Karakter Olmalıdır.");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("Ürün Adı En Fazla 50 Karakter Olmalıdır.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün Fiyatı Boş Geçilemez.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Ürün Fiyatı 0'dan Büyük Olmalıdır.");

        }


    }
}
