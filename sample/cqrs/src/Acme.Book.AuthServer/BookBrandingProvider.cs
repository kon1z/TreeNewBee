using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Acme.Book;

[Dependency(ReplaceServices = true)]
public class BookBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Book";
}
