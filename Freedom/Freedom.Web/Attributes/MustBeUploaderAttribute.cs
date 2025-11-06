using Freedom.Web.Attributes.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Freedom.Web.Attributes;

public class MustBeUploaderAttribute : TypeFilterAttribute
{
    public MustBeUploaderAttribute() 
        : base(typeof(MustBeUploaderFilter))
    {
    }
}