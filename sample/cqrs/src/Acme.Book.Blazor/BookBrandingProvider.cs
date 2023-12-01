using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Acme.Book.Blazor;

[Dependency(ReplaceServices = true)]
public class BookBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Book";
}
