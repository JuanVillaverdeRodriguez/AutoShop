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
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.Card = new HashSet<Card>();
        }
    
        public long userId { get; set; }
        public string user_name { get; set; }
        public string user_surname { get; set; }
        public string email { get; set; }
        public string alias { get; set; }
        public string password { get; set; }
        public string language { get; set; }
        public long workshopId { get; set; }
    
        
        /// <summary>
        /// Relationship Name (Foreign Key in ER-Model): FK_Card_Usuario
        /// </summary>
        public virtual ICollection<Card> Card { get; set; }
        
        /// <summary>
        /// Relationship Name (Foreign Key in ER-Model): FK_Usuario_Workshop
        /// </summary>
        public virtual Workshop Workshop { get; set; }
    
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
    
    			hash = hash * multiplier + (user_name == null ? 0 : user_name.GetHashCode());
    			hash = hash * multiplier + (user_surname == null ? 0 : user_surname.GetHashCode());
    			hash = hash * multiplier + (email == null ? 0 : email.GetHashCode());
    			hash = hash * multiplier + (alias == null ? 0 : alias.GetHashCode());
    			hash = hash * multiplier + (password == null ? 0 : password.GetHashCode());
    			hash = hash * multiplier + (language == null ? 0 : language.GetHashCode());
    			hash = hash * multiplier + workshopId.GetHashCode();
    
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
    
            Usuario target = obj as Usuario;
    
    		return true
               &&  (this.userId == target.userId )       
               &&  (this.user_name == target.user_name )       
               &&  (this.user_surname == target.user_surname )       
               &&  (this.email == target.email )       
               &&  (this.alias == target.alias )       
               &&  (this.password == target.password )       
               &&  (this.language == target.language )       
               &&  (this.workshopId == target.workshopId )       
               ;
    
        }
    
    
    	public static bool operator ==(Usuario  objA, Usuario  objB)
        {
            // Check if the objets are the same Usuario entity
            if(Object.ReferenceEquals(objA, objB))
                return true;
      
            return objA.Equals(objB);
    }
    
    
    	public static bool operator !=(Usuario  objA, Usuario  objB)
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
    	    StringBuilder strUsuario = new StringBuilder();
    
    		strUsuario.Append("[ ");
           strUsuario.Append(" userId = " + userId + " | " );       
           strUsuario.Append(" user_name = " + user_name + " | " );       
           strUsuario.Append(" user_surname = " + user_surname + " | " );       
           strUsuario.Append(" email = " + email + " | " );       
           strUsuario.Append(" alias = " + alias + " | " );       
           strUsuario.Append(" password = " + password + " | " );       
           strUsuario.Append(" language = " + language + " | " );       
           strUsuario.Append(" workshopId = " + workshopId + " | " );       
            strUsuario.Append("] ");    
    
    		return strUsuario.ToString();
        }
    
    
    }
}
