namespace Demo.Entities;

public interface IHasCreator
{
	Guid? CreatorUserId { get; set; }
}