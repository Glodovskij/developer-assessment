using AutoMapper;
using DataExporter.Application.Dtos;
using DataExporter.Application.Interfaces;
using DataExporter.Domain.Entities;
using DataExporter.Domain.Repositories;

namespace DataExporter.Application.Implementations
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository _policyRepository;
        private readonly IMapper _mapper;

        public PolicyService(IPolicyRepository policyRepository, IMapper mapper)
        {
            _policyRepository = policyRepository;
            _mapper = mapper;
        }

        public async Task<CreatePolicyDto> CreatePolicyAsync(CreatePolicyDto createPolicyDto)
        {
            var policy = _mapper.Map<Policy>(createPolicyDto);

            var result = await _policyRepository.CreatePolicyAsync(policy);

            var resultPolicy = _mapper.Map<CreatePolicyDto>(result);

            return resultPolicy;
        }

        public async Task<IList<ReadPolicyDto>> ReadPoliciesAsync()
        {
            var result = await _policyRepository.ReadPoliciesAsync();

            var readPolicies = _mapper.Map<List<ReadPolicyDto>>(result);

            return readPolicies;
        }

        public async Task<ReadPolicyDto> ReadPolicyAsync(int id)
        {
            var result = await _policyRepository.ReadPolicyAsync(id);

            var readPolicyDto = _mapper.Map<ReadPolicyDto>(result);

            return readPolicyDto;
        }
    }
}
