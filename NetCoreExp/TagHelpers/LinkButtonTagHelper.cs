using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace NetCoreExp.TagHelpers
{
    public class LinkButtonTagHelper:TagHelper
    {
        public string Action { get; set; } = "Index";

        public string Controller { get; set; } = "Home";

        public string BgColor { get; set; } = "primary";

        public string Name { get; set; }

        public string Id { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", $"btn btn-{BgColor}");
            output.Attributes.SetAttribute("href", $"/{Controller}/{Action}/{Id}");
            output.Content.SetContent(Name);
        }
    }
}
