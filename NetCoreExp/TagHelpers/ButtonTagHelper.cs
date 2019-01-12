using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace NetCoreExp.TagHelpers
{
    [HtmlTargetElement("button", Attributes = "bs-button-color")]
    [HtmlTargetElement("a", Attributes = "bs-button-color")]
    public class ButtonTagHelper:TagHelper
    {
        public string BsButtonColor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", $"btn btn-{BsButtonColor}");
        }
    }
}
