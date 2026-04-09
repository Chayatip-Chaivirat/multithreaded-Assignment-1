using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanManagementSys;

/// <summary>
/// Class that represents a loan item.  Each loan item has an object of the

/// Product class and an object of the Member class.  The member is the
/// object that loans the product. More attributes like "description,
/// loan date, return date" can be added as optional features.
/// </summary>

public class LoanItem
{
    private Product product;
    private Member member;

    private String description;

    public LoanItem(Product product, Member member)
    {
        this.product = product;
        this.member = member;
    }
    public Product Product
    {
        get { return product; }
        set { product = value; }
    }
   
    public Member Member
    {
        get { return member; }
        set { member = value; }
    }

    //The toString method retuning a textual representation of the
    //object's values.
    public override String ToString()
    {
        string? memberStr = (member != null) ? "Loaned to  " + member.ToString() :  string.Empty;
        return $"{product.ToString()} {memberStr}";
    }
}



