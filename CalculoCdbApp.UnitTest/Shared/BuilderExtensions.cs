
namespace CalculoCdbApp.UnitTests.Shared;

internal static class BuilderExtensions
{
    internal static Faker<TInstance> UsePrivateConstructor<TInstance>(this Faker<TInstance> faker)
        where TInstance : class
    {
        return faker.CustomInstantiator(f => (Activator.CreateInstance(typeof(TInstance), nonPublic: true) as TInstance)!);
    }
}
