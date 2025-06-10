namespace CalculoCdbApp.UnitTests.Shared;

internal abstract class CoreBuilder<TInstance>
    where TInstance : class
{
    private bool _generateValuesWhenNullOrDefault = true;

    internal virtual TInstance Build() => Build(1).Single();

    internal virtual List<TInstance> Build(int count) => Faker().Generate(count);

    protected internal bool IsGenerateValuesWhenNullOrDefault() => _generateValuesWhenNullOrDefault;

    protected internal virtual Faker<TInstance> Faker() => Faker("pt_BR");

    protected internal virtual Faker<TInstance> Faker(string locale) =>
        new Faker<TInstance>(locale).UsePrivateConstructor();

    internal CoreBuilder<TInstance> WithGenerateValuesWhenNullOrDefault(bool generateValuesWhenNullOrDefault)
    {
        _generateValuesWhenNullOrDefault = generateValuesWhenNullOrDefault;
        return this;
    }
}
