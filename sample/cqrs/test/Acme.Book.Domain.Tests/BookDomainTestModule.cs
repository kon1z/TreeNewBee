using Acme.Book.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Acme.Book;

[DependsOn(
    typeof(BookEntityFrameworkCoreTestModule)
    )]
public class BookDomainTestModule : AbpModule
{

}
