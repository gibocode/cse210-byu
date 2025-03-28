using System;

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsAddressInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetInfo()
    {
        return $"  {_name}\n{_address.GetFullAddress()}";
    }
}
