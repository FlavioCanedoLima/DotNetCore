using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCCore.TagHelpers
{
    [HtmlTargetElement("email", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class MailTagHelper : TagHelper
    {
        public string MailTo { get; set; }
        public string MailInfo { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            output.Attributes.SetAttribute("href", "mailto:" + MailTo);
            output.Content.SetContent(MailInfo);
        }
    }
}
