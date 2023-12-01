using Volo.Abp.Modularity;

namespace Acme.Book;

[DependsOn(
    typeof(BookApplicationModule),
    typeof(BookDomainTestModule)
    )]
public class BookApplicationTestModule : AbpModule
{

}
