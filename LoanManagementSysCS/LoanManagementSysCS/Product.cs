using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanManagementSys;


//Stores and handles data about a product (equipment) that
//can be loaned to members of the system
public class Product
{
    public string name;
    public string id;
    public string description;

    //Properties
    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                name = value;
            }
        }

    }

    public string ID
    {
        get { return id; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                id = value;
        }
    }
    public override string ToString()
    {
        return $"{name,-15} ID: {id}";
    }
}