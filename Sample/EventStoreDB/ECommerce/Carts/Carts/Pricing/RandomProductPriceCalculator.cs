using Carts.ShoppingCarts.Products;

namespace Carts.Pricing;

public class RandomProductPriceCalculator: IProductPriceCalculator
{
    public IReadOnlyList<PricedProductItem> Calculate(params ProductItem[] productItems)
    {
        if (productItems.Length == 0)
            throw new ArgumentOutOfRangeException(nameof(productItems.Length));

        var random = new Random();

        return productItems
            .Select(pi =>
                PricedProductItem.From(pi, (decimal)random.NextDouble() * 100))
            .ToList();
    }
}
