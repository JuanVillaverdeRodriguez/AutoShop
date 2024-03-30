//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Es.Udc.DotNet.PracticaMaD.Model
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.Property = new HashSet<Property>();
        }
    
        public long productId { get; set; }
        public string name { get; set; }
        public double prize { get; set; }
        public System.DateTime date { get; set; }
        public int stock { get; set; }
        public long categoryId { get; set; }
    
        
        /// <summary>
        /// Relationship Name (Foreign Key in ER-Model): FK_Product_Category
        /// </summary>
        public virtual Category Category { get; set; }
        
        /// <summary>
        /// Relationship Name (Foreign Key in ER-Model): FK_Property_Product
        /// </summary>
        public virtual ICollection<Property> Property { get; set; }
    
    	/// <summary>
    	/// A hash code for this instance, suitable for use in hashing algorithms and data structures 
    	/// like a hash table. It uses the Josh Bloch implementation from "Effective Java"
        /// Primary key of entity is not included in the hash calculation to avoid errors
    	/// with Entity Framework creation of key values.
    	/// </summary>
    	/// <returns>
    	/// Returns a hash code for this instance.
    	/// </returns>
    	public override int GetHashCode()
    	{
    	    unchecked
    	    {
    			int multiplier = 31;
    			int hash = GetType().GetHashCode();
    
    			hash = hash * multiplier + (name == null ? 0 : name.GetHashCode());
    			hash = hash * multiplier + prize.GetHashCode();
    			hash = hash * multiplier + date.GetHashCode();
    			hash = hash * multiplier + stock.GetHashCode();
    			hash = hash * multiplier + categoryId.GetHashCode();
    
    			return hash;
    	    }
    
    	}
        
        /// <summary>
        /// Compare this object against another instance using a value approach (field-by-field) 
        /// </summary>
        /// <remarks>See http://www.loganfranken.com/blog/687/overriding-equals-in-c-part-1/ for detailed info </remarks>
    	public override bool Equals(object obj)
    	{
    
            if (ReferenceEquals(null, obj)) return false;        // Is Null?
            if (ReferenceEquals(this, obj)) return true;         // Is same object?
            if (obj.GetType() != this.GetType()) return false;   // Is same type? 
    
            Product target = obj as Product;
    
    		return true
               &&  (this.productId == target.productId )       
               &&  (this.name == target.name )       
               &&  (this.prize == target.prize )       
               &&  (this.date == target.date )       
               &&  (this.stock == target.stock )       
               &&  (this.categoryId == target.categoryId )       
               ;
    
        }
    
    
    	public static bool operator ==(Product  objA, Product  objB)
        {
            // Check if the objets are the same Product entity
            if(Object.ReferenceEquals(objA, objB))
                return true;
      
            return objA.Equals(objB);
    }
    
    
    	public static bool operator !=(Product  objA, Product  objB)
        {
            return !(objA == objB);
        }
    
    
        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the 
        /// current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current 
        /// <see cref="T:System.Object"></see>.
        /// </returns>
    	public override String ToString()
    	{
    	    StringBuilder strProduct = new StringBuilder();
    
    		strProduct.Append("[ ");
           strProduct.Append(" productId = " + productId + " | " );       
           strProduct.Append(" name = " + name + " | " );       
           strProduct.Append(" prize = " + prize + " | " );       
           strProduct.Append(" date = " + date + " | " );       
           strProduct.Append(" stock = " + stock + " | " );       
           strProduct.Append(" categoryId = " + categoryId + " | " );       
            strProduct.Append("] ");    
    
    		return strProduct.ToString();
        }
    
    
    }
}
