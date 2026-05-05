namespace InterestCalculator.Domain.Services.Contracts;

public interface IInterestRateService
{
    Task<decimal> GetAsync(CancellationToken cancellationToken);
}