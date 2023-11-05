using BackEnd_ApiTech.Shared.Persistence.Repositories;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Repositories;
using BackEnd_ApiTech.TechXPrime.Domain.Services;
using BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;

namespace BackEnd_ApiTech.TechXPrime.Services;

public class AnalyticService : IAnalyticService
{
    private readonly IAnalyticRepository _analyticRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AnalyticService(IAnalyticRepository analyticRepository, IUnitOfWork unitOfWork)
    {
        _analyticRepository = analyticRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Analytic>> ListByMonthAsync(int month)
    {
        return await _analyticRepository.ListByMonthAsync(month);
    }

    public async Task<AnalyticResponse> SaveAsync(Analytic analytic)
    {
        try
        {
            await _analyticRepository.AddAsync(analytic);
            await _unitOfWork.CompleteAsync();
            return new AnalyticResponse(analytic);
        }
        catch (Exception e)
        {
            return new AnalyticResponse($"An error occurred while saving the category: {e.Message}");
        }

    }

    public async Task<AnalyticResponse> UpdateAsync(int id, Analytic analytic)
    {
        var existingAnalytic = await _analyticRepository.FindByIdAsync(id);
        if (existingAnalytic == null)
            return new AnalyticResponse("Category not found.");
        existingAnalytic.Incomes = analytic.Incomes;
        existingAnalytic.Expenses = analytic.Expenses;
        existingAnalytic.Profits = analytic.Profits;
        try
        {
            _analyticRepository.Update(existingAnalytic);
            await _unitOfWork.CompleteAsync();
            return new AnalyticResponse(existingAnalytic);
        }
        catch (Exception e)
        {
            return new AnalyticResponse($"An error occurred while updating the category: {e.Message}");
        }
    }

    public async Task<AnalyticResponse> DeleteAsync(int id)
    {
        var existingAnalytic = await _analyticRepository.FindByIdAsync(id);
        if (existingAnalytic == null)
            return new AnalyticResponse("Category not found.");
        try
        {
            _analyticRepository.Remove(existingAnalytic);
            await _unitOfWork.CompleteAsync();
            return new AnalyticResponse(existingAnalytic);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new AnalyticResponse($"An error occurred while deleting the category: {e.Message}");
        }
    }
}