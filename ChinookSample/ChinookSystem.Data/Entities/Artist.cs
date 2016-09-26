using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace ChinookSystem.Data.Entities
{
    //point to the sql table that this file maps
    [Table("Artists")]
    public class Artist
    {
        //Key notation is optional if the sql pKey ends in ID or Id. Required if default of entity is Not Identity. Required if pKey is compound.

        //Properties can be fully implemented or auto implemented. Property names should use sql attribute name. Properties should be listed in the same order as sql table attributes for easy of maintenance.
        [Key]
        public int ArtistId { get; set; }
        public string Name { get; set; }

        //Navigation properties for use by Linq. These properties will by of type virtural
        //There are 2 types of navigation properties. Properties that point tot "children" use ICollection<T>. Properties that point to "Parent" use ParentName as the data type
        public virtual ICollection<Album> Albums { get; set; }
    }
}
