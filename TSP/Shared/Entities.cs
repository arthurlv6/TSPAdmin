using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSP.Shared
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public T ToModel<T>(IMapper mapper) where T : BaseModel
        {
            return mapper.Map<T>(this);
        }
    }
    public class SubSystem:BaseEntity
    {
        public IList<SubMenuItem> SubMenuItems { get; set; }
        // tsp, revlution, greenhaven and staff
        public int Order { get; set; }
    }
    public class SubMenuItem : BaseEntity
    {
        public SubSystem SubSystem { get; set; }
        public int SubSystemId { get; set; }
        public IList<SubItemDetail> SubItemDetails { get; set; }
        // for tsp we have home, team, gallery, about us and current project
        public int Order { get; set; }
    }
    public class SubItemDetail : BaseEntity
    {
        public int SubMenuItemId { get; set; }
        public string Title { get; set; }
        public string Paragraph { get; set; }
        public string Image { get; set; }
        public int Order { get; set; }
        public bool Available { get; set; }
        public SubMenuItem SubMenuItem { get; set; }
    }
}
