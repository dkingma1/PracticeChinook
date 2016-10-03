using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region AdditionalNamspaces
using System.ComponentModel;
using ChinookSystem.Data.Entities;
using ChinookSystem.Data.POCOs;
using ChinookSystem.DAL;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class ArtistController
    {
        //Dump the entire artist entity. This will use Entity Framework access. Entity classes will be used to define the data
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Artist> Artist_ListAll()
        {
            //Set up transaction area
            using (var context = new ChinookContext())
            {
                return context.Artists.ToList();
            }
        }

        //Report a data set containing data from multiple entities(tables), this will use link to entity access. POCO classes will be used to define the data. This will use Entity Framework access. Entity classes will be used to define the data
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbum> ArtistAlbums_Get()
        {
            //Set up transaction area
            using (var context = new ChinookContext())
            {
                //where bringing over a query from LinqPad you must change the reference(s) to the data source
                //you may also need to change your navigation refrencing used in LinqPad to the navigation properties you stated in the entity class definitions
                var results = from x in context.Albums where x.ReleaseYear == 2008 orderby x.Artist.Name, x.Title select new ArtistAlbum { Name = x.Artist.Name, Title = x.Title };
                //the following requires the query data in memory
                // .ToList()
                //At this point the query will actualy execute
                return results.ToList();
            }
        }

    }
}
