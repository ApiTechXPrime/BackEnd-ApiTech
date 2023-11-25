using BackEnd_ApiTech.Shared.Persistence.Repositories;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Repositories;
using BackEnd_ApiTech.TechXPrime.Domain.Services;
using BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;

namespace BackEnd_ApiTech.TechXPrime.Services;

public class TechnicalsService : ITechnicalService
{
    private readonly ITechnicalRepository _technicalRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TechnicalsService(ITechnicalRepository technicalRepository, IUnitOfWork unitOfWork)
    {
        _technicalRepository = technicalRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Technical>> ListAsync()
    {
        return await _technicalRepository.ListAsync();
    }

    public async Task<Technical> FindByEmail(string email)
    {
        return await _technicalRepository.FindByEmailAsync(email);
    }

    public async Task<TechnicalResponse> SaveAsync(Technical technical)
    {
        try
        {
            await _technicalRepository.AddAsync(technical);
            await _unitOfWork.CompleteAsync();
            return new TechnicalResponse(technical);
        }
        catch (Exception e)
        {
            return new TechnicalResponse($"An error occurred while saving the technical: {e.Message}");
        }
    }

    public async Task<TechnicalResponse> UpdateAsync(int id, Technical technical)
    {
        var existingTechnical = await _technicalRepository.FindByIdAsync(id);
        if (existingTechnical == null)
            return new TechnicalResponse("Technical not found.");
        existingTechnical.FullName = technical.FullName;
        existingTechnical.Location = technical.Location;
        existingTechnical.Image = technical.Image;
        existingTechnical.ConsultationPrice = technical.ConsultationPrice;
        existingTechnical.Number = technical.Number;
        try
        {
            _technicalRepository.Update(existingTechnical);
            await _unitOfWork.CompleteAsync();
            return new TechnicalResponse(existingTechnical);
        }
        catch (Exception e)
        {
            return new TechnicalResponse($"An error occurred while updating the technical: {e.Message}");
        }
    }

    public async Task<TechnicalResponse> DeleteAsync(int id)
    {
        var existingTechnical = await _technicalRepository.FindByIdAsync(id);
        if(existingTechnical == null)
            return new TechnicalResponse("Technical not found.");
        try
        {
            _technicalRepository.Remove(existingTechnical);
            await _unitOfWork.CompleteAsync();
            return new TechnicalResponse(existingTechnical);
        }
        catch (Exception e)
        {
            return new TechnicalResponse($"An error occurred while deleting the technical: {e.Message}");
        }
    }
}