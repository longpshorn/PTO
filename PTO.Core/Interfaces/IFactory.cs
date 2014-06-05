namespace PTO.Core.Interfaces
{
	public interface IFactory<out T>
	{
		T Create();
	}
}
