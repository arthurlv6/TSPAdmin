using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSP.Shared
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class PatchUpdate
    {
        public string op { get; set; }
        public string path { get; set; }
        public string value { get; set; }
    }
    public enum PatchUpdateItem
    {
        Name,
        Style,
        Color,
        Size,
        Price,
        Quatity,
        Description
    }
    public class PaginationModel
    {
        public int Page { get; set; } = 1;
        public int QuantityPerPage { get; set; } = 10;
    }
    public class PageDataModel<T>
    {
        public List<T> Data { get; set; }
        public int PageQuantity { get; set; }
    }
    public class SubSystemModel:BaseModel
    {

    }
    public class SubMenuItemModel : BaseModel
    {
        public SubSystem SubSystem { get; set; }
        public int SubSystemId { get; set; }
        public IList<SubItemDetailModel> SubItemDetails { get; set; }
    }
    public class SubItemDetailModel : BaseModel
    {
        public int SubMenuItemId { get; set; }
        public string Title { get; set; }
        public string Paragraph { get; set; }
        public string Image { get; set; }
        public SubMenuItemModel SubMenuItem { get; set; }
        public bool IsShowDetail { get; set; }
    }
}
