using DD4T.ContentModel;
using DD4T.Mvc.ViewModels.Attributes;
using DD4T.ViewModels.Attributes;
using DD4T.ViewModels.Base;
using Dyndle.Modules.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace DyndleWebApp.Models.Entities
{
    [ContentModel("TeaserCollection", true)]      // ← matches schema root element name in CM
    public class TeaserCollection : EntityModel
    {

        [TextField(FieldName = "test")]
        public virtual string Test { get; set; }

        // Use IComponentLink list to get the TCM URIs
        [LinkedComponentField(FieldName = "teasers")]
        public virtual List<IComponent> teasers { get; set; }
    }
}