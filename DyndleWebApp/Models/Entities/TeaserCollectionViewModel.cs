using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DyndleWebApp.Models.Entities
{
    public class TeaserCollectionViewModel
    {
        public List<Teaser> Teasers { get; set; } = new List<Teaser>();
    }
}