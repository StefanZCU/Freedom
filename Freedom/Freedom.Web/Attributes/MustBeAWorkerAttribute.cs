using Freedom.Web.Attributes.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Freedom.Web.Attributes;

public class MustBeAWorkerAttribute : TypeFilterAttribute
{
    public MustBeAWorkerAttribute() 
        : base(typeof(MustBeAWorkerFilter))
    {
    }
}