using Acme.Book.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Acme.Book.Blazor;

public abstract class BookComponentBase : AbpComponentBase
{
    protected BookComponentBase()
    {
        LocalizationResource = typeof(BookResource);
    }
}
