using AutoMapper;
using CF.ConceptBrainService.Application.Common.Bases;
using CF.ConceptBrainService.Application.Common.Constants;
using CF.ConceptBrainService.Application.Common.Interfaces;
using CF.ConceptBrainService.Application.Common.Mappings;
using CF.ConceptBrainService.Application.Features.GenerateConceptFeatures.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Application.Features.GenerateConceptFeatures.Query
{
    public class GetConceptByProjectRevisionIdQuery : BasePaginationQuery<ConceptSummaryDto>
    {
        public Guid ProjectRevisonId { get; set; }
        public string? ProcessingScheme { get; set; }
        public string? EvacuationScheme { get; set; }
        //public bool? ContaminantManagementCurrenty { get; set; }
        //public bool? ContaminantManagementFuture { get; set; }
        //public string? EnhancedRecovery { get; set; }
        //public string? WellTest { get; set; }
        public string[] productionProfile { get; set; }

        public class GetConceptByProjectRevisionIdQueryHandler : IRequestHandler<GetConceptByProjectRevisionIdQuery, PaginatedList<ConceptSummaryDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetConceptByProjectRevisionIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<PaginatedList<ConceptSummaryDto>> Handle(GetConceptByProjectRevisionIdQuery query, CancellationToken cancellationToken)
            {
                List<ConceptSummaryDto> objConceptList = new List<ConceptSummaryDto>();
                var queueId = _unitOfWork.ProjectConceptQueueRepository.Filter(x => x.IsDeleted == false && x.ProjectRevisionId == query.ProjectRevisonId).OrderByDescending(x => x.CreatedOn).FirstOrDefault();
                if (queueId != null)
                {
                    var concepts = _unitOfWork.ConceptRepository.Filter(x => x.IsDeleted == false && x.RevisonId == query.ProjectRevisonId && x.ProjectConceptQueueId == queueId.Id).ToList();

                    var conceptsQry = _unitOfWork.ConceptRepository.Filter(x => x.IsDeleted == false && x.RevisonId == query.ProjectRevisonId && x.ProjectConceptQueueId == queueId.Id);
                    if (conceptsQry != null)
                    {
                        if (query.productionProfile != null && query.productionProfile.Length > 0)
                        {
                            for (var i = 0; i < query.productionProfile.Length; i++)
                            {
                                query.productionProfile[i] = query.productionProfile[i].Trim().ToLower();
                            }
                            conceptsQry = conceptsQry.Where(x => query.productionProfile.Contains(x.Plevel.ToLower()));
                        }
                    }
                    var result = await conceptsQry.PaginatedListAsync(query.PageIndex, query.PageSize);

                    if (result != null)
                    {
                        foreach (var conceptItem in result.Items)
                        {
                            var conceptDcDetails = _unitOfWork.ConceptDCDetailsRepository.Filter(x => x.IsDeleted == false && x.ConceptId == conceptItem.Id).ToList();
                            //Add filters//
                            if (query.ProcessingScheme != null && query.ProcessingScheme.Trim().Length > 0)
                            {
                                conceptDcDetails = conceptDcDetails.Where(x => x.ProcessingScheme.ToLower() == query.ProcessingScheme.ToLower()).ToList();
                            }
                            if (query.EvacuationScheme != null && query.EvacuationScheme.Trim().Length > 0)
                            {
                                conceptDcDetails = conceptDcDetails.Where(x => x.EvacuationScheme.ToLower() == query.EvacuationScheme.ToLower()).ToList();
                            }
                            //if (query.ContaminantManagementCurrenty != null)
                            //{
                            //    conceptDcDetails = conceptDcDetails.Where(x => x.ContaminantManagementCurrenty == query.ContaminantManagementCurrenty).ToList();
                            //}
                            //if (query.ContaminantManagementFuture != null)
                            //{
                            //    conceptDcDetails = conceptDcDetails.Where(x => x.ContaminantManagementFuture == query.ContaminantManagementFuture).ToList();
                            //}
                            //if (query.EnhancedRecovery != null)
                            //{
                            //    conceptDcDetails = conceptDcDetails.Where(x => x.EnhancedRecovery == query.EnhancedRecovery).ToList();
                            //}
                            //if (query.WellTest != null)
                            //{
                            //    conceptDcDetails = conceptDcDetails.Where(x => x.WellTest == query.WellTest).ToList();
                            //}
                            // End Filters//
                            if (conceptDcDetails != null)
                            {
                                string hostType = "";

                                Dictionary<string, int> hostTypegrp = conceptDcDetails.Select(x => x.SubStructureType).GroupBy(x => x).Where(g => g.Count() > 0).ToDictionary(x => x.Key, x => x.Count());
                                //string hosttype = " " + String.Join(",", hostTypegrp);

                                foreach (var hostresult in hostTypegrp)
                                {
                                    hostType = hostType + $"{hostTypegrp[hostresult.Key]} X {hostresult.Key},";
                                }

                                ConceptSummaryDto objConcept = new ConceptSummaryDto();
                                //foreach (var conceptDcDetailsItems in conceptDcDetails)
                                //{
                                objConcept.Type = conceptItem.Plevel;
                                objConcept.Name = conceptItem.ConceptName;
                                objConcept.BaseConcept = conceptItem.IsBaseConcept;
                                objConcept.IsBookmarked = conceptItem.IsBookmarked;
                                objConcept.OilProd = conceptDcDetails.Sum(x => x.OilProd);
                                objConcept.WaterInj = conceptDcDetails.Sum(x => x.WaterInj);
                                objConcept.GasProd = conceptDcDetails.Sum(x => x.GasProd);
                                objConcept.GasInj = conceptDcDetails.Sum(x => x.GasInj);
                                objConcept.ProcessingScheme = conceptDcDetails.Where(x => x.DCName == FormulaFieldName.DC1).Select(x => x.ProcessingScheme).FirstOrDefault();
                                objConcept.EvacuationScheme = conceptDcDetails.Where(x => x.DCName == FormulaFieldName.DC1).Select(x => x.EvacuationScheme).FirstOrDefault();
                                objConcept.HostType = hostType;
                                objConceptList.Add(objConcept);
                                //}
                            }
                        }

                    }
                    var finalresult = new PaginatedList<ConceptSummaryDto>(objConceptList, result.TotalCount, result.PageIndex, query.PageSize);
                    return finalresult;
                }
                else
                {
                    return null;

                }




            }
        }
    }
}
