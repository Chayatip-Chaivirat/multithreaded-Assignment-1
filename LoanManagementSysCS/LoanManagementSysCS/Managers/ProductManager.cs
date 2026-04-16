using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSys
{
    /// <summary>
    /// 
    ///This class administers a list of products, adding a new object,
    ///removing an existing, etc.  The list contains products that are 
    ///available for loan.  When a product is loaned by a member the 
    ///product is removed from this list and placed in the LoanItenmList,
    ///and when returned, the object is added to the list again.
    /// </summary>
    internal class ProductManager
    {
        private List<Product> products = new();
        public List<LoanItem> retuns = new();
        public List<Product> allProductAdded = new(); 

        //Products receive an Id starting from 100 and then
        //everytime a new product is created, the id is
        //incremented.
        private int lastProductID = 100;

        /// <summary>
        /// Returns a product at a position = index in the list
        /// </summary>
        /// <param name="index">The position of the element in the list.</param>
        /// <returns></returns>
        public Product Get(int index)
        {
            if (CheckIndex(index))
                return products[index];
            else
                return null;
        }
        /// <summary>
        /// Adds a given product at the end of the list
        /// </summary>
        /// <param name="product"></param>
        public void Add(Product product)
        {
            products.Add(product);
        }
        /// <summary>
        /// Removes a product from a position = index from
        /// the list
        /// </summary>
        /// <param name="index">Position of the elment in the list.</param>
        public void Remove(int index, List<LoanItem> returnItems)
        {
            // Remove the product at the given index when it is loaned out.
            // The returnItems parameter is not needed here but kept to match
            // existing callers in the codebase.
            if (CheckIndex(index))
            {
                products.RemoveAt(index);   
            }
        }
        /// <summary>
        /// Return the number of elements in the list
        /// </summary>
        public int Count
        {
            get { return products.Count; }
        }
        /// <summary>
        /// Validate the given index so it is not out of range.
        /// </summary>
        /// <param name="index">Index to be validated.</param>
        /// <returns></returns>
        private bool CheckIndex(int index)
        {
            return (index >= 0) && (index < products.Count);
        }


        //Preapare and return a string array where each element contains
        //information about the loanObject, calling the object's
        //toString metod.  The return array can then be used to update
        //the GUI on the related view.
        public String[] GetProductInfoStrings()
        {
            if ((products == null) || (products.Count <= 0))
                return new string[] { "Products available: ", " " };

            //Create an array with a size equal to the number of items in the list.
            //one extra lines for the title, size and a blank line.
            String[] infoStrings = new string[products.Count + 3]; //See (x)

            infoStrings[0] = $"Number of products availabale: {products.Count}"; //(1)
            infoStrings[1] = "";  //(2)
            int j = 2;

            //Fill the list with info on each element, using the object's toString
            //method.
            for (int i = 0; i < products.Count(); i++)
                infoStrings[j++] = products[i].ToString();

            infoStrings[infoStrings.Length - 1] = "";  //(3)
            return infoStrings;
        }

        public String[] GetAddedProductInfoStrings()
        {
            String[] infoStrings = new string[allProductAdded.Count];
            for (int i = 0; i < allProductAdded.Count(); i++)
                infoStrings[i] = allProductAdded[i].AddedToString();
            return infoStrings;
        }

        //Fill the list with some test objects.
        public void AddTestProducts()
        {
            for (int i = 0; i < 15; i++)
            {
                AddNewTestProduct();
            }
        }

        //Return true if the list of items is empty, an thus no product available for loaning.
        public bool NoProductsAvailable()
        {
            return (products == null) || (products.Count <= 0);
        }

        //This method is called for adding a new tests object in the list.
        public Product AddNewTestProduct()
        {
            Product product = new Product(); // Assume Product constructor and methods are defined elsewhere
            product.ID = lastProductID.ToString();
            product.Name = $"Product{lastProductID++}";
            products.Add(product);
            return product;
        }

    }
}
