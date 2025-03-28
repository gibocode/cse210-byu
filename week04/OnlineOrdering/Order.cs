using System;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0;

        foreach (Product product in _products)
        {
            totalPrice += product.GetTotalCost();
        }

        totalPrice += GetShippingCost();

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";

        foreach (Product product in _products)
        {
            packingLabel += $"  {product.GetInfo()}\n";
        }

        return $"Packing Label:\n{packingLabel}";
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetInfo()}";
    }

    private double GetShippingCost()
    {
        return _customer.IsAddressInUSA() ? 5 : 35;
    }
}
